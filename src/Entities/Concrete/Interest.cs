using Entities.Interfaces;

namespace Entities.Concrete
{
    [Dapper.Contrib.Extensions.Table("Interests")]
    public class Interest: ITable
    {
        [Dapper.Contrib.Extensions.Key]
        public int Id { get; set; }
        public string Description { get; set; }
    }
}