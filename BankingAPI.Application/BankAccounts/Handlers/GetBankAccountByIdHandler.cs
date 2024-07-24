using MediatR;
using BankingAPI.Application.BankAccounts.Queries;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Handlers
{
    // Handler to handle GetBankAccountByIdQuery
    public class GetBankAccountByIdHandler : IRequestHandler<GetBankAccountByIdQuery, BankAccount>
    {
        private readonly List<BankAccount> _bankAccounts;

        // Initializing with mock data
        public GetBankAccountByIdHandler()
        {
            _bankAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = "123456", AccountType = "savings", Balance = 1000, CustomerName = "Dayananda M" },
                new BankAccount { Id = 2, AccountNumber = "654321", AccountType = "current", Balance = 2000, CustomerName = "Swamy Dayanand" }
            };
        }

        // Handle method to process the query
        public Task<BankAccount> Handle(GetBankAccountByIdQuery request, CancellationToken cancellationToken)
        {
            var account = _bankAccounts.FirstOrDefault(a => a.Id == request.Id);
            return Task.FromResult(account);
        }
    }
}

