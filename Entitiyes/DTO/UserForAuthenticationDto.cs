using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiyes.DTO
{
    public record UserForAuthenticationDto
    {
        [Required(ErrorMessage = "Email Alanı Zorunludur")]
        public string? Email { get; init; }

        [Required(ErrorMessage = "Şifre Zorunludur")]
        public string? Password { get; init; }
    }
}
