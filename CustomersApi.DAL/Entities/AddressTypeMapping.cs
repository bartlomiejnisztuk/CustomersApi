using System.ComponentModel.DataAnnotations.Schema;

namespace CustomersApi.DAL.Entities
{
    public class AddressTypeMapping
    {
        public string AddressName { get; set; }

        [Column(TypeName = "varchar(1)")]
        public char AddressType { get; set; }
    }
}
