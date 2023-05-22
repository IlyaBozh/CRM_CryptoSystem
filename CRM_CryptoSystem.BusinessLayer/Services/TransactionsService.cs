
using CRM_CryptoSystem.BusinessLayer.Services.Interfaces;
using IncredibleBackendContracts.Requests;
using IncredibleBackendContracts.Responses;

namespace CRM_CryptoSystem.BusinessLayer.Services;

public class TransactionsService : ITransactionsService
{
    public Task<long> AddDeposit(TransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<long> AddWithdraw(TransactionRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<decimal> GetBalanceByAccountsId(int accountId)
    {
        throw new NotImplementedException();
    }

    public Task<TransactionResponse> GetTransactionById(int transactionId)
    {
        throw new NotImplementedException();
    }

    public Task<List<TransactionResponse>> GetTransactionsByAccountId(int accountId)
    {
        throw new NotImplementedException();
    }
}
