using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Lab7.Models; 

namespace Lab7.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["token"];
            

            //Getting personal info
            string ced = SendRequest("Https://api.github.com/user", key, "brad7555");
            ViewBag.cred = ced;
            Person person = JsonConvert.DeserializeObject<Person>(ced);

            ViewData["myPerson"] = person; 
           
            //Getting repo info
            string repoInfo = SendRequest("Https://api.github.com/user/repos", key, "brad7555");
            //List<Repos> repo = new List<Repos>(); 
            var repo = JsonConvert.DeserializeObject<List<Repos>>(repoInfo);
            //repo.Add(JsonConvert.DeserializeObject<Repos>(repoInfo));
            
            
           
            //person.repo = JsonConvert.DeserializeObject<Repos>(repoInfo);

            //Getting commits info
           






            return View(repo); 
            
        }

        public JsonResult Creds()
        {

            return Json(JsonRequestBehavior.AllowGet); 
        }

        private string SendRequest(string uri, string credentials, string username)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Headers.Add("Authorization", "token " + credentials);
            request.UserAgent = username;       // Required, see: https://developer.github.com/v3/#user-agent-required
            request.Accept = "application/json";

            string jsonString = null;
            // TODO: You should handle exceptions here
            using (WebResponse response = request.GetResponse())
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                jsonString = reader.ReadToEnd();
                reader.Close();
                stream.Close();
            }
            return jsonString;
        }

        public ActionResult commits()
        {
            string key = System.Web.Configuration.WebConfigurationManager.AppSettings["token"];
            string Url = "https://api.github.com/repos/" + Request.QueryString["user"] + "/" + Request.QueryString["repo"] + "/commits";
            string username = Request.QueryString["user"];
            string json = SendRequest(Url, key, username);
            JArray gitInfo = JArray.Parse(json);
            // Do what is needed to obtain a C# object containing data you wish to convert to JSON
            List<CommitModel> commitList = new List<CommitModel>();
            //Going through data, assigning data into string variables, and adding those to new list to pass back
            int length = gitInfo.Count;
            for (int i = 0; i < length; i++)
            {
                string sha = (string)gitInfo[i]["sha"];
                string committer = (string)gitInfo[i]["commit"]["committer"]["name"];
                string whenCommitted = (string)gitInfo[i]["commit"]["committer"]["date"];
                string commitMessage = (string)gitInfo[i]["commit"]["message"];
                string commitUrl = (string)gitInfo[i]["html_url"];
                commitList.Add(new CommitModel() { Sha = sha, Committer = committer, Date = whenCommitted, Message = commitMessage, CommitUrl = commitUrl });
            }

            return new ContentResult
            {
                // serialize C# object "commits" to JSON using Newtonsoft.Json.JsonConvert
                Content = JsonConvert.SerializeObject(commitList),
                ContentType = "application/json",
                ContentEncoding = System.Text.Encoding.UTF8
            };
        }


    }
   
    
}