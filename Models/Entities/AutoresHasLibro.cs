using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models.Entities
{
    public partial class AutoresHasLibro
    {
        public int AutoresId { get; set; }
        public int LibrosIsbn { get; set; }
        [Key]
        public virtual Autore Autores { get; set; }
        [Key]
        public virtual Libro LibrosIsbnNavigation { get; set; }
    }
}
