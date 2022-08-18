using CoreBusiness;
using System.Collections.Generic;

namespace UseCases
{
    public interface IGetTodayTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}