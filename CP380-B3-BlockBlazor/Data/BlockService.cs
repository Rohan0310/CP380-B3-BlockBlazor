using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using CP380_B1_BlockList.Models;


namespace CP380_B3_BlockBlazor.Data
{
    public class BlockService
    {
        // TODO: Add variables for the dependency-injected resources
        //       - httpClient
        //       - configuration
        //
        static HttpClient _httpClient;
        private readonly IConfiguration _config;

        public BlockService(IHttpClientFactory httpClientFactory, IConfiguration configuration) 
        {
            _httpClient = httpClientFactory.CreateClient();
            _config = configuration.GetSection("BlockService");

        
        
        }

        //
        // TODO: Add a constructor with IConfiguration and IHttpClientFactory arguments
        //
        public async Task<IEnumerable<Block>> GetBlocksAsync()
        {
            var response = await _httpClient.GetAsync(_config["url"]);
            if (response.IsSuccessStatusCode)
            {
                JsonSerializerOptions options = new(JsonSerializerDefaults.Web);
                return await JsonSerializer.DeserializeAsync<IEnumerable<Block>>(


                    await response.Content.ReadAsStreamAsync(), options 


                    );
          

            }
            return Array.Empty<Block>();

        }

        //
        // TODO: Add an async method that returns an IEnumerable<Block> (list of Blocks)
        //       from the web service
        //

    }
}

