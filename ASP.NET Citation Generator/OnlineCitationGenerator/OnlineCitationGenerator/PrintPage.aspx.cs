
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Text;
using System.Web.UI.WebControls;

using System.Configuration;
using System.Data.Linq;


namespace OnlineCitationGenerator {
    public partial class PrintPage : System.Web.UI.Page {
        protected void Page_Load(object sender, EventArgs e) {
            List<Book> books = BookDB.GetBookReferences();
            StringBuilder str = new StringBuilder();
            int PaperID = Int32.Parse(Session["PaperID"].ToString());

            //sort the list
            books.Sort();

            //remove books that do not match the PaperID
            for (int i = 0; i < books.Count; i++)
                if (PaperID != books[i].PaperID) {
                    books.RemoveAt(i);
                }

            //set the sequence variable
            int ch = Convert.ToInt32('a');
            int start1 = 0;
            int start2 = 0;
            for (int i = 0; i < books.Count; i++) {
                Book previousBook;
                Book ctBook;
                Book nextBook;
                start1 = start2;

                //compare current to next
                try {
                    ctBook = books[i];
                    nextBook = books[i + 1];
                    if (ctBook.CompareLname(nextBook) == 0) {
                        ch += i - start1;
                        ctBook.sequence = Convert.ToChar(ch);
                    }
                    else {
                        start2 = i + 1;
                        ch = Convert.ToInt32('a');
                    }
                }
                catch (ArgumentOutOfRangeException) { }

                //compare current to previous
                try {
                    previousBook = books[i - 1];
                    ctBook = books[i];
                    if (ctBook.CompareLname(previousBook) == 0) {
                        ch += i - start1;
                        ctBook.sequence = Convert.ToChar(ch);
                    }
                }
                catch (ArgumentOutOfRangeException) { }
            }

            for (int i = 0 ; i < books.Count ; i++ )
                str.Append(books[i].ToString() + "</br>");

                /*Am trying to get this working right. 
                .hangingindent {
                padding-left: 22px ;
                text-indent: -22px ;
                }*/
            Page.Controls.Add(new LiteralControl("<span style='color: black; font-family:\"Calibri\" font-size: 11px; line-height: 2em; '><p>" + str.ToString() + "</p></span>"));
        }//end method

        //public List<Book> GetBookReferences(int PaperID) {

        //    List<Book> retList = new List<Book>();//return list
        //     DataContext takes a connection string. 
        //    DataContext db = new DataContext(GetConnectionString());

        //     //Get a typed table to run queries.
        //    Table<Book> Books = db.GetTable<Book>();

        //     //Query for books
        //    var selBooks =
        //        from book in Books
        //        where book.PaperID == PaperID
        //        select book;

        //     //Query for Authors
        //    var selAuthors =
        //        from book in Books
        //        where book.PaperID == PaperID
        //        select book;

        //    foreach (var book in selBooks)
        //        foreach()
        //        retList.Add(book);

        //    return retList;
        //}//end method

        //public static string GetConnectionString() {
        //    return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //}//end method
    }
}