using SmartWalletHybrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Components.Pages
{
    public partial class Home
    {
        private List<Account> accounts = new List<Account>();
        private List<Account> categories = new List<Account>();
        private List<Budget> budgets = new List<Budget>();

        protected async override Task OnInitializedAsync()
        {
            accounts = await _dbService.GetAllAccounts(false);
            categories = await _dbService.GetAllAccounts(true);
            budgets = await _dbService.GetAllBudget();
            StateHasChanged();
        }

        private void NavigateBudget()
        {
            _navigationManager.NavigateTo("/budget");
        }

        private void NavigateCategory()
        {
            _navigationManager.NavigateTo("/account-new/acc");
        }

        private void NavigateAccount()
        {
            _navigationManager.NavigateTo("/account-new/cat");
        }

        private void NavigateTransaction()
        {
            _navigationManager.NavigateTo("/transaction/0");
        }
    }
}
