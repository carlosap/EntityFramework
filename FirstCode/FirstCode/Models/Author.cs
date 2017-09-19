using System.Collections.Generic;
namespace FirstCode.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string MailId { get; set; }

        public ICollection<Book> Books { get; set; }

    }
}
