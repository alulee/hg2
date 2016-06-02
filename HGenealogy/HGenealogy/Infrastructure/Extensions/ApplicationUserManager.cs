using HGenealogy.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Data;

namespace HGenealogy.Infrastructure.Extensions
{
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(): base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
            PasswordValidator = new MinimumLengthValidator (10);
        }
    }
}