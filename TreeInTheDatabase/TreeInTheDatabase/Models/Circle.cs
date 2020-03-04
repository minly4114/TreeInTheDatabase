using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeInTheDatabase.Models
{
    public class Circle : Node
    {
        private double _radius;
        public double Radius
        {
            get { return _radius; }
            set { _radius = value; Square = Math.PI * 2 * Radius; }
        }

        public Circle()
        {
                
        }
        public Circle(Node node)
        {
            Id = node.Id;
            Guid = node.Guid;
            Parameters = node.Parameters;
            Square = node.Square;
            TypeNode = node.TypeNode;
            Parent = node.Parent;
            Children = node.Children;
        }

        public Node ToNode()
        {
            var node = (Node)this;
            node.Parameters = JsonConvert.SerializeObject(new { Radius });
            node.TypeNode = TypeNode.Circle;
            return node;
        }
    }
}
