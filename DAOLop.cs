using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CSharp
{
    public class DAOLop : IDAO<Lop>
    {
        public SqlConnection conn { get; set; }

        public DAOLop()
        {
            conn = new SqlConnection(Connection.Instance.GetConnectionString());
        }

        public List<Lop> GetAll()
        {
            string query = "Select * From Lop";
            List<Lop> list = new List<Lop>();
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    Lop lop =
                        new Lop()
                        {
                            ID = Convert.ToInt32(rd["ID"]),
                            Name = rd["Name"].ToString()
                        };

                    list.Add (lop);
                }

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return list;
        }

        public List<Lop> GetByID(int id)
        {
            string query = "Select * From Lop Where ID = @ID";
            List<Lop> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.NChar).Value =
                    id;
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    list = new List<Lop>();
                    while (rd.Read())
                    {
                        Lop lop =
                            new Lop()
                            {
                                ID = Convert.ToInt32(rd["ID"]),
                                Name = rd["Name"].ToString()
                            };
                        Console.WriteLine("1");
                        list.Add (lop);
                    }
                }

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return list;
        }

        public List<Lop> GetByName(string name)
        {
            string query = "Select * From Lop Where Name = @Name";
            List<Lop> list = null;
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NChar).Value =
                    name;
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    Console.WriteLine("Hey");
                    list = new List<Lop>();
                    while (rd.Read())
                    {
                        Lop lop =
                            new Lop()
                            {
                                ID = Convert.ToInt32(rd["ID"]),
                                Name = rd["Name"].ToString()
                            };
                        Console.WriteLine("1");
                        list.Add (lop);
                    }
                }

                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
            return list;
        }

        public bool Update(Lop obj)
        {
            string query = "Update Lop Set Name = @Name Where ID = @ID";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.Int).Value =
                    obj.Name;
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value =
                    obj.ID;
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool Delete(Lop obj)
        {
            string query = "Delete From Lop Where ID = @ID";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value =
                    obj.ID;
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool Add(Lop obj)
        {
            string query = "Insert Into Lop (ID, Name) Values (@ID, @Name)";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.Int).Value =
                    obj.Name;
                cmd.Parameters.Add("@ID", System.Data.SqlDbType.Int).Value =
                    obj.ID;
                conn.Open();
                int row = cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            return true;
        }
    }
}
