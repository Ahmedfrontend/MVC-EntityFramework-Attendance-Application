using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace AttendanceApp.Models
{
	public class Attendance
	{
		public int ID { get; set; }

		public DateTime ComingTime { get; set; }


		[DisplayName("Date")]
		public DateTime DateOfDay { get; set; }

		public DateTime? LeaveTime { get; set; }

		public int EmployeeID { get; set; }

		//public virtual Employee employee { get; set; }

	}
}