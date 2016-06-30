using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HGenealogy.Models.PedigreeMeta
{
    public class PedigreeMetaSimpleQueryModel
    {

        [DisplayName("姓氏")]
        public string FamilyName { get; set; }

        [DisplayName("族譜名稱")]
        public string Title { get; set; }
      
    }
}