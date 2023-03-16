namespace QuanLyNhanSu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("tblChamCong")]
    public partial class tblChamCong
    {
        public int ID { get; set; }

        [StringLength(15)]
        public string MaNV { get; set; }

        [StringLength(50)]
        public string TenNV { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngay { get; set; }

        public TimeSpan? ThoiGianVao { get; set; }

        public TimeSpan? ThoiGianRa { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual tblThongTinNV tblThongTinNV { get; set; }
    }
}
