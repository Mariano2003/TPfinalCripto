﻿using System.ComponentModel.DataAnnotations;

namespace CriproBack.DTOs
{
    public class ClienteUpdateDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email no tiene un formato válido")]
        public string Email { get; set; }
    }
}
