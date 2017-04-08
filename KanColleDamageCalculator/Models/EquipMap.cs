using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public class EquipMap : CsvClassMap<Equip>
    {
        public EquipMap()
        {
            Map(m => m.Type).Index(0).Name("装備種");
            Map(m => m.Name).Index(1).Name("装備名");
            Map(m => m.FirePower).Index(2).Name("火力");
            Map(m => m.Torpedo).Index(3).Name("雷装");
            Map(m => m.AA).Index(4).Name("対空");
            Map(m => m.Armor).Index(5).Name("装甲");
            Map(m => m.ASW).Index(6).Name("対潜");
            Map(m => m.Evade).Index(7).Name("回避");
            Map(m => m.ViewRange).Index(8).Name("索敵");
            Map(m => m.Luck).Index(9).Name("運");
            Map(m => m.Hit).Index(10).Name("命中");
            Map(m => m.Bomber).Index(11).Name("爆装");
            Map(m => m.Range).Index(12).Name("射程");
            Map(m => m.Radius).Index(13).Name("戦闘行動半径");
        }
    }
}
