
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
namespace KitaplikProje.Models
{
    public class Product
    {
        [Key]
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string BookWrites { get; set; }
        public string BookPublishHouse { get; set; }
        public int BookPublishYear { get; set; }
        public string  BookImageURL { get; set; }
        public string BookSummary { get; set; }
        public int BookStock { get; set; }
        public int CategoryID { get; set; }
        public virtual Category Category { get; set; }  



    }
}
