﻿using System.Web.Http.Dependencies;
using Ninject;

namespace Master.API.App_Start
{
   public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver
   {
      private IKernel kernel;

      public NinjectDependencyResolver(IKernel kernel)
         : base(kernel)
      {
         this.kernel = kernel;
      }

      public IDependencyScope BeginScope()
      {
         return new NinjectDependencyScope(kernel.BeginBlock());
      }
   }
}
