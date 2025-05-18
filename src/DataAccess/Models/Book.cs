namespace cloudBackend.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Cover { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}