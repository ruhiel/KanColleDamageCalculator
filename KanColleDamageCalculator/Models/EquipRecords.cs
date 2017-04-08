using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public class EquipRecords : CSVRecords<Equip, EquipMap>
    {
        public static EquipRecords Instance = new EquipRecords();


        private EquipRecords(string fileName = "equips.csv") : base(fileName)
        {

        }
    }
}
