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
    
    public partial class Накладная
    {
        public int Id_Накладная { get; set; }
        public string НомерКвитанции { get; set; }
        public Nullable<int> Id_Отправ { get; set; }
        public Nullable<int> Id_КонтрАгента { get; set; }
        public Nullable<int> Id_СТАотправ { get; set; }
        public Nullable<int> Id_СТАназнач { get; set; }
        public Nullable<int> Id_МаркаУгляя { get; set; }
        public string НомерВагона { get; set; }
        public string Упаковка { get; set; }
        public string НомерЗаявки { get; set; }
        public Nullable<int> Id_Деклараций { get; set; }
    
        public virtual КонтрАгент КонтрАгент { get; set; }
        public virtual МаркаУгля МаркаУгля { get; set; }
        public virtual Отправитель Отправитель { get; set; }
        public virtual СправДек СправДек { get; set; }
        public virtual Станция Станция { get; set; }
        public virtual Станция2 Станция2 { get; set; }
    }
}
