using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB.Database.Models
{
    public class Publication
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public string Image { get; set; }
    }
}
