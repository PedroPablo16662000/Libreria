using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace Models.Entities
{
    [Display(Name ="Editoriales")]
    public partial class Autore
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage = "El campo no puede tener más de 45 carácteres")]
        public string Nombre { get; set; }
        [Required]
        [MaxLength(45, ErrorMessage = "El campo no puede tener más de 45 carácteres")]
        public string Apellidos { get; set; }
    }
}
