using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using webapidapper.Data;
using webapidapper.Data.Models;

namespace webapidapper.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SampleController : ControllerBase
    {
        private ISampleRepository _sampleRepository;

        public SampleController(ISampleRepository sampleRepository)
        {
            _sampleRepository = sampleRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _sampleRepository.Get();
                if (result is null) return NotFound();
                else return Ok(result);

                //var sample = new string[] {"sample1","sample2"};
                //return Ok(sample);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //return StatusCode(500);

                return Ok(ex.Message);
            }
        }

        [HttpGet("sampledata")]
        public async Task<IActionResult> GetSampleData()
        {
            try
            {
                var sampledata = new List<SampleTable>()
                {
                    new SampleTable { Id = 1, Description = "value 1" },
                    new SampleTable { Id = 2, Description = "value 2" },
                    new SampleTable { Id = 3, Description = "value 3" },
                    new SampleTable { Id = 4, Description = "value 4" },
                    new SampleTable { Id = 5, Description = "value 5" }
                };

                return Ok(sampledata);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //return StatusCode(500);

                return Ok(ex.Message);
            }
        }

        [HttpGet("sampledata/{id}")]
        public async Task<IActionResult> GetSampleDataById(int id)
        {
            try
            {
                var sampledata = new List<SampleTable>()
                {
                    new SampleTable { Id = 1, Description = "value 1 - modified" },
                    new SampleTable { Id = 2, Description = "value 2" },
                    new SampleTable { Id = 3, Description = "value 3" },
                    new SampleTable { Id = 4, Description = "value 4" }
                };

                return Ok(sampledata.Where(item => item.Id == id).ToList());
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //return StatusCode(500);

                return Ok(ex.Message);
            }
        }


        [HttpPost("postsomedata")]
        public async Task<IActionResult> PostSomeData([FromBody] SampleRequest request) //
        {
            try
            {
                //Console.WriteLine(request.Data.Count.ToString());
                return Ok(request);
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                //return StatusCode(500);

                return Ok(ex.Message);
            }
        }
    }
}
