using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrainStation23_Please_Consider_For_Blazor.Data
{
    public class ReportServices :IReportService
    {
        public async Task<List<Posting>> GetInfo()
        {
            ////Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3


            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44308/api/getReport/0");
            response.EnsureSuccessStatusCode();
            string responseBody =  response.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(responseBody);
            var data = obj["data"];

            List<Posting> post = new List<Posting>();

            foreach(var ss in data)
            {
                var kkk = ss["Key"].ToList();

                var pos = new Posting
                {
                    Post = kkk[0]["post"].ToString(),
                    user = kkk[0]["user"].ToString(),
                    Time = kkk[0]["time"].ToString(),
                    CommentCount= kkk[0]["commentCount"].ToString()
                };

              

                post.Add(pos);
            }

            return post;
        }

        public async Task<List<Commenting>> GetInfo2()
        {
            ////Install-Package Microsoft.AspNetCore.Blazor.HttpClient -Version 3.2.0-preview3.20168.3


            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:44308/api/getReport/0");
            response.EnsureSuccessStatusCode();
            string responseBody = response.Content.ReadAsStringAsync().Result;
            JObject obj = JObject.Parse(responseBody);
            var data = obj["data"];

            List<Commenting> comment = new List<Commenting>();

            foreach (var ss in data)
            {
                var kkk = ss["Value"].ToList();

                var com = new  Commenting
                {
                    data = kkk[0]["data"].ToString(),
                    user = kkk[0]["user"].ToString(),
                    time = kkk[0]["time"].ToString(),
                    like = kkk[0]["like"].ToString(),
                    disLike = kkk[0]["disLike"].ToString()
                };

                comment.Add(com);
            }

            return comment;
        }



      
    }
}
