/* Author: Cameron Block
 * Class: CIS 434 ASP.NET
 * Final Project
 * Purpose: To create an online APA citation generator. 
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Data.Linq.Mapping;


namespace OnlineCitationGenerator {

    [Table( Name = "Book")]
    public class Book : IComparable {

        public List<Author> authors = new List<Author>();
        public List<Editor> editors = new List<Editor>();

        [Column(IsPrimaryKey = true, IsDbGenerated = true)]
        public int refID { get; set; }

        [Column]
        public int edition { get; set; }
        [Column]
        public int volume { get; set; }

        //public bool anonymous { get; set; }
        //public bool corporateAuthor { get; set; }
        [Column]
        public bool translation { get; set; }

        public DateTime publicationDate { get; set; }

        [Column]
        public string title { get; set; }
        [Column]
        public string subtitle { get; set; }
        [Column]
        public string city { get; set; }
        [Column]
        public string state { get; set; }
        [Column]
        public string publisher { get; set; }
        [Column]
        public string URL { get; set; }
        [Column]
        public string DOI { get; set; }
        [Column]
        public int PaperID { get; set; }

        public char sequence{ get; set; }//used in the references list for consecutive authors

        public int CompareLname(object obj) {
            if (obj == null) return 1;

            Book other = obj as Book;

            if (other != null) {
                //compare
                List<Person> list1 = authors.Cast<Person>().ToList();
                List<Person> list2 = other.authors.Cast<Person>().ToList();

                //if either of the author lists is null, compare to the editors
                if (list1.Count == 0) { list1 = editors.Cast<Person>().ToList(); }
                if (list2.Count == 0) { list2 = editors.Cast<Person>().ToList(); }

                //if either of the editor lists is null, compare to the ""
                String str1;
                String str2;
                if (list1.Count == 0) { str1 = ""; }
                else { str1 = list1[0].lname; }
                if (list2.Count == 0) { str2 = ""; }
                else { str2 = list2[0].lname; }

                return str1.CompareTo(str2);
            }
            else
                throw new ArgumentException("Object is not a book. ");
        }//end method

        public int CompareTo(object obj) {
            if (obj == null) return 1;

            Book other = obj as Book;
            if (other != null) {
                //comparison goes here
                List<Person> list1 = authors.Cast<Person>().ToList();
                List<Person> list2 = other.authors.Cast<Person>().ToList();

                //if either of the author lists is null, compare to the editors
                if (list1.Count == 0) { list1 = editors.Cast<Person>().ToList(); }
                if (list2.Count == 0) { list2 = editors.Cast<Person>().ToList(); }

                //if (list1.Count == 0) { list1.Add(new Author() {fname = "", mname = "", lname = "Anonymous" }); }
                //if (list2.Count == 0) { list2.Add(new Author() { fname = "", mname = "", lname = "Anonymous" }); }

                int compareAuthor = 0;
                if (list1.Count > 0 && list2.Count > 0) {
                    compareAuthor = list1[0].CompareTo(list2[0]);//Author lname can be "Anonymous"
                }
                else if (list1.Count == 0) {
                    //change processing depending on whether there is an author or editors
                    if(list2.Count > 0)
                        compareAuthor = this.title.CompareTo(list2[0].lname);
                    else
                        compareAuthor = this.title.CompareTo("");
                }
                else if (list2.Count == 0) { compareAuthor = list1[0].lname.CompareTo(other.title); }
                else
                    compareAuthor = this.title.CompareTo(other.title);

                int compareYear = this.publicationDate.Year.CompareTo(other.publicationDate.Year);
                int compareTitle = this.title.CompareTo(other.title);

                if (compareAuthor == 0) {
                    if (compareYear == 0) {
                        return compareTitle;
                    }
                    else
                        return compareYear;
                }
                else
                    return compareAuthor;
            }
            else
                throw new ArgumentException("Object is not a book. ");
        }//end method

        public override string ToString() {
            StringBuilder str = new StringBuilder();

            int i = 0;
            if (authors.Count != 0) {
                //list the authors
                for (; i < 6 && authors.Count > i; i++)
                    str.Append(authors[i].ToString() + " ");

                if (i == 6 && authors.Count > 6)
                    str.Append(" ... ");
            }
            else if (editors.Count != 0) {
                //editors
                i = 0;
                for (; i < 6 && editors.Count > i; i++)
                    str.Append(editors[i].ToString() + " ");

                if (i == 6 && editors.Count > 6)
                    str.Append(" ... ");

                if (editors.Count > 1)
                    str.Append("(Eds.). ");
                else if (editors.Count == 1)
                    str.Append("(Ed.). ");
            }
            //year of publication
            if(authors.Count > 0 || editors.Count > 0 && publicationDate != null)
                str.Append("(" + publicationDate.Year + sequence + ") ");
            str.Append(title + " ");
            
            //subtitle
            if (subtitle != "")
                str.Append(": " + subtitle);

            //volume number
            if (volume != 0)
                str.Append(", " + volume);

            //edition
            String[] ordinal = new String[] { "st", "nd", "rd", "th" };
            if (edition != 0) {
                //determine which ordinal to use. 
                int j;
                for (j = 0; j < ordinal.Length - 1 && j < edition - 1; j++) ;

                str.Append("(" + this.edition + ordinal[j] + " ed.)");
            }

            //period follows the title and subtitle
            str.Append(". ");

            //publication date
            if (authors.Count == 0 && editors.Count == 0 && publicationDate != null)
                str.Append(" (" + publicationDate.Year + ") ");

            if (authors != null) {
                //editors
                i = 0;

                for (; i < 6 && editors.Count > i; i++)
                    str.Append(editors[i].ToString() + " ");

                if (i == 6 && editors.Count > 6)
                    str.Append(" ... ");

                if (editors.Count > 1)
                    str.Append("(Eds.). ");
                else if (editors.Count == 1)
                    str.Append("(Ed.). ");
            }

            if(city != "")
                str.Append(city);
            if (city != "" && state != "")
                str.Append(", ");
            if (state != "")
                str.Append(state);

            str.Append(": ");

            str.Append(publisher + ". ");

            return str.ToString();
        }//end method

        private static String getBookLname(Book book) {
            String str1 = "";
            if (book.authors.Count > 0) { str1 = book.authors[0].lname; }
            else if (book.editors.Count > 0) { str1 = book.editors[0].lname; }
            return str1;
        }

    }//end class
}//end namespace