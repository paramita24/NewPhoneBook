using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PhoneBook.Models
{
    public class PhoneBookDBHandler
    {
        private SqlConnection con;
        private void connection()
        {
            string constring = ConfigurationManager.ConnectionStrings["PhoneBookconn"].ToString();
            con = new SqlConnection(constring);
        }
        // **************** ADD NEW STUDENT *********************
        public bool AddPhoneBookEntry(PhoneBookModel phonebookmodel)
        {
            connection();
            SqlCommand cmd = new SqlCommand("AddNewEntry", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@EntryName", phonebookmodel.EntryName);
            cmd.Parameters.AddWithValue("@PhoneNumber", phonebookmodel.PhoneNumber);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }

        // ********** VIEW STUDENT DETAILS ********************
        public List<PhoneBookModel> GetDetails()
        {
            connection();
            List<PhoneBookModel> phonebooklist = new List<PhoneBookModel>();

            SqlCommand cmd = new SqlCommand("GetAllDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter pbd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            pbd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                phonebooklist.Add(
                    new PhoneBookModel
                    {
                        EntryName = Convert.ToString(dr["EntryName"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"])
                    });
            }
            return phonebooklist;
        }
        public List<PhoneBookModel> GetDetailsByName(string entryname)
        {
            connection();
            List<PhoneBookModel> phonebooklist = new List<PhoneBookModel>();

            SqlCommand cmd = new SqlCommand("GetDetails", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EntryName", entryname);
            SqlDataAdapter pbd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();

            con.Open();
            pbd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                phonebooklist.Add(
                    new PhoneBookModel
                    {
                        EntryName = Convert.ToString(dr["EntryName"]),
                        PhoneNumber = Convert.ToString(dr["PhoneNumber"])
                    });
            }
            return phonebooklist;
        }
    }
}