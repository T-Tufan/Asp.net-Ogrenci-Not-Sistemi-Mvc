//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OgrenciNotMvc.Models.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tbl_Notlar
    {
        public int Not_Id { get; set; }
        public Nullable<byte> Ders_Id { get; set; }
        public Nullable<byte> Ogrenci_Id { get; set; }
        public Nullable<byte> Sınav1 { get; set; }
        public Nullable<byte> Sınav2 { get; set; }
        public Nullable<byte> Proje { get; set; }
        public Nullable<decimal> Ortalama { get; set; }
        public Nullable<bool> Durum { get; set; }
    
        public virtual Tbl_Dersler Tbl_Dersler { get; set; }
        public virtual Tbl_Ogrenci Tbl_Ogrenci { get; set; }
    }
}
