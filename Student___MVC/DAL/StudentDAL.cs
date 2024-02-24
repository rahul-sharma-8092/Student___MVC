using Student___MVC.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace Student___MVC.DAL
{
    public class StudentDAL
    {
        private readonly string _connString = ConfigurationManager.ConnectionStrings["dbConnString"].ConnectionString.ToString();

        #region Get Student List
        public DataTable StudentList()
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@pageIndex", 1);
                cmd.Parameters.AddWithValue("@pageSize", 10);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region Get Student info By Id
        public DataTable StudentInfo(int id)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@query", 1);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region Student Register
        public string StudentRegister(Student student)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@password", student.Password);
                cmd.Parameters.AddWithValue("@birthDate", student.BirthDate);
                cmd.Parameters.AddWithValue("@mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@country", student.Country);
                cmd.Parameters.AddWithValue("@state", student.State);
                cmd.Parameters.AddWithValue("@district", student.District);
                cmd.Parameters.AddWithValue("@dpImage", student.DpImageName);
                cmd.Parameters.AddWithValue("@certificate", student.CertificateName);
                cmd.Parameters.AddWithValue("@query", 1);

                string result = cmd.ExecuteNonQuery().ToString();

                return result;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region Student Update
        public string StudentUpdate(Student student)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@name", student.Name);
                cmd.Parameters.AddWithValue("@email", student.Email);
                cmd.Parameters.AddWithValue("@password", student.Password);
                cmd.Parameters.AddWithValue("@birthDate", student.BirthDate);
                cmd.Parameters.AddWithValue("@mobile", student.Mobile);
                cmd.Parameters.AddWithValue("@address", student.Address);
                cmd.Parameters.AddWithValue("@country", student.Country);
                cmd.Parameters.AddWithValue("@state", student.State);
                cmd.Parameters.AddWithValue("@district", student.District);
                cmd.Parameters.AddWithValue("@dpImage", student.DpImageName);
                cmd.Parameters.AddWithValue("@certificate", student.CertificateName);
                cmd.Parameters.AddWithValue("@query", 2);

                string result = cmd.ExecuteNonQuery().ToString();

                return result;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region Student Delete
        public string StudentDelete(int StuId)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", StuId);
                cmd.Parameters.AddWithValue("@query", 3);

                string result = cmd.ExecuteNonQuery().ToString();

                return result;
            }
            catch (Exception Ex)
            {
                return Ex.Message;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region CountryDdlBind
        public DataTable CountryDdlBind()
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("Country__State__District__ListforDDL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@query", 1);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region CityDdlBind
        public DataTable StateDdlBind(string id)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("Country__State__District__ListforDDL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@countryId", Convert.ToInt32(id));
                cmd.Parameters.AddWithValue("@query", 2);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region DistrictDdlBind
        public DataTable DistrictDdlBind(string id)
        {
            SqlConnection conn = new SqlConnection(_connString);
            conn.Open();

            try
            {
                SqlCommand cmd = new SqlCommand("Country__State__District__ListforDDL", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@stateId", Convert.ToInt32(id));
                cmd.Parameters.AddWithValue("@query", 3);

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable table = new DataTable();

                adapter.Fill(table);

                return table;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
        #endregion

        #region String Encryption
        //public string Encryption(string data)
        //{
        //    MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
        //    TripleDESCryptoServiceProvider tripleDES = new TripleDESCryptoServiceProvider();
        //    Encoding encoding = Encoding.UTF8;

        //    string secretKey = "Rahul$$1234";

        //    byte[] data = Encoding.UTF8.Convert.FromBase64String(data);

        //    tripleDES.Key = md5.ComputeHash(Encoding.UTF8.GetBytes(secretKey));
        //}
        #endregion
    }
}