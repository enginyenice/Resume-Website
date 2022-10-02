using DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.DTOs.LogDtos
{
	public class LogListDto : IDto
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public string Org { get; set; }
        public DateTime Date { get; set; }
    }
}
