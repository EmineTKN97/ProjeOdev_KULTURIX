using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.İnterceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstarct;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
  public  class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<BlogManager>().As<IBlogService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().InstancePerLifetimeScope();
            builder.RegisterType<BlogCommentManager>().As<IBlogCommentService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBlogCommentDal>().As<IBlogCommentDal>().InstancePerLifetimeScope();
            builder.RegisterType<BlogLikeManager>().As<IBlogLikeService>().InstancePerLifetimeScope();
            builder.RegisterType<EfBlogLikeDal>().As<IBlogLikeDal>().InstancePerLifetimeScope();
            builder.RegisterType<MediaManager>().As<IMediaService>().InstancePerLifetimeScope();
            builder.RegisterType<EfMediaDal>().As<IMediaDal>().InstancePerLifetimeScope();
            builder.RegisterType<AnnouncementManager>().As<IAnnouncementService>().InstancePerLifetimeScope();
            builder.RegisterType<EfAnnouncementDal>().As<IAnnouncementDal>().InstancePerLifetimeScope();
            builder.RegisterType<UserManager>().As<IUserService>().InstancePerLifetimeScope();
            builder.RegisterType<EfUserDal>().As<IUserDal>().InstancePerLifetimeScope();
            builder.RegisterType<AdminManager>().As<IAdminService>().InstancePerLifetimeScope();
            builder.RegisterType<EfAdminDal>().As<IAdminDal>().InstancePerLifetimeScope();
            builder.RegisterType<AuthManager>().As<IAuthService>().InstancePerLifetimeScope();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<ProjeOdevContext>().InstancePerLifetimeScope();
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
