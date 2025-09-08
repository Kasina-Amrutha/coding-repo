using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using static ConsoleApp.Models.MyModelClasses;


namespace ConsoleApp.Models
{
    class CRUD
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["MyConnection"].ToString());
        public List<Book> GetBooks()
        {
            List<Book> bookList = new List<Book>();
            SqlCommand cmd = new SqlCommand("Select * from book", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow drow in dt.Rows)
            {
                Book b = new Book()
                {
                    Id = int.Parse(drow["Id"].ToString()),
                    AuthorId = int.Parse(drow["AuthorId"].ToString()),
                    Description = drow["Description"].ToString(),
                    Type = drow["Type"].ToString()
                };
                bookList.Add(b);
            }
            return bookList;
        }
    }
}
