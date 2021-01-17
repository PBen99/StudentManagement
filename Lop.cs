using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp
{
    public class Lop
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public override int GetHashCode()
        {
            return this.ID.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }
            Lop sv = obj as Lop;
            return sv.ID == this.ID;
        }

        public override string ToString()
        {
            return "ID = " + ID + "Ten lop = " + Name;
        }
    }
}
