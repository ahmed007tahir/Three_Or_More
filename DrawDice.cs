using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Three_Or_More
{
    internal class DrawDice : Dice
    {
        public static Dictionary<int, string> printDieFace()
        {

            Dictionary<int, string> DieFace = new Dictionary<int, string>()
            {
                {
                    1, @"
    ┌─────────┐
    │         │
    │    0    │
    │         │
    └─────────┘"
                },
                {
                    2, @"
    ┌─────────┐
    │ 0       │
    │         │
    │       0 │
    └─────────┘"
                },
                {
                    3, @"
    ┌─────────┐
    │ 0       │
    │    0    │
    │       0 │
    └─────────┘"
                },
                {
                    4, @"
    ┌─────────┐
    │ 0     0 │
    │         │
    │ 0     0 │
    └─────────┘"
                },
                {
                    5, @"
    ┌─────────┐
    │ 0     0 │
    │    0    │
    │ 0     0 │
    └─────────┘"
                },
                {
                    6, @"
    ┌─────────┐
    │ 0  0  0 │
    │ 0  0  0 │
    │ 0  0  0 │
    └─────────┘"
                },

            };
            return DieFace;
        }
    }
}
