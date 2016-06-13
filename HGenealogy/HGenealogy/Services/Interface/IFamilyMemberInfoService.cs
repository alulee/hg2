using HGenealogy.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HGenealogy.Services.Interface
{
    public interface IFamilyMemberInfoService
    {
        IQueryable<FamilyMemberInfo> GetAll();
        FamilyMemberInfo GetById(int id);
        void Insert(FamilyMemberInfo entity);
        void Update(FamilyMemberInfo entity);
        void Delete(FamilyMemberInfo entity);
    }
}