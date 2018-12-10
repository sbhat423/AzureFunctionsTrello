using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace TrelloBoardCreate
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            // parse query parameter
            string url = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "url", true) == 0)
                .Value;

            string name = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "name", true) == 0)
                .Value;

            string defaultLabels = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "defaultLabels", true) == 0)
                .Value;

            string defaultLists = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "defaultLists", true) == 0)
                .Value;

            string keepFromSource = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "keepFromSource", true) == 0)
                .Value;

            string prefs_permissionLevel = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "prefs_permissionLevel", true) == 0)
                .Value;

            string prefs_comments = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "prefs_comments", true) == 0)
                .Value;

            string prefs_invitations = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "prefs_invitations", true) == 0)
                .Value;

            string prefs_selfJoin = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "prefs_selfJoin", true) == 0)
                .Value;

            string prefs_cardCovers = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "prefs_cardCovers", true) == 0)
                .Value;

            string prefs_background = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "prefs_background", true) == 0)
                .Value;

            string prefs_cardAging = req.GetQueryNameValuePairs()
                .FirstOrDefault(q => string.Compare(q.Key, "prefs_cardAging", true) == 0)
                .Value;

            string key = req.GetQueryNameValuePairs()
               .FirstOrDefault(q => string.Compare(q.Key, "key", true) == 0)
               .Value;

            string token = req.GetQueryNameValuePairs()
               .FirstOrDefault(q => string.Compare(q.Key, "token", true) == 0)
               .Value;



            if (name == null)
            {
                // Get request body
                dynamic data = await req.Content.ReadAsAsync<object>();
                name = data?.name;
            }

            var client = new HttpClient();
            var values = new List<KeyValuePair<string, string>>();
            values.Add(new KeyValuePair<string, string>("name", name));
            values.Add(new KeyValuePair<string, string>("defaultLabels", defaultLabels));
            values.Add(new KeyValuePair<string, string>("defaultLists", defaultLists));
            values.Add(new KeyValuePair<string, string>("keepFromSource", keepFromSource));
            values.Add(new KeyValuePair<string, string>("prefs_permissionLevel", prefs_permissionLevel));
            values.Add(new KeyValuePair<string, string>("prefs_comments", prefs_comments));
            values.Add(new KeyValuePair<string, string>("prefs_invitations", prefs_invitations));
            values.Add(new KeyValuePair<string, string>("prefs_selfJoin", prefs_selfJoin));
            values.Add(new KeyValuePair<string, string>("prefs_cardCovers", prefs_cardCovers));
            values.Add(new KeyValuePair<string, string>("prefs_background", prefs_background));
            values.Add(new KeyValuePair<string, string>("prefs_cardAging", prefs_cardAging));
            values.Add(new KeyValuePair<string, string>("key", key));
            values.Add(new KeyValuePair<string, string>("token", token));
            // include other fields
            var content = new FormUrlEncodedContent(values);
            var response = await client.PostAsync(url, content);

            
            return name == null
                ? req.CreateResponse(HttpStatusCode.BadRequest, "Please pass a name on the query string or in the request body")
                : req.CreateResponse(HttpStatusCode.OK, "Success");

        }
    }
}