namespace ProjektSklep.Dtos
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateBookDto
    {
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
    }
}
