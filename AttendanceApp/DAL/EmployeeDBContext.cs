using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using AttendanceApp.Models;

namespace AttendanceApp.DAL
{
	public class EmployeeDBContext:DbContext
	{

		public EmployeeDBContext() : base("DefaultConnection")
		{

		}

		public DbSet<Employee> Employee { get; set; }
		public DbSet<Attendance> Attendance { get; set; }


	}
}