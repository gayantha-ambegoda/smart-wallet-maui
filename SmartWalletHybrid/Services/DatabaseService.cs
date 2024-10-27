using SmartWalletHybrid.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Services
{
    public class DatabaseService : IDatabaseService
    {
        SQLiteAsyncConnection? _connection;

        private async Task Init()
        {
            if (_connection is not null) return;
            _connection = new SQLiteAsyncConnection(Configurations.DatabasePath,Configurations.Flags);
            await _connection.CreateTableAsync<Account>();
            await _connection.CreateTableAsync<Budget>();
            await _connection.CreateTableAsync<Plan>();
            await _connection.CreateTableAsync<Transaction>();
        }


        public async Task SaveAccount(Account account)
        {
            await Init();
            if (_connection is not null)
            {
                await _connection.InsertAsync(account);
            }
        }

        public async Task SaveBudget(Budget budget)
        {
            await Init();
            if(_connection is not null)
            {
                await _connection.InsertAsync(budget);
            }
        }

        public async Task SaveTransaction(Transaction transaction)
        {
            await Init();
            if (_connection is not null)
            {
                await _connection.InsertAsync(transaction);
            }
        }

        public async Task SavePlan(Plan plan)
        {
            await Init();
            if (_connection is not null)
            {
                await _connection.InsertAsync(plan);
            }
        }

        public async Task<IList<Plan>> GetBudgetPlans(int budgetId)
        {
            await Init();
            if (_connection is not null)
            {
                return await _connection.Table<Plan>().Where(x => x.BudgetId == budgetId).ToListAsync();
            }
            else
            {
                return new List<Plan>();
            }
        }

        public async Task<List<Account>> GetAllAccounts(bool isCategory)
        {
            await Init();
            if(_connection is not null)
            {
                return await _connection.Table<Account>().Where(x => x.IsCategory == isCategory).ToListAsync();
            }
            else
            {
                return new List<Account>();
            }
        }
        public async Task<List<Account>> GetAllAccounts()
        {
            await Init();
            if (_connection is not null)
            {
                return await _connection.Table<Account>().ToListAsync();
            }
            else
            {
                return new List<Account>();
            }
        }
        public async Task<List<Budget>> GetAllBudget()
        {
            await Init();
            if (_connection is not null)
            {
                return await _connection.Table<Budget>().ToListAsync();
            }
            else
            {
                return new List<Budget>();
            }
        }

        public async Task<Account> GetAccountById(int id)
        {
            await Init();
            if (_connection is not null)
            {
                return await _connection.Table<Account>().FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return new Account();
            }
        }

        public async Task<List<Transaction>> getRelatedTransactions(int account)
        {
            await Init();
            if (_connection is not null)
            {
                return await _connection.Table<Transaction>().Where(x => x.FromAccount == account || x.ToAccount == account).ToListAsync();
            }
            else
            {
                return new List<Transaction>();
            }
        }

        public async Task<Budget> GetBudgetById(int id)
        {
            await Init();
            if (_connection is not null)
            {
                return await _connection.Table<Budget>().FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return new Budget();
            }
        }

        public async Task<Plan> GetPlanById(int id)
        {
            await Init();
            if (_connection is not null)
            {
                return await _connection.Table<Plan>().FirstOrDefaultAsync(x => x.Id == id);
            }
            else
            {
                return new Plan();
            }
        }
    }
}
