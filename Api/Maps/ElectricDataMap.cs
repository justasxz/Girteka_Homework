using CsvHelper.Configuration;
using Girteka_Homework.Data.Models;

namespace Girteka_Homework.Maps
{
    sealed class ElectricDataMap : ClassMap<Electronic_Data>
    {

        public ElectricDataMap()
        {
            Map(m => m.Network).Name("TINKLAS");
            Map(m => m.ObjectName).Name("OBT_PAVADINIMAS");
            Map(m => m.ObjectType).Name("OBJ_GV_TIPAS");
            Map(m => m.ObjectNumber).Name("OBJ_NUMERIS");
            Map(m => m.HourlyConsumption).Name("P+");
            Map(m => m.Date).Name("PL_T");
            Map(m => m.HourlyProduction).Name("P-");
        }
    }
}
