using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TreeInTheDatabase.Models
{
    public class Node
    {
        [Key]
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Parameters { get; set; }
        public double Square { get; set; }
        public TypeNode TypeNode { get; set; }

        public Node Parent { get; set; }
        public List<Node> Children { get; set; }
        public List<ChangesNode> ChangesNodes { get; set; }
    }
    public enum TypeNode
    {
        Circle,
        Quadrate,
        Rectangle
    }
}
