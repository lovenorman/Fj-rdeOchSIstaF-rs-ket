namespace FjärdeOchSIstaFörsöket.Models
{
    public partial class Book
    {
        
        public int Id { get; set; }

        public string Title { get; set; }

        public Author? Author { get; set; }

        public BookCategory Category { get; set; }

        public _covertype CoverType { get; set; }

        public int AmountOfPages { get; set; }
    }
}
