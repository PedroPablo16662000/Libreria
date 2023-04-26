using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models.Entities
{
    public partial class Editoriale
    {
        public Editoriale()
        {
            Libros = new HashSet<Libro>();
        }

        public int Id { get; set; }
        [MaxLength(45, ErrorMessage = "El campo no puede tener más de 45 carácteres")]
        [Required]
        public string Nombre { get; set; }
        [MaxLength(45, ErrorMessage = "El campo no puede tener más de 45 carácteres")]
        public string Sede { get; set; }

        public virtual ICollection<Libro> Libros { get; set; }
    }
}
