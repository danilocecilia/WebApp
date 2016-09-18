namespace WebApp
{
    using System;
    using System.Web;
    using System.Web.Optimization;

    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            BundleTable.Bundles
                .Add(new ScriptBundle("~/scripts")
                        .Include(
                            "~/scripts/angular.js",
                            "~/scripts/angular-route.js",
                            "~/App/*.js",
                            "~/App/admin/routes.js",
                            "~/App/root/routes.js",
                            "~/App/admin/controllers/*.js",
                            "~/App/root/controllers/*.js"));
        }
    }
}