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
    public static class AuthorDB {
        
        [DataObjectMethod(DataObjectMethodType.Select)]
        public static List<Author> GetAuthors() {
            List<Author> authors = new List<Author>();

            SqlConnection con = new SqlConnection(GetConnectionString());
            string sel = "SELECT * FROM Author";
            SqlCommand cmd = new SqlCommand(sel, con);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

            Author author;
            while (dr.Read()) {
                author = new Author();

                author.refID = (int)dr["refID"];
                author.authorID = (int)dr["authorID"];

                author.fname = dr["fname"].ToString().Trim();
                author.mname = dr["mname"].ToString().Trim();
                author.lname = dr["lname"].ToString().Trim();
                author.suffix = dr["suffix"].ToString().Trim();

                authors.Add(author);
            }

            dr.Close();
            return authors;
        }//end method

        [DataObjectMethod(DataObjectMethodType.Update)]
        public static int UpdateAuthors(Author original_Author, Author author) {
            SqlConnection con = new SqlConnection(GetConnectionString());
            string up = "UPDATE Author "
            + "SET fname = @fname, "
            + "mname = @mname, "
            + "lname = @lname, "
            + "suffix = @suffix, "
            + "WHERE refID = @original_refID AND authorID = @original_authorID";

            SqlCommand cmd = new SqlCommand(up, con);
            cmd.Parameters.AddWithValue("fname", author.fname);
            cmd.Parameters.AddWithValue("mname", author.mname);
            cmd.Parameters.AddWithValue("lname", author.lname);
            cmd.Parameters.AddWithValue("suffix", author.suffix);
            cmd.Parameters.AddWithValue("original_refID", original_Author.refID);
            cmd.Parameters.AddWithValue("original_authorID", original_Author.authorID);

            con.Open();
            return cmd.ExecuteNonQuery();//return update count
        }

        public static string GetConnectionString() {
            return ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        }//end method
    }//end class
}//end namespace