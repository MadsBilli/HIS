using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Threading;
using System.Globalization;
using HIS;

namespace HIS
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Code that runs on application startup
            BundleConfig.RegisterBundles(BundleTable.Bundles); 
        }
        void Application_BeginRequest(object sender, EventArgs e)
        {
            //Create Number Format info for UI Culture
            NumberFormatInfo nfi = new NumberFormatInfo();
            nfi.NumberGroupSeparator = string.Empty;

            //Create Culture Info for UI
            CultureInfo ci = new CultureInfo("en-US");
            ci.NumberFormat = nfi;

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
        }
        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            // Code that runs when an unhandled error occurs

        }
    }
}
