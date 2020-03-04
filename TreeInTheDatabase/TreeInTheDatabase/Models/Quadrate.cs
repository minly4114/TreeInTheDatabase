using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeInTheDatabase.Models
{
    public class Quadrate : Node
    {
        private double _side;
        public double Side { 
            get { return _side; }
            set { _side = value; Square = _side * _side; }
        }
        public Node ToNode()
        {
            var node = (Node)this;
            node.Parameters = JsonConvert.SerializeObject(new { Side });
            node.TypeNode = TypeNode.Quadrate;
            return node;
        }
    }
}
