/* Author: Cameron Block
 * Class: CIS 434 ASP.NET
 * Final Project
 * Purpose: To create an online APA citation generator. 
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel;

namespace OnlineCitationGenerator {

    [DataObject(true)]
    public static class BookDB {
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Book> GetBookReferences() {
            List<Book> books = new List<Book>();

            SqlConnection bookCon = new SqlConnection(GetConnectionString());
            string bookSelect = "SELECT * FROM Book";
            SqlCommand bookCmd = new SqlCommand(bookSelect, bookCon);
            bookCon.Open();
            SqlDataReader bookDr = bookCmd.ExecuteReader(CommandBehavior.CloseConnection);

            Book book;
            
            //read data from the book table
            while (bookDr.Read()) {
                book = new Book();

                book.refID = (int)bookDr["refID"];

                book.PaperID = (int)bookDr["PaperID"];

                try{
                    book.edition = (int)bookDr["edition"];
                }
                catch (InvalidCastException) {
                    book.edition = 0;
                }

                try {
                    book.volume = (int)bookDr["volume"];
                }
                catch (InvalidCastException) {
                    book.volume = 0;
                }

                //book.anonymous = (bool)bookDr["anonymous"];
                //book.corporateAuthor = (bool)bookDr["corporateAuthor"];
                try {
                    book.translation = (bool)bookDr["translation"];
                }
                catch (InvalidCastException) {
                    book.translation = false;
                }

                book.publicationDate = (DateTime)bookDr["publicationDate"];

                book.title = bookDr["title"].ToString().Trim();
                book.subtitle = bookDr["subtitle"].ToString().Trim();
                book.city = bookDr["city"].ToString().Trim();
                book.state = bookDr["state"].ToString().Trim();
                book.publisher = bookDr["publisher"].ToString().Trim();
                book.URL = bookDr["URL"].ToString().Trim();
                book.DOI = bookDr["DOI"].ToString().Trim();

                GetAuthors(book);
                GetEditors(book);

                books.Add(book);
            }
            bookDr.Close();

            books.Sort();
            return books;
        }//end method

        private static void GetAuthors(Book book) {
            //read all data from Author table
            SqlConnection authorCon = new SqlConnection(GetConnectionString());
            string authorSelect = "SELECT * FROM Author WHERE refID = @refID";
            SqlCommand authorCmd = new SqlCommand(authorSelect, authorCon);
            authorCmd.Parameters.AddWithValue("refID", book.refID);
            authorCon.Open();
            SqlDataReader authorDr = authorCmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<Author> authors = new List<Author>();

            Author author;
            while (authorDr.Read()) {
                author = new Author();

                author.refID = (int)authorDr["refID"];
                author.authorID = (int)authorDr["authorID"];
                author.fname = authorDr["fname"].ToString().Trim();
                author.mname = authorDr["mname"].ToString().Trim();
                author.lname = authorDr["lname"].ToString().Trim();
                author.suffix = authorDr["suffix"].ToString().Trim();

                authors.Add(author);
            }

            authorDr.Close();
            authors.Sort();
            book.authors = authors;
        }//end method

        private static void GetEditors(Book book) {
            //read all data from editors table
            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT * FROM Editor WHERE refID = @refID";
            SqlCommand cmd = new SqlCommand(sel, con);
            cmd.Parameters.AddWithValue("refID", book.refID);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            List<Editor> editors = new List<Editor>();

            Editor editor;
            while (dr.Read()) {
                editor = new Editor();

                editor.refID = (int)dr["refID"];
                editor.editorID = (int)dr["editorID"];
                editor.fname = dr["fname"].ToString().Trim();
                editor.mname = dr["mname"].ToString().Trim();
                editor.lname = dr["lname"].ToString().Trim();
                editor.suffix = dr["suffix"].ToString().Trim();

                editors.Add(editor);
            }

            dr.Close();
            editors.Sort();
            book.editors = editors;
        }//end method

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateBookReferences(Book original_Book, Book book) {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string up = "UPDATE Book "
            + "SET edition = @edition, "
            + "volume = @volume, "
            + "anonymous = @anonymous, "
            + "corporateAuthor = @corporateAuthor, "
            + "translation = @translation, "
            + "publicationDate = @publicationDate, "
            + "title = @title, "
            + "subtitle = @subtitle, "
            + "city = @city, "
            + "state = @state, "
            + "publisher = @publisher, "
            + "URL = @URL, "
            + "DOI = @DOI "
            + "WHERE refID = @original_refID";
            
            SqlCommand cmd = new SqlCommand(up, con);
            cmd.Parameters.AddWithValue("edition", book.edition);
            cmd.Parameters.AddWithValue("volume", book.volume);
            //cmd.Parameters.AddWithValue("anonymous", book.anonymous);
            //cmd.Parameters.AddWithValue("corporateAuthor", book.corporateAuthor);
            cmd.Parameters.AddWithValue("translation", book.translation);
            cmd.Parameters.AddWithValue("publicationDate", book.publicationDate);
            cmd.Parameters.AddWithValue("title", book.title);
            cmd.Parameters.AddWithValue("subtitle", book.subtitle);
            cmd.Parameters.AddWithValue("city", book.city);
            cmd.Parameters.AddWithValue("state", book.state);
            cmd.Parameters.AddWithValue("publisher", book.publisher);
            cmd.Parameters.AddWithValue("URL", book.URL);
            cmd.Parameters.AddWithValue("DOI", book.DOI);
            cmd.Parameters.AddWithValue("original_refID", original_Book.refID);

            for (int i = 0; i < book.authors.Count; i++)
                UpdateAuthors(original_Book.authors[i], book.authors[i]);

                con.Open();
            return cmd.ExecuteNonQuery();//return update count
        }//end method

        public static int UpdateAuthors(Author original_Author, Author author) {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string up = "UPDATE Author "
            + "SET fname = @fname, "
            + "lname = @lname, "
            + "mname = @mname, "
            + "suffix = @suffix, "
            + "WHERE refID = @original_refID AND authorID = @original_authorID";


            SqlCommand cmd = new SqlCommand(up, con);
            cmd.Parameters.AddWithValue("fname", author.fname);
            cmd.Parameters.AddWithValue("lname", author.lname);
            cmd.Parameters.AddWithValue("mname", author.mname);
            cmd.Parameters.AddWithValue("suffix", author.suffix);
            cmd.Parameters.AddWithValue("original_refID", original_Author.refID);
            cmd.Parameters.AddWithValue("original_authorID", original_Author.authorID);

            con.Open();
            return cmd.ExecuteNonQuery();//return update count
        }
        //public int refID { get; set; }
        //public int edition { get; set; }
        //public int volume { get; set; }

        //public bool anonymous { get; set; }
        //public bool corporateAuthor { get; set; }
        //public bool translation { get; set; }

        //public DateTime publicationDate { get; set; }

        //public string title { get; set; }
        //public string subtitle { get; set; }
        //public string city { get; set; }
        //public string state { get; set; }
        //public string publisher { get; set; }
        //public string URL { get; set; }
        //public string DOI { get; set; }

        public static string GetConnectionString() {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }//end method
    }//end class

}//end namespace