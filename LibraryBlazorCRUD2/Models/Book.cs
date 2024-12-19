namespace LibraryBlazorCRUD2.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PatronId { get; set; }
        public Patron Patron { get; set; }
    }
}
