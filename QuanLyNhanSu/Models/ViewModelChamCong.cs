using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyNhanSu.Models
{
    public class ViewModelChamCong
    {
        public tblChamCong ChamCong { get; set; }
        public IEnumerable<tblChamCong> DanhSachChamCong { get; set; }
    }
}