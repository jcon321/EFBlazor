namespace LibraryBlazorCRUD2.Models
{
    public class Patron
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime? Birthdate { get; set; }
        public List<Book> Books { get; set; }
    }
}
