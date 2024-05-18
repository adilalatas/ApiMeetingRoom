using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiyes.Models
{
    public class Room
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}
