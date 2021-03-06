//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication4.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Category_advertising
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Category_advertising()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int Id_category_advertising { get; set; }
        public int Id_manager { get; set; }
        public Nullable<int> Id_mass_media { get; set; }
        [Display(Name = "Срок действия рекламы")]
        public string Advertising_period { get; set; }
        [Display(Name = "Визуальные средства")]
        public string Visual_aid { get; set; }
    
        public virtual Manager Manager { get; set; }
        public virtual Mass_media Mass_media { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Order { get; set; }
    }
}
