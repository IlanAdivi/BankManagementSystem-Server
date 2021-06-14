using BankManagementSystem.Interfaces;
using BankManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagementSystem.Helpers
{
    public class BankHelper
    {
        public IEnumerable<BankOptionsModel> BankOptions = new List<BankOptionsModel>(14)
            {
                { new BankOptionsModel { Value = "פועלים", Label = "פועלים"} },
                { new BankOptionsModel { Value = "איגוד", Label = "איגוד" } },
                { new BankOptionsModel { Value = "דיסקונט", Label = "דיסקונט" } },
                { new BankOptionsModel { Value = "דקסיה", Label = "דקסיה" } },
                { new BankOptionsModel { Value = "יהב", Label = "יהב" } },
                { new BankOptionsModel { Value = "ירושלים", Label = "ירושלים" } },
                { new BankOptionsModel { Value = "לאומי", Label = "לאומי" } },
                { new BankOptionsModel { Value = "מזרחי", Label = "מזרחי" } },
                { new BankOptionsModel { Value = "מסד", Label = "מסד" } },
                { new BankOptionsModel { Value = "מרכנתיל", Label = "מרכנתיל" } },
                { new BankOptionsModel { Value = "ערבי ישראלי", Label = "ערבי ישראלי" } },
                { new BankOptionsModel { Value = "פועלי אגודת ישראל", Label = "פועלי אגודת ישראל" } },
                { new BankOptionsModel { Value = "בינלאומי", Label = "בינלאומי" } },
                { new BankOptionsModel { Value = "יובנק", Label = "יובנק" } },
            };
    }
}
