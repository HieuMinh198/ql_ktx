﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnWeb.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class dich_vu_phong
    {
        [DisplayName("Mã dịch vụ phòng")]
        public string ma_dich_vu_phong { get; set; }
        [DisplayName("Số lượng")]
        public int so_luong { get; set; }
        public string ma_dich_vu { get; set; }
        public string ma_phong { get; set; }
    
        public virtual dich_vu dich_vu { get; set; }
        public virtual Phong Phong { get; set; }
    }
}
