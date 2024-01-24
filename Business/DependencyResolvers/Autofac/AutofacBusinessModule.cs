using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.Context;
using DataAccess.Concrete.EntityFramework;
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

            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().SingleInstance();
            builder.RegisterType<BlogCommentManager>().As<IBlogCommentService>().SingleInstance();
            builder.RegisterType<EfBlogCommentDal>().As<IBlogCommentDal>().SingleInstance();
            builder.RegisterType<BlogLikeManager>().As<IBlogLikeService>().SingleInstance();
            builder.RegisterType<EfBlogLikeDal>().As<IBlogLikeDal>().SingleInstance();
            builder.RegisterType<ProjeOdevContext>().InstancePerLifetimeScope();
        }
    }
}
