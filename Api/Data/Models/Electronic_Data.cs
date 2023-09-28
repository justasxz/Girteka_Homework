using System.ComponentModel.DataAnnotations;

namespace Girteka_Homework.Data.Models
{
    public class Electronic_Data : SystemFields
    {

        public string Network { get; set; }
        public string ObjectName { get; set; }
        public string? ObjectType { get; set; }
        public long? ObjectNumber { get; set; }
        public double? HourlyConsumption { get; set; }
        public DateTime Date { get; set; }
        public double? HourlyProduction { get; set; }
    }
}
