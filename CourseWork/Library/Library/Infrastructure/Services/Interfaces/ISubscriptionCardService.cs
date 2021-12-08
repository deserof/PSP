using ClosedXML.Excel;
using Library.Entities;

namespace Library.Infrastructure.Services.Interfaces
{
    public interface ISubscriptionCardService : IService<SubscriptionCard>
    {
        XLWorkbook GenerateReport();
    }
}
