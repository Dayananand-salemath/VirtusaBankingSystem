using MediatR;
using BankingAPI.Application.BankAccounts.Commands;
using BankingAPI.Domain.Entities;

namespace BankingAPI.Application.BankAccounts.Handlers
{
    // Handler to handle UpdateBankAccountCommand
    public class UpdateBankAccountHandler : IRequestHandler<UpdateBankAccountCommand>
    {
        private readonly List<BankAccount> _bankAccounts;

        // Initializing with mock data
        public UpdateBankAccountHandler()
        {
            _bankAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = "123456", AccountType = "savings", Balance = 1000, CustomerName = "Dayananda M" },
                new BankAccount { Id = 2, AccountNumber = "654321", AccountType = "current", Balance = 2000, CustomerName = "Swamy Dayanand" }
            };
        }

        // Handle method to process the command
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