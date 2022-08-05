namespace TodoAppDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Note
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public string Text { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<Like> Likes { get; set; }
    }
}
