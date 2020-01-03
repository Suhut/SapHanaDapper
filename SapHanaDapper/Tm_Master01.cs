using Dapper.Contrib.IduExtensions;

namespace SapHanaDapper
{
    [Table("Tm_Master01")]
    public class Tm_Master01
    {
        [Key]
        public int Id { set; get; }

        public string Description { set; get; }
    } 
}
