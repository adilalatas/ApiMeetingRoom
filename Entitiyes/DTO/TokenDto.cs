using Entitiyes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiyes.DTO
{
    public record TokenDto
    {
        public String AccessToken { get; init; }
        public String RefreshToken { get; init; }
        public User LoginUser { get; init; }
        public string LoginUserRole { get; init; }
    }
}
