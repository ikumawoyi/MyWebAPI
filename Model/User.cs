﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI.Models
{
	public partial class User
	{
		public int UserId { get; set; }
		public string Username { get; set; }
		public string Password { get; set; }
		public string Role { get; set; }
		public int PrivateId { get; set; }
	}
}
