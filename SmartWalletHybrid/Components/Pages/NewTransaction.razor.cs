using BlazorBootstrap;
using Microsoft.AspNetCore.Components;
using SmartWalletHybrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWalletHybrid.Components.Pages
{
    public partial class NewTransaction
    {
        [Parameter]
        public string? plan { get; set; } = string.Empty;
        private string title {  get; set; } = string.Empty;
        private DateTime transDate { get; set; } = DateTime.Today;
        private decimal transAmount { get; set; } = 0;
        private Account fromAccount { get; set; } = new Account();
        private Account toAccount { get; set; } = new Account();
        private bool isFromAcc = false;
        private bool isToAcc = false;
        private Plan planData = new Plan();

        private Modal accountModal;

        private List<Account> accounts = new List<Account>();

        protected override async Task OnInitializedAsync()
        {
            accounts = await _dbService.GetAllAccounts();
            var pln = 0;
            if (plan != null && !plan.Equals("0"))
            {
                pln = Int32.Parse(plan);
                planData = await _dbService.GetPlanById(pln);
                title = planData.Name;
            }
            StateHasChanged();
        }

        private async Task OpenFromAccount()
        {
            isFromAcc = true;
            await accountModal?.ShowAsync();
        }

        private async Task OpenToAccount()
        {
            isToAcc = true;
            await accountModal?.ShowAsync();
        }

        private async Task SaveAccount(Account account)
        {
            if (isFromAcc)
            {
                fromAccount = account;
            }
            else
            {
                toAccount = account;
            }
            await OnHideModalClick();
            StateHasChanged();
        }

        private async Task OnHideModalClick()
        {
            await accountModal?.HideAsync();
            isFromAcc = false;
            isToAcc = false;
            StateHasChanged();
        }

        private async Task onsaveTransactionClick()
        {
            var pln = 0;
            if(plan != null)
            {
                pln = Int32.Parse(plan);
            }
            Transaction transaction = new Transaction()
            {
                Title = title,
                FromAccount = fromAccount.Id,
                ToAccount = toAccount.Id,
                Amount = transAmount,
                TransDate = transDate,
                Plan = pln
            };
            await _dbService.SaveTransaction(transaction);
            title = string.Empty;
            fromAccount = new Account();
            toAccount = new Account();
            transAmount = 0;
            transDate = DateTime.Today;
            StateHasChanged();
        }
    }
}
