﻿using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ContextSample.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Poc.ThreadAndTask.CustomExceptions;
using Poc.ThreadAndTask.Repositories;

namespace Poc.ThreadAndTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly ILogger<ValuesController> _logger;
        private readonly IServiceScopeFactory serviceScope;
        private readonly ILocalRepository localRepository;
        private readonly SampleRepository sampleRepository;

        public ValuesController(ILogger<ValuesController> logger, IServiceScopeFactory serviceScope,
            ILocalRepository localRepository, SampleRepository sampleRepository)
        {
            _logger = logger;
            this.serviceScope = serviceScope;
            this.localRepository = localRepository;
            this.sampleRepository = sampleRepository;
        }

        [HttpGet("v1")]
        public IActionResult Get()
        {
            Console.WriteLine($"[v1]: Started: Get memory string;");
            string xpto = "Thiago";

            new Thread( (value) =>
            {
                Thread.Sleep(3000);
                Console.WriteLine($"[v1] Thread: '{xpto}'.");
            })
            .Start(xpto);

            Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"[v1] Task[{Task.CurrentId}]: '{xpto}'.");
            });

            return Ok($"Success [v1]");
        }


        [HttpGet("v1/{xpto}")]
        public IActionResult Get(string xpto)
        {
            /* 
             * Assim que 'xpto' entra na requisição, um espaço de memória é reservado para ele!
             * Percabe que, ao final do ciclo da requisição, a memória continua sendo utilizada pela Thread e Task criados.
             * Mesmo que eu tenha passado o valor para a Thread e a Task ANTES de mudar o seu valor, ela apresentam o novo valor.
             */

            Console.WriteLine($"[v1/{xpto}]: Started: get parameter(s)");

            new Thread((value) =>
            {
                Thread.Sleep(3000);
                Console.WriteLine($"[v1/{xpto}] Thread.");
            })
            .Start(xpto);

            Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"[v1/{xpto}] Task[{Task.CurrentId}];");
            });

            xpto = $"The value '{xpto}' has changed.";

            return Ok($"Success [v1/{xpto}]");
        }


        [HttpGet("v2")]
        public IActionResult GetV2()
        {
            Console.WriteLine($"[v2]: Started: No limit to finished!");

            Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"[v2] Task[{Task.CurrentId}]");
                return $"Origin Task[{Task.CurrentId}] ended.";
            })
            .ContinueWith((output) => 
            {
                output.Wait();
                Console.WriteLine($"[v2] Output: '{output.Result}'.");
                for(int i = 1; i <= 7; i++)
                {
                    Thread.Sleep(10000);
                    Console.WriteLine($"[v2] Task[{Task.CurrentId}]: Tic-Tac {10*i}s;");
                }
            })
            .ContinueWith((output) => 
            {
                if (output.IsCompletedSuccessfully)
                {
                    Console.WriteLine("[v2] Successful");
                }
                else
                {
                    Console.WriteLine("[v2] Failure");
                }
            });

            return Ok("Success [v2]");
        }

        [HttpGet("v3")]
        public IActionResult GetV3()
        {
            Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"[v3] Task[{Task.CurrentId}]");
                _logger.LogInformation($"Repository is null: '{localRepository is null}'.");
                
                string dataString = JsonConvert.SerializeObject(localRepository.GetAllData());
                _logger.LogInformation($"AllData: {dataString}");
            });

            return Ok("Success [v3]");
        }

        [HttpGet("v4")]
        public async Task<IActionResult> GetV4()
        {
            int countProducts = await Task.Run(() => 
            {
                Thread.Sleep(2000);
                return sampleRepository.Products.GetAll().Count();
            });

            _ = Task.Run(() =>
            {
                Thread.Sleep(5000);
                Console.WriteLine($"[v4] Task[{Task.CurrentId}]");
                _logger.LogInformation($"Repository is null: '{sampleRepository is null}'.");

                string dataString = JsonConvert.SerializeObject(sampleRepository.Products.PrintAll());
                _logger.LogInformation($"AllData: {dataString}");
            });

            return Ok($"Success [v4]. Has '{countProducts}' products;");
        }

        /// <summary>
        /// Sql Command: 'sp_who'
        /// </summary>
        /// <returns></returns>
        [HttpGet("v5")]
        public async Task<IActionResult> GetV5()
        {
            int countProducts = await Task.Run(() =>
            {
                Thread.Sleep(2000);
                return sampleRepository.Products.GetAll().Count();
            });

            _ = Task.Run(() =>
            {
                using var xpto = serviceScope.CreateScope();
                Thread.Sleep(5000);
                Console.WriteLine($"[v5] Task[{Task.CurrentId}]");
                var printAll = xpto.ServiceProvider.GetService<SampleRepository>().Products.PrintAll();
                string dataString = JsonConvert.SerializeObject(printAll);
                _logger.LogInformation($"AllData: {dataString}");
            });

            return Ok($"Success [v5]. Has '{countProducts}' products;");
        }

        [HttpGet("v6")]
        public async Task<IActionResult> GetV6()
        {
            int count = 1;
            while (count < 11)
            {
                _ = Task.Run(() =>
                {
                    using var xpto = serviceScope.CreateScope();
                    Thread.Sleep(5000);
                    Console.WriteLine($"[v5] Task[{Task.CurrentId}]");
                    var printAll = xpto.ServiceProvider.GetService<SampleRepository>().Products.PrintAll();
                    string dataString = JsonConvert.SerializeObject(printAll);
                    _logger.LogInformation($"AllData: {dataString}");
                });
                count++;
            }

            return Ok($"Success [v6]. Has X products;");
        }


        [HttpGet("errorTest")]
        public async Task<IActionResult> GetError()
        {
            try
            {
                try
                {
                    try
                    {
                        throw new InvalidOperationException("Simulando uma operação inválida!");
                    }
                    catch (Exception ex)
                    {
                        throw new Level01Exception("Primeiro nível", ex);
                    }
                }
                catch (Exception ex)
                {
                    throw new Level02Exception("Segundo nível", ex);
                }
            }
            catch (Exception ex)
            {
                throw new Level03Exception("Terceiro nível", ex);
            }
        }
    }
}