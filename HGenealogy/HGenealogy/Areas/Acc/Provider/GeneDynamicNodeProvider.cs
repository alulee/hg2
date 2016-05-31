using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HGenealogy.Services;
using HGenealogy.Services.Acc;
using HGenealogy.Models;
using HGenealogy.Data;
using MvcSiteMapProvider;

namespace HGenealogy.Areas.Acc.Provider
{
    public class GeneDynamicNodeProvider : DynamicNodeProviderBase
    {
        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode nodes)
        {
            var returnValue = new List<DynamicNode>();

            using (hDatabaseEntities db = new hDatabaseEntities())
            {
                // 取出此用戶角色關聯的所有Menu項
                var loginUserId = "admin";
                var roleMenus = MenuService.GetMenusByRoleID(loginUserId);

                foreach (var menu in roleMenus)
                {
                    DynamicNode node = new DynamicNode()
                    {
                        // 顯示的文字
                        Title = menu.Name,
                        // 父Menu項目Id
                        ParentKey = menu.ParentId.HasValue ? menu.ParentId.Value.ToString() : "",
                        // Node Key
                        Key = menu.MenuId.ToString(),
                        // Action Name
                        Action = menu.Action,
                        // Controller Name
                        Controller = menu.Controller,
                        // Url (只要有值就會以此為主)
                        Url = menu.Url
                    };

                    if (!string.IsNullOrWhiteSpace(menu.RouteValues))
                    {
                        // 此部分利用menu.RouteValues欄位文字轉乘key-value pair
                        // 當作RouteValues使用
                        // ex. Key1=value1,Key2=value2...
                        node.RouteValues = menu.RouteValues.Split(',').Select(value => value.Split('='))
                                                .ToDictionary(pair => pair[0], pair => (object)pair[1]);
                    }

                    returnValue.Add(node);
                }
            }

            return returnValue;
        }
    }
}