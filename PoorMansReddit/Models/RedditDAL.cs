using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace PoorMansReddit.Models
{
    public class RedditDAL
    {
        public string GetData()
        {
            string url = @"https://www.reddit.com/r/aww/.json";
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader rd = new StreamReader(response.GetResponseStream());
            string JSON = rd.ReadToEnd();
            return JSON;
        }

        public Rootobject GetPost()
        {
            string link = GetData();
            Rootobject ro = JsonConvert.DeserializeObject<Rootobject>(link);

            return ro;
        }
    }
}
