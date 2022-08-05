namespace TodoAppDatabase.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class User
    {
        public int Id { get; set; }

        [MaxLength(10)]

        public string Name { get; set; }

        public ICollection<Note> Notes { get; set; }
    }
}
