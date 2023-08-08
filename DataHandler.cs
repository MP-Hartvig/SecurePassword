using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurePassword
{
    internal class DataHandler
    {
        string connString = "Data Source=MPP-P53;" +
            "Initial Catalog=HashAndSaltDB;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;";

        public string GetSaltOnUser(string username)
        {
            string salt = "";

            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                conn.Open();

                SqlCommand command = new SqlCommand("GetSaltOnUser", conn);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            salt = reader.GetString("Salt");
                        }

                        return salt;
                    }
                }
                catch (Exception e)
                {
                    return salt;
                }
            }
        }

        public bool CheckUserLogin(string username, string password)
        {
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CheckUserLogin", conn);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;
                command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password;

                int result = 0;

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result = reader.GetInt32("Id");
                        }

                        if (result != 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                catch (Exception e)
                {
                    return false;
                }
            }
        }

        public int GetUserId(string username)
        {
            int id = 0;

            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                conn.Open();

                SqlCommand command = new SqlCommand("GetUserId", conn);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;

                try
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            id = reader.GetInt32("Id");
                        }

                        return id;
                    }
                }
                catch (Exception e)
                {
                    return id;
                }
            }
        }

        public bool CreateUser(string username, string password, string salt)
        {
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                conn.Open();

                SqlCommand command = new SqlCommand("CreateUser", conn);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;
                command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password;
                command.Parameters.AddWithValue("@Salt", SqlDbType.VarChar).Value = salt;

                return ExecuteNonQuery(command);
            }
        }

        public bool UpdateUser(string username, string password, string salt, int id)
        {
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                conn.Open();

                SqlCommand command = new SqlCommand("UpdateUserInfo", conn);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Username", SqlDbType.VarChar).Value = username;
                command.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = password;
                command.Parameters.AddWithValue("@Salt", SqlDbType.VarChar).Value = salt;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                return ExecuteNonQuery(command);
            }
        }

        public bool DeleteUser(int id)
        {
            SqlConnection conn = new SqlConnection(connString);

            using (conn)
            {
                conn.Open();

                SqlCommand command = new SqlCommand("DeleteUserInfo", conn);

                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id;

                return ExecuteNonQuery(command);
            }
        }

        public bool ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                int rowsAffected = command.ExecuteNonQuery();

                // Not sure why, but rowsAffected returns as -1 when 
                if (rowsAffected != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
