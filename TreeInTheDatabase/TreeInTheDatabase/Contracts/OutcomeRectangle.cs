using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeInTheDatabase.Models;

namespace TreeInTheDatabase.Contracts
{
    public class OutcomeRectangle : OutcomeNode
    {
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
    }
}
