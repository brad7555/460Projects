using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab7.Models
{
    public class CommitModel
    {
        public string Sha { get; set; }
        public string Committer { get; set; }
        public string Date { get; set; }
        public string Message { get; set; }
        public string CommitUrl { get; set; }
        
    }
}