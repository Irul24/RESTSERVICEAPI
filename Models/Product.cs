using System.ComponentModel.DataAnnotations.Schema;

namespace RESTSERVICEAPI.Models
{
    //[Table("Product")]
    public class produk
    {
        public int? id { get; set; }
        public string? nama { get; set; }
        public string? deskripsi { get; set; }
        public int harga { get; set; }
        public int stok { get; set; }

    }
}
