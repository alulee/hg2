using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HGenealogy.Data;
using HGenealogy.Data.Repository;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace HGenealogy.Services.Interface
{
    public interface IFamilyMemberService
    {
        IQueryable<FamilyMember> GetAll();
        FamilyMember GetById(int id);
        void Insert(FamilyMember entity);
        void Update(FamilyMember entity);
        List<FamilyMember> GetList(Expression<Func<FamilyMember, bool>> filter);
        List<SelectListItem> GetFamilyMembersSelectList(int pedigreeId);
    }
}