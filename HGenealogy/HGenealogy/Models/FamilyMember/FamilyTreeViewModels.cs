using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HGenealogy.Data;
using HGenealogy.Models.Common;
using System.Web.Mvc;
using HGenealogy.Models.PedigreeMeta;

namespace HGenealogy.Models.FamilyMember
{
    public class FamilyTreeViewModel
    {
        public List<node> nodes;
        public List<link> links;
    }

    public class node
    {
        public string id { get; set; }
        public string name { get; set; }
        public string gid { get; set; }
        public string groupid { get; set; }
        public string imageurl { get; set; }
    }

    public class link
    {
        public string name { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string value { get; set; }
        public string weight { get; set; }
    }    
}