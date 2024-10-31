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
    public partial class AccountContent
    {
        [Parameter]
        public string accid { get; set; }
        private int accountId { get; set; }

        private List<Transaction> transactions { get; set; } = new List<Transaction>(); 
        private Account account { get; set; } = new Account();

        protected override async Task OnInitializedAsync()
        {
            accountId = Int32.Parse(accid);
            transactions = await _dbService.getRelatedTransactions(accountId);
            account = await _dbService.GetAccountById(accountId);
            StateHasChanged();
        }
    }
}
