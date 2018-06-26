using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using AttendanceApp.DAL;
using AttendanceApp.Models;
using Newtonsoft.Json;



namespace AttendanceApp
{
	public class MvcApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);
		}


		protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
		{
			if (FormsAuthentication.CookiesSupported == true)
			{
				if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
				{
					try
					{
						//let us take out the username now                
						string Email = FormsAuthentication.Decrypt(Request.Cookies[FormsAuthentication.FormsCookieName].Value).Name;
						string roles = string.Empty;
						
					
						Employee Loginemployee = JsonConvert.DeserializeObject<Employee>(Email);
						roles = Loginemployee.UserRoles;
						//let us extract the roles from our own custom cookie
						//Let us set the Pricipal with our user specific details
						e.User = new System.Security.Principal.GenericPrincipal(
						new System.Security.Principal.GenericIdentity(Email, "Forms"), roles.Split(';'));
					}
					catch (Exception)
					{
						//somehting went wrong
					}
				}
			}
		}

	}
}
