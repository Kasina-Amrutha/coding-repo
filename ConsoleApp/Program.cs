using ConsoleApp.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleApp.Models.MyModelClasses;

namespace ConsoleApp.Models
{
    class Program
    {
        static void Main(string[] args)
        {
            CRUD c = new CRUD();
            List<Book> bookList= c.GetBooks();
            foreach (Book b in bookList)
            {
                Console.WriteLine($" ID: {b.Id} | AuthorID: {b.AuthorId} | Type: {b.Type} | Description: {b.Description} ");
            }
        }
    }
}
