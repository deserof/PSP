using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TradeCompany.Models;
using ClosedXML.Excel;

namespace TradeCompany.Infrastructure.Services.Histories
{
    public interface IHistoryService : IService<History>
    {
        void AddProductById(string text, int id);

        XLWorkbook GenerateExcelReport(int id);
    }
}
