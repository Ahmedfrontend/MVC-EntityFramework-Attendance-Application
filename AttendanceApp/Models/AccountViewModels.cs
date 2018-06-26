using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
	public class LoginViewModel
	{
		[Required]
		[Display(Name = "Email")]

		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		[Display(Name = "Password")]
		public string Password { get; set; }

	}

	public class AttendanceViewModel
	{
		public bool iscoming { get; set; }
		public bool isLeave { get; set; }
	}



	}