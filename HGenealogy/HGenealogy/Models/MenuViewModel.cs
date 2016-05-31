using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HGenealogy.Models;

namespace HGenealogy.Models
{

    public class MenuViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MenuId { get; set; }

        [Required]
        public string Name { get; set; }

        public string Controller { get; set; }

        public string Action { get; set; }

        public string Url { get; set; }

        public string Description { get; set; }

        public int? ParentId { get; set; }

        public int Status { get; set; }

        public string RouteValues { get; set; }

        public int? OrderSerial { get; set; }


        // Navigation Properties
        // public virtual ICollection<Role> Roles { get; set; }
    }
}