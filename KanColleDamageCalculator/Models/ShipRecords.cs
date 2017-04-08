using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public class ShipRecords : CSVRecords<Ship, ShipMap>
    {
        public static ShipRecords Instance = new ShipRecords();

        private ShipRecords(string fileName = "ships.csv") : base(fileName)
        {
        }
    }
}
