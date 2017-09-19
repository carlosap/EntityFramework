using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstCode.Models;
using FirstCode.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace FirstCode.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext _contex;

        public HomeController(LibraryContext context)
        {
            _contex = context;
        }

        public string Index()
        {
            _contex.Database.EnsureCreated();
            return "DB Created";
        } 
        public string CreateAuthor(Author author)
        {
            try
            {
                if(author.Name != null && author.MailId != null)
                {
                    _contex.Add(author);
                    _contex.SaveChanges();
                    return "Author details Added successfully";

                }
                else
                {
                    return "missing some properties";
                }
                    
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public string CreateBook(Book book)
        {
            try
            {
                if(book.Title != null && book.Price != 0 && book.Description != null && book.AuthorId != 0)
                {
                    _contex.Book.Add(book);
                    _contex.SaveChanges();
                    return "Book details added";
                } 
                else
                {
                    return "Missing Some Properties";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public string ReadBook()
        {
            var books = _contex.Book.Include("Author").AsNoTracking();
            StringBuilder sb = new StringBuilder();
            if(books == null)
            {
                return "not found";

            }
            else
            {
                foreach (var book in books)
                {
                    sb.Append($"Book Id: {book.Id}");
                    sb.Append($"Title: {book.Title}");
                    sb.Append($"Description Id: {book.Description}");
                    sb.Append($"Price: {book.Price}");
                    sb.Append($"Author Id: {book.Author.AuthorId}");
                    sb.Append($"Author Name: {book.Author.Name}");
                    sb.Append($"Authoer Mail Id: {book.Author.MailId}");
                }
                return sb.ToString();
            }
        }

        public string BookDetails(int? bookId)
        {
            if(bookId == null)
            {
                return "Enter book id";
            }

            var result = _contex.Book.Include("Author").AsNoTracking().SingleOrDefaultAsync(b => b.Id == bookId);
            StringBuilder sb = new StringBuilder();
            var book = result.Result;
            if (book == null)
                return "not found";
            else
            {
                sb.Append($"Book Id: {book.Id}");
                sb.Append($"Title: {book.Title}");
                sb.Append($"Description Id: {book.Description}");
                sb.Append($"Price: {book.Price}");
                sb.Append($"Author Id: {book.Author.AuthorId}");
                sb.Append($"Author Name: {book.Author.Name}");
                sb.Append($"Authoer Mail Id: {book.Author.MailId}");
                return sb.ToString();
            }
        }
    }
}
