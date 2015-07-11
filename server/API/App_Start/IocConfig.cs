using System.Web.Http;
using DataAccess;
using Ninject;

namespace Master.API.App_Start
{
   public class IocConfig
   {
      public static void RegisterIoc(HttpConfiguration config)
      {
         var kernel = new StandardKernel();

         
         config.DependencyResolver = new NinjectDependencyResolver(kernel);
      }
   }
}