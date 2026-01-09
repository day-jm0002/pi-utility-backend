using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Proxy.ApiCatalogRendaFixa.Response
{
    public class CacheInfoResponse
    {
    [JsonPropertyName("useCache")]
        public bool UseCache { get; set; }

        [JsonPropertyName("cacheExpiration")]
        public DateTime CacheExpiration { get; set; }

        [JsonPropertyName("itemsCount")]
        public int ItemsCount { get; set; }

        [JsonPropertyName("keys")]
        public List<string> Keys { get; set; }
    }
}
