using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

#nullable disable

namespace Models.Entities
{
    public partial class Libro
    {
        public int Isbn { get; set; }
        [Display(Name = "Editorial")]
        public int? EditorialesId { get; set; }

        [Required]
        [Display(Name = "Título")]
        [MaxLength(45, ErrorMessage = "El campo no puede tener más de 45 carácteres")]
        public string Titulo { get; set; }

        public string Sinopsis { get; set; }
        [Display(Name = "Número de Páginas")]
        [Range(0, 1000000, ErrorMessage = "El número máximo de páginas es 1000000")]
        public string NPaginas { get; set; }

        public virtual Editoriale Editoriales { get; set; }
    }
}
