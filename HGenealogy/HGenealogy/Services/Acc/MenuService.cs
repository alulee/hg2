using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Models;
using HGenealogy.Data;

namespace HGenealogy.Services.Acc
{
    public class MenuService
    {
        public static IList<Menu> GetMenusByRoleID(string roleID)
        {
            List<Menu> result = new List<Menu>();

            using (var db = new hDatabaseEntities())
            {
                if (!(string.IsNullOrEmpty(roleID) || roleID == ""))
                {
                    result = (from menus in db.Menus
                              select menus).OrderBy(x => x.OrderSerial).ToList<Menu>();

                }
            }
            return result;
        }

      }
}