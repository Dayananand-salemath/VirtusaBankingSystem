using MediatR;
using BankingAPI.Application.BankAccounts.Queries;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Handlers
{
    public class GetBankAccountsByTypeHandler : IRequestHandler<GetBankAccountsByTypeQuery, IEnumerable<BankAccount>>
    {
        private readonly List<BankAccount> _bankAccounts;

        public GetBankAccountsByTypeHandler()
        {
            _bankAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = "123456", AccountType = "savings", Balance = 1000, CustomerName = "John Doe" },
                new BankAccount { Id = 2, AccountNumber = "654321", AccountType = "current", Balance = 2000, CustomerName = "Jane Smith" }
            };
        }

        public Task<IEnumerable<BankAccount>> Handle(GetBankAccountsByTypeQuery request, CancellationToken cancellationToken)
        {
            var accounts = _bankAccounts.Where(a => a.AccountType == request.AccountType);
            return Task.FromResult(accounts);
        }
    }
}
