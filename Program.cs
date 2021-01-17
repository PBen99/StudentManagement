using System;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CSharp
{
    class Program
    {
        static void Main(string[] args)
        {
            BO view = new BO();
            SinhVienView sv = new SinhVienView(){
                MSSV = 7,
                Name = "Dorn",
                DTB = 8.9,
                Lop = "17T4"
            };
                Console.WriteLine (view.Update(sv));
        }
    }
}
