using MediatR;
using BankingAPI.Application.BankAccounts.Queries;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Handlers
{
    // Handler to handle GetBankAccountsByTypeQuery
    public class GetBankAccountsByTypeHandler : IRequestHandler<GetBankAccountsByTypeQuery, IEnumerable<BankAccount>>
    {
        private readonly List<BankAccount> _bankAccounts;

        // Initializing with mock data
        public GetBankAccountsByTypeHandler()
        {
            _bankAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = "123456", AccountType = "savings", Balance = 1000, CustomerName = "Dayananda M" },
                new BankAccount { Id = 2, AccountNumber = "654321", AccountType = "current", Balance = 2000, CustomerName = "Swamy Dayanand" }
            };
        }

        // Handle method to process the query
        public Task<IEnumerable<BankAccount>> Handle(GetBankAccountsByTypeQuery request, CancellationToken cancellationToken)
        {
            var accounts = _bankAccounts.Where(a => a.AccountType == request.AccountType);
            return Task.FromResult(accounts);
        }
    }
}
