using MediatR;
using BankingAPI.Application.BankAccounts.Commands;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Handlers
{
    public class UpdateBankAccountHandler : IRequestHandler<UpdateBankAccountCommand>
    {
        private readonly List<BankAccount> _bankAccounts;

        public UpdateBankAccountHandler()
        {
            _bankAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = "123456", AccountType = "savings", Balance = 1000, CustomerName = "John Doe" },
                new BankAccount { Id = 2, AccountNumber = "654321", AccountType = "current", Balance = 2000, CustomerName = "Jane Smith" }
            };
        }

        public Task<Unit> Handle(UpdateBankAccountCommand request, CancellationToken cancellationToken)
        {
            var account = _bankAccounts.FirstOrDefault(a => a.Id == request.BankAccount.Id);
            if (account != null)
            {
                account.AccountNumber = request.BankAccount.AccountNumber;
                account.AccountType = request.BankAccount.AccountType;
                account.Balance = request.BankAccount.Balance;
                account.CustomerName = request.BankAccount.CustomerName;
            }

            return Unit.Task;
        }

    
    }
}