//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Diplom2
{
    using System;
    using System.Collections.Generic;
    
    public partial class СправДек
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public СправДек()
        {
            this.Анализ_ВТД = new HashSet<Анализ_ВТД>();
            this.ВПД = new HashSet<ВПД>();
            this.Накладная = new HashSet<Накладная>();
        }
    
        public int Id_Деклараций { get; set; }
        public string НомерВТД { get; set; }
        public string Тонн { get; set; }
        public string Марка { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Анализ_ВТД> Анализ_ВТД { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ВПД> ВПД { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Накладная> Накладная { get; set; }
    }
}
