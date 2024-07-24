using Moq;
using MediatR;
using FluentAssertions;
using BankingAPI.Application.BankAccounts.Queries;
using BankingAPI.Application.BankAccounts.Handlers;
using BankingAPI.Domain.Entities;
using BankingAPI.Application.BankAccounts.Commands;

namespace BankingAPI.Tests
{
    public class BankAccountTests
    {
        private readonly Mock<IMediator> _mediatorMock;

        public BankAccountTests()
        {
            _mediatorMock = new Mock<IMediator>();
        }

        [Fact]
        public async Task GetBankAccountsByType_ShouldReturnAccountsOfSpecifiedType()
        {
            // Arrange
            var query = new GetBankAccountsByTypeQuery("savings");
            var handler = new GetBankAccountsByTypeHandler();
            var expectedAccounts = new List<BankAccount>
            {
                new BankAccount { Id = 1, AccountNumber = "123456", AccountType = "savings", Balance = 1000, CustomerName = "Dayananda M" }
            };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(expectedAccounts);
        }

        [Fact]
        public async Task GetBankAccountById_ShouldReturnAccountIfExists()
        {
            // Arrange
            var query = new GetBankAccountByIdQuery(1);
            var handler = new GetBankAccountByIdHandler();
            var expectedAccount = new BankAccount { Id = 1, AccountNumber = "123456", AccountType = "savings", Balance = 1000, CustomerName = "Dayananda M" };

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            result.Should().BeEquivalentTo(expectedAccount);
        }

        [Fact]
        public async Task UpdateBankAccount_ShouldUpdateAccountDetails()
        {
            // Arrange
            var handler = new UpdateBankAccountHandler();
            var updatedAccount = new BankAccount { Id = 1, AccountNumber = "123456", AccountType = "savings", Balance = 1000, CustomerName = "Dayananda M Updated" };
            var command = new UpdateBankAccountCommand(updatedAccount);

            // Act
            await handler.Handle(command, CancellationToken.None);
            var result = await new GetBankAccountByIdHandler().Handle(new GetBankAccountByIdQuery(1), CancellationToken.None);

            // Assert
            result.Should().NotBeEquivalentTo(updatedAccount);
        }
    }
}