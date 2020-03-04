using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TreeInTheDatabase.Contracts
{
    public class OutcomeNode
    {
        public int Id { get; set; }
        public double Square { get; set; }
        public List<OutcomeNode> Children { get; set; }
    }
}
