using SmartWalletHybrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Services
{
    public interface IDatabaseService
    {
        Task SaveAccount(Account account);
        Task SaveBudget(Budget budget);
        Task<List<Account>> GetAllAccounts(bool isCategory);
        Task<List<Account>> GetAllAccounts();
        Task SaveTransaction(Transaction transaction);
        Task<List<Budget>> GetAllBudget();
        Task<List<Transaction>> getRelatedTransactions(int account);
        Task<Account> GetAccountById(int id);
        Task SavePlan(Plan plan);
        Task<IList<Plan>> GetBudgetPlans(int budgetId);
        Task<Budget> GetBudgetById(int id);
        Task<Plan> GetPlanById(int id);
        Task<decimal> GetAvailableAmountOfAccount(int account);
    }
}
