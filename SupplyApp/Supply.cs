//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SupplyApp
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supply
    {
        public long Id_Supply { get; set; }
        public long Id_Product { get; set; }
        public long Id_Supplier { get; set; }
        public decimal Price_Supply { get; set; }
        public int Scope_Supply { get; set; }
        public System.DateTime Date_Supply { get; set; }
        public long Id_Worker { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Supplier Supplier { get; set; }
        public virtual Worker Worker { get; set; }
    }
}
