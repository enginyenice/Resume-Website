using Entities.Interfaces;

namespace Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Certifications")]
    public class Certification : ITable
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}