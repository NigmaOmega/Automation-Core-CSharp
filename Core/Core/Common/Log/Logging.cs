using Serilog;
using Serilog.Formatting.Elasticsearch;
using Serilog.Sinks.Elasticsearch;
using System;

namespace Core
{
    public static class Logging
    {
        public static LoggerConfiguration GetElasticSearchConfig(string elasticSearchUri, string indexFormat = "")
        {
            if (indexFormat == "")
            {
                indexFormat = $"AutomationLog-{DateTime.UtcNow:yyyy-MM}";
            }
            var config = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console(new ElasticsearchJsonFormatter())
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticSearchUri))
                {
                    AutoRegisterTemplate = true,
                    IndexFormat = indexFormat
                });

            return config;
        }

    }
}