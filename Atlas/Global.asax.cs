﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Atlas.Infrastructure.EF;
using Atlas.Migrations;
using Castle.Windsor;

namespace Atlas
{
    // Nota: para obtener instrucciones sobre cómo habilitar el modo clásico de IIS6 o IIS7, 
    // visite http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication
    {
        private static IWindsorContainer container;

        public IWindsorContainer Container { get { return container; } }

        protected void Application_Start()
        {
            container = Bootstrapper.InitializeContainer();

            //Database.SetInitializer(new AtlasContextCustomInitializer());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<AtlasContext, Configuration>());

            AreaRegistration.RegisterAllAreas();
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

          
        }

        protected void Application_Stop()
        {
            Bootstrapper.Release(container);
        }
    }
}