//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace IPS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Info
    {
        public long Id { get; set; }
        public long InfoId { get; set; }
        public string Title { get; set; }
        public string infoContent { get; set; }
        public Nullable<long> UserloginId { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> ReleaseTime { get; set; }
        public Nullable<System.DateTime> OffshelfTime { get; set; }
        public Nullable<long> UpdateUserloginId { get; set; }
        public Nullable<System.DateTime> UpdateTime { get; set; }
        public Nullable<long> InfoViews { get; set; }
        public string RoofPlacement { get; set; }
        public string State { get; set; }
    
        public virtual InfoCategory InfoCategory { get; set; }
    }
}
