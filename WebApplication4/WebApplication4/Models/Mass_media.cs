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

    public partial class Mass_media
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Mass_media()
        {
            this.Category_advertising = new HashSet<Category_advertising>();
        }
    
        public int Id_mass_media { get; set; }
        public int Id_mediabuiner { get; set; }
        [Display(Name = "Название СМИ")]
        public string Name_mass_media { get; set; }
        [Display(Name = "Предметная область")]
        public string Subject_area { get; set; }
        [Display(Name = "Цена")]
        public int Price { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Category_advertising> Category_advertising { get; set; }
        public virtual Mediabuiner Mediabuiner { get; set; }
    }
}
