using System.ComponentModel;

namespace FjärdeOchSIstaFörsöket.Models
{
    public partial class Book
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public Author? Author { get; set; }

        public BookCategory Category { get; set; }
        [DisplayName("Cover")]
        public _covertype CoverType { get; set; }
        [DisplayName ("Pages")]
        public int AmountOfPages { get; set; }
    }
}
