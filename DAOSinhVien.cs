using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace CSharp
{
    public class DAOSinhVien : IDAO<SinhVien>
    {
        public SqlConnection conn { get; set; }

        public DAOSinhVien()
        {
            conn = new SqlConnection(Connection.Instance.GetConnectionString());
        }

        public List<SinhVien> GetAll()
        {
            List<SinhVien> list = new List<SinhVien>();

            string query = "Select * from SinhVien";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                while (rd.Read())
                {
                    SinhVien sv =
                        new SinhVien()
                        {
                            MSSV = Convert.ToInt32(rd["MSSV"]),
                            Name = rd["Name"].ToString(),
                            DTB = Convert.ToDouble(rd["DTB"]),
                            IDLop = Convert.ToInt32(rd["IDLop"])
                        };

                    list.Add (sv);
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

        public List<SinhVien> GetByID(int id)
        {
            List<SinhVien> list = null;

            string query = "Select * from SinhVien Where MSSV = @MSSV";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.Add("@MSSV", System.Data.SqlDbType.Int).Value =
                    id;
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    list = new List<SinhVien>();
                    while (rd.Read())
                    {
                        SinhVien sv =
                            new SinhVien()
                            {
                                MSSV = Convert.ToInt32(rd["MSSV"]),
                                Name = rd["Name"].ToString(),
                                DTB = Convert.ToDouble(rd["DTB"]),
                                IDLop = Convert.ToInt32(rd["IDLop"])
                            };

                        list.Add (sv);
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

        public List<SinhVien> GetByName(string name)
        {
            List<SinhVien> list = new List<SinhVien>();

            string query = "Select * from SinhVien Where Name = @Name";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd
                    .Parameters
                    .Add("@Name", System.Data.SqlDbType.NVarChar)
                    .Value = name;
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {
                    list = new List<SinhVien>();
                    while (rd.Read())
                    {
                        SinhVien sv =
                            new SinhVien()
                            {
                                MSSV = Convert.ToInt32(rd["MSSV"]),
                                Name = rd["Name"].ToString(),
                                DTB = Convert.ToDouble(rd["DTB"]),
                                IDLop = Convert.ToInt32(rd["IDLop"])
                            };

                        list.Add (sv);
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

        public bool Update(SinhVien obj)
        {
            string query =
                "Update SinhVien Set Name = @Name, DTB = @DTB Where MSSV = @MSSV";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NChar).Value =
                    obj.Name;
                cmd.Parameters.Add("@DTB", System.Data.SqlDbType.Float).Value =
                    obj.DTB;
                cmd.Parameters.Add("@MSSV", System.Data.SqlDbType.Int).Value =
                    obj.MSSV;
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

        public bool Delete(SinhVien obj)
        {
            string query = "Delete From SinhVien Where MSSV = @MSSV";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.Add("@MSSV", System.Data.SqlDbType.Int).Value =
                    obj.MSSV;
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

        public bool Add(SinhVien obj)
        {
            string query =
                "Insert Into SinhVien (MSSV, Name, DTB, IDLop) Values (@MSSV, @Name, @DTB, @IDLop)";
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                cmd.Parameters.Add("@MSSV", System.Data.SqlDbType.Int).Value =
                    obj.MSSV;
                cmd.Parameters.Add("@Name", System.Data.SqlDbType.NChar).Value =
                    obj.Name;
                cmd.Parameters.Add("@DTB", System.Data.SqlDbType.Float).Value =
                    obj.DTB;
                cmd.Parameters.Add("@IDLop", System.Data.SqlDbType.Int).Value =
                    obj.IDLop;
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
