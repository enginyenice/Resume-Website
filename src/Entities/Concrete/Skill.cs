using System;
using System.Collections.Generic;
using System.Text;
using Entities.Interfaces;

namespace Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Skills")]
    public class Skill : ITable
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}
