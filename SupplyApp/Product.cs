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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.Supply = new HashSet<Supply>();
        }
    
        public long Id_Product { get; set; }
        public string Product_Сode { get; set; }
        public string Name { get; set; }
        public System.DateTime Sales_start_date { get; set; }
        public decimal Recommended_Price { get; set; }
        public decimal Dealer_Price { get; set; }
        public decimal Postpartner_Price { get; set; }
        public decimal RF_VAT_Rate { get; set; }
        public string Currency { get; set; }
        public long Id_Category { get; set; }
    
        public virtual Product_Сategory Product_Сategory { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Supply> Supply { get; set; }
    }
}