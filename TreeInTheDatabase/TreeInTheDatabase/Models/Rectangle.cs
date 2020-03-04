using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeInTheDatabase.Models
{
    public class Rectangle : Node
    {
        private double _firstSide;
        private double _secondSide;
        public double FirstSide
        {
            get { return _firstSide; }
            set
            {
                _firstSide = value;
                Square = _firstSide * _secondSide;
            }
        }
        public double SecondSide
        {
            get { return _secondSide; }
            set
            {
                _secondSide = value;
                Square = _firstSide * _secondSide;
            }
        }
        public Node ToNode()
        {
            var node = (Node)this;
            node.Parameters = JsonConvert.SerializeObject(new { FirstSide,SecondSide });
            node.TypeNode = TypeNode.Rectangle;
            return node;
        }
    }
}
