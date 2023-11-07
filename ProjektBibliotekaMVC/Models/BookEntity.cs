namespace BibliotekaMVC.Entities
{
    public class BookEntity
    {
        public int Id { get; set; }
        public int IdAuthor { get; set; }
        public int IdCathegory { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public string Status { get; set; }
    }
}
