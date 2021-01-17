using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CSharp
{
    public class BO
    {
        private IDAO<SinhVien> _svs;

        private IDAO<Lop> _lops;

        public BO()
        {
            _svs = new DAOSinhVien();
            _lops = new DAOLop();
        }

        public List<SinhVienView> GetAll()
        {
            List<SinhVienView> svs = new List<SinhVienView>();
            List<SinhVien> daoSvs = _svs.GetAll();
            List<Lop> daoLops = _lops.GetAll();
            foreach (SinhVien sv in daoSvs)
            {
                string lop = daoLops.Find(x => sv.IDLop.Equals(x.ID)).Name;
                SinhVienView svview =
                    new SinhVienView()
                    { MSSV = sv.MSSV, Name = sv.Name, DTB = sv.DTB, Lop = lop };
                svs.Add (svview);
            }
            return svs;
        }

        public bool Update(SinhVienView sv)
        {
            List<SinhVien> sviens = _svs.GetByID(sv.MSSV);
            List<Lop> lops = _lops.GetByName(sv.Lop);
            if (sv == null || sviens.Any() || !lops.Any())
            {
                return false;
            }
            SinhVien svien = new SinhVien(){
                MSSV = sv.MSSV,
                Name = sv.Name,
                DTB = sv.DTB,
                IDLop = lops[0].ID
            };
            return _svs.Update(svien);
        }
    }
}
