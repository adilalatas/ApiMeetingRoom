using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiyes.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int CreateUserId { get; set; }
        public DateTime CreateDate { get; set; }
        public string Name { get; set; }
    }
}
