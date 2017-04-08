using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KanColleDamageCalculator.Models
{
    public class ShipMap : CsvClassMap<Ship>
    {
        public ShipMap()
        {
            Map(m => m.ID).Index(0).Name("ID");
            Map(m => m.Type).Index(0).Name("艦種");
            Map(m => m.Name).Index(1).Name("艦名");
            Map(m => m.HP).Index(2).Name("耐久初期");
            Map(m => m.FirePower).Index(3).Name("火力最大");
            Map(m => m.Torpedo).Index(4).Name("雷装最大");
            Map(m => m.AA).Index(5).Name("対空最大");
            Map(m => m.Armor).Index(6).Name("装甲最大");
            Map(m => m.ASW).Index(7).Name("対潜最大");
            Map(m => m.Evade).Index(8).Name("回避最大");
            Map(m => m.ViewRange).Index(9).Name("索敵最大");
            Map(m => m.Luck).Index(10).Name("運最大");
            Map(m => m.Have).Index(11).Name("スロット数");
            Map(m => m.Slot1Num).Index(12).Name("搭載機数1");
            Map(m => m.Slot2Num).Index(13).Name("搭載機数2");
            Map(m => m.Slot3Num).Index(14).Name("搭載機数3");
            Map(m => m.Slot4Num).Index(15).Name("搭載機数4");
            Map(m => m.KanmusuFlag).Index(15).Name("艦娘フラグ");
        }
    }
}
