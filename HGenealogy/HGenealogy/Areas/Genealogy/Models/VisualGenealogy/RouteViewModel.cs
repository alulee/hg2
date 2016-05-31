using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.SharedClass;

namespace HGenealogy.Areas.Genealogy.Models
{
    public class RouteViewModel
    {
        public string eventName { get; set; }
        public string fromPointDescr { get; set; }
        public GeoPoint fromPoint { get; set; }
        public string toPointDescr { get; set; }
        public GeoPoint toPoint { get; set; }
    }
}