namespace QuanLyNhanSu.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tblPhong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblPhong()
        {
            tblThongTinNVs = new HashSet<tblThongTinNV>();
        }

        [Key]
        [StringLength(15)]
        public string MaPhong { get; set; }

        [StringLength(50)]
        public string TenPhong { get; set; }

        [StringLength(50)]
        public string TenTruongPhong { get; set; }

        [StringLength(15)]
        public string DienThoaiPhong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblThongTinNV> tblThongTinNVs { get; set; }
    }
}
