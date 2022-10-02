using Dapper.Contrib.Extensions;
using Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
	[Table("Logs")]
	public class Log : ITable
	{
		[Key]
		public int Id { get; set; }
		public string Ip { get; set; }
		public string Region { get; set; }
		public string City { get; set; }
		public string Org { get; set; }
		public DateTime Date { get; set; }
	}
}
