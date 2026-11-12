using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace demoOlimpiada_12_11_26
{
    public class CompareItem
    {
        public int tarifId { get; set; }
        public string tarifName { get; set; }
        public int extraMin { get; set; }
        public int extraSms { get; set; }
        public int extraGb { get; set; }
        public int totalMin { get; set; }
        public int totalSms { get; set; }
        public int totalGb { get; set; }
        public decimal totalCost { get; set; }
    }

    public static class CompareStorage
    {
        public static List<CompareItem> Items = new List<CompareItem>();
    }
}
