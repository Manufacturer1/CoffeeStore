using CoffeeStore.BuiesnessLogic.Interfaces;
using CoffeeStore.BuiesnessLogic.Services;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoffeeStore.Util
{
    public class EditModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEditProductService>().To<EditProductService>();
        }
    }
}