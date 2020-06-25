using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class Home
    {
    }
    public class Person
    {
        public string login { get; set; }
        public string url { get; set; }
        public string repos_url { get; set; }
        public string html_url { get; set; }
        public string email { get; set;  }
        public string name { get; set; }
        public string avatar_url { get; set; }
        public List<Repos> repo { get; set; }
    }

    public class Owner
    {
        public string login { get; set; }
        public string avatar_url { get; set; }
        public string html_url { get; set; }
    }

    public class Repos
    {
        public string name { get; set; }
        public Owner owner { get; set; }
        public string commits_url { get; set; }
        public DateTime updated_at { get; set; }
    }

}