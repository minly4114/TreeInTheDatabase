using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TreeInTheDatabase.Models
{
    public class ChangesNode
    {
        [Key]
        public int Id { get; set; }
        public Node Node { get; set; }
        public DateTime DateChanges { get; set; }
        public string Parameters { get; set; }
    }
}
