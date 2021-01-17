using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp
{
    public class SinhVien
    {
        public int MSSV { get; set; }

        public string Name { get; set; }

        public double DTB { get; set; }

        public int IDLop { get; set; }

        public override int GetHashCode()
        {
            return this.MSSV.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            SinhVien sv = obj as SinhVien;
            return sv.MSSV == this.MSSV;
        }

        public override string ToString()
        {
            return ("MSSV = " + MSSV + " - Name = " + Name + " - DTB = " + DTB);
        }
    }
}
