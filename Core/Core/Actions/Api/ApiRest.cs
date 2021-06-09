using RestSharp;
using System.Collections.Generic;

namespace Core
{
    public static class ApiRest
    {
        public static IRestResponse Call(Method apiMethod, string url, string jsonBody = null, Dictionary<string, string> headers = null, Dictionary<string, object> parameters = null, Dictionary<string, object> pathParameters = null)
        {
            RestClient client = new RestClient(url);

            IRestRequest request = new RestRequest("", apiMethod);

            //Add Body
            if (jsonBody != null)
            {
                request.AddJsonBody(jsonBody);
            }

            //Add header
            if (headers != null)
            {
                request.AddHeaders(headers);
            }

            //Add parameter
            if (parameters != null)
            {
                request = request.AddParameters(parameters);
            }

            //Add QueryParameter

            if (pathParameters != null)
            {
                foreach (var item in pathParameters)
                {
                    request = request.AddUrlSegment(item.Key, item.Value);
                }
            }

            IRestResponse response = client.Execute(request);

            return response;
        }

        private static IRestRequest AddParameters(this IRestRequest request, Dictionary<string, object> parameters)
        {
            foreach (var parameter in parameters)
            {
                request.AddParameter(parameter.Key, parameter.Value);
            }

            return request;
        }

    }
}