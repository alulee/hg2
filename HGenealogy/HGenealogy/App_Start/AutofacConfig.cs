using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Integration.Mvc;
using System.Reflection;
using System.Web.Mvc;
using System.Configuration;
using HGenealogy.Data.DbContextFactory;
using HGenealogy.Data.Repository;
using HGenealogy.Services;
using HGenealogy.Services.Interface;
using HGenealogy.Services.Genealogy;
using HGenealogy.Core;
using HGenealogy.Fakes;

namespace HGenealogy.App_Start
{
    public class AutofacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            //DbContextFactory
            string connectionString = ConfigurationManager.ConnectionStrings["HGenealogyEntities"].ConnectionString;

            builder.RegisterType<DbContextFactory>()
                    .WithParameter("connectionString", connectionString)
                    .As<IDbContextFactory>()
                    .InstancePerRequest();

            //Repository
            //使用 RegisterGeneric() 註冊泛型類別
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IRepository<>));

            //Service
            //builder.RegisterAssemblyTypes(AppDomain.CurrentDomain.GetAssemblies())
            //       .Where(t => t.Name.EndsWith("Service"))
            //       .AsImplementedInterfaces()
            //       ;
            builder.RegisterType<PedigreeMetaService>().As<IPedigreeMetaService>().InstancePerLifetimeScope();
            builder.RegisterType<PedigreeInfoService>().As<IPedigreeInfoService>().InstancePerLifetimeScope();
            builder.RegisterType<FamilyService>().As<IFamilyService>().InstancePerLifetimeScope();
            builder.RegisterType<GeneMetaService>().As<IGeneMetaService>().InstancePerLifetimeScope();
            builder.RegisterType<FamilyMemberService>().As<IFamilyMemberService>().InstancePerLifetimeScope();
            builder.RegisterType<AddressService>().As<IAddressService>().InstancePerLifetimeScope();
            builder.RegisterType<WebHelper>().As<IWebHelper>().InstancePerLifetimeScope();

            //HTTP context and other related stuff
            builder.Register(c =>
                //register FakeHttpContext when HttpContext is not available
                HttpContext.Current != null ?
                (new HttpContextWrapper(HttpContext.Current) as HttpContextBase) :
                (new FakeHttpContext("~/") as HttpContextBase))
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Request)
                .As<HttpRequestBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Response)
                .As<HttpResponseBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Server)
                .As<HttpServerUtilityBase>()
                .InstancePerLifetimeScope();
            builder.Register(c => c.Resolve<HttpContextBase>().Session)
                .As<HttpSessionStateBase>()
                .InstancePerLifetimeScope();

            //builder.RegisterControllers(Assembly.GetExecutingAssembly());           //注冊MVC容器
            builder.RegisterControllers(typeof(MvcApplication).Assembly)
                //.InstancePerRequest();
            .InstancePerDependency();           //注冊MVC容器

            //builder.RegisterFilterProvider();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

       
        }
    }
}