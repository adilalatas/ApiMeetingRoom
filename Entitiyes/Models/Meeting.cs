using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entitiyes.Models
{
    public class Meeting
    {
        public Guid Id { get; set; }
        [ForeignKey("User")]
        public Guid CreateUserId { get; set; }
        [ForeignKey("Room")]
        public Guid RoomId { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
