using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using webapidapper.Data;
using webapidapper.Data.Models;
using System.Data;
using Microsoft.Extensions.Options;

namespace webapidapper.Data
{
    public interface ISampleRepository
    {
        Task<List<SampleTable>> Get();
    }

    public class SampleRepository : RepositoryBase, ISampleRepository
    {        
        public SampleRepository() 
        { }

        public async Task<List<SampleTable>> Get()
        {
            
            using (IDbConnection conn = OpenConnection())
            {
                var result = await conn.QueryAsync<SampleTable>("select * from dbo.SampleTable");
                return result.ToList();
            }
            
			/*
            var sampleResult = new List<SampleTable>();

            sampleResult.Add(new SampleTable()
            {
                Id = 1,
                Description = "Sample"
            });

            return sampleResult;
			*/
        }
    }
}
