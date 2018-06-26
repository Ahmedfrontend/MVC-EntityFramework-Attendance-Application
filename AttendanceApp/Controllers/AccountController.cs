using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AttendanceApp.DAL;
using AttendanceApp.Models;
using Newtonsoft.Json;
namespace AttendanceApp.Controllers
{
    public class AccountController : Controller
    {
		private EmployeeDBContext db = new EmployeeDBContext();
		// GET: Account
		public ActionResult Login(string returnUrl)
		{

			string AdminEmail = ConfigurationManager.AppSettings["AdminEmail"].ToString();
			string Password = ConfigurationManager.AppSettings["Password"].ToString();


			var user = db.Employee.Where(s => s.Email == AdminEmail);
			if (user.Count() == 0)
			{

				Employee Employee = new Employee {FirstName = "admin" , LastName = "admin",BirthDate= Convert.ToDateTime("12/9/1985"),salary=0, Email = AdminEmail, Password = Password, ConfirmPassword = Password, UserRoles = "Admin" };
				db.Employee.Add(Employee);
				db.SaveChanges();
			}




			return View();
		}


		[HttpPost]
		public ActionResult Login(LoginViewModel model, string returnUrl)
		{
			// Lets first check if the Model is valid or not
			if (ModelState.IsValid)
			{

				string Email = model.Email;
				string Password = model.Password;

				// Now if our password was enctypted or hashed we would have done the
				// same operation on the user entered password here, But for now
				// since the password is in plain text lets just authenticate directly

				bool userValid = db.Employee.Any(user => user.Email == Email && user.Password == Password);
				IEnumerable emp = db.Employee.Where(obj => obj.Email == Email);
				var result = db.Employee
				   .SingleOrDefault(c => c.Email == Email);
				var tiket = JsonConvert.SerializeObject(result);



				// User found in the database
				if (userValid)
				{

					FormsAuthentication.SetAuthCookie(tiket, false);
					if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
						&& !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
					{
						return Redirect(returnUrl);
					}
					else
					{
						return RedirectToAction("Index", "Home");
					}
				}
				else
				{
					ModelState.AddModelError("", "The user name or password provided is incorrect.");
				}

			}

			// If we got this far, something failed, redisplay form
			return View(model);
		}



		public ActionResult LogOff()
		{
			FormsAuthentication.SignOut();
			return RedirectToAction("Index", "Home");
		}


		public ActionResult Register(int id)
		{
			return View();
		}





	}
}
