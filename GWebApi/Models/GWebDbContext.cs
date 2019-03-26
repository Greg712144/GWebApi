using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace GWebApi.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class GWebDbContext : DbContext
    {
        /// <summary>
        /// 
        /// </summary>
        public GWebDbContext()
            : base("FinConnect")
        { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static GWebDbContext Create ()
        {
            return new GWebDbContext();
        }

        /// <summary>
        /// Collection of All Household Data
        /// </summary>
        /// <returns>List of Households</returns>
        public async Task<List<Household>> AllHouseholds ()
        {
            return await Database.SqlQuery<Household>("AllHouseholds").ToListAsync();
        }

        /// <summary>
        /// Collection of All Budget Data
        /// </summary>
        /// <returns>List of Budgets</returns>
        public async Task<List<Budget>> AllBudgets()
        {
            return await Database.SqlQuery<Budget>("AllBudgets").ToListAsync();
        }

        /// <summary>
        /// Collection of Budgets By Household Id
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns>List of Budgets by Household Id</returns>
        public async Task<List<Budget>> GetBudgetsByHouseId(int houseId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetsByHouseId @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }

        /// <summary>
        /// Collection of Budget Details by Id
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns>List of Budget Details by Id</returns>
        public async Task<List<Budget>> GetBudgetDetailsById(int budgetId)
        {
            return await Database.SqlQuery<Budget>("GetBudgetDetailsById @budgetId",
                new SqlParameter("budgetId", budgetId)).ToListAsync();
        }

        /// <summary>
        /// Collection of All BudgetItem Data
        /// </summary>
        /// <returns>Lists of all BudgetItems</returns>
        public async Task<List<BudgetItem>> AllBudgetItems()
        {
            return await Database.SqlQuery<BudgetItem>("AllBudgetItems").ToListAsync();
        }

        /// <summary>
        /// Collection of BudgetItems by Budget Id
        /// </summary>
        /// <param name="budgetId"></param>
        /// <returns>List of BudgetItems by BudgetId</returns>
        public async Task<List<BudgetItem>> AllBudgetItemsByBudgetId(int budgetId)
        {
            return await Database.SqlQuery<BudgetItem>("BudgetItemsByBudgetId @budgetId",
                new SqlParameter("budgetId", budgetId)).ToListAsync();
        }

        /// <summary>
        /// Collection of BudgetItem Details by Id
        /// </summary>
        /// <param name="budId"></param>
        /// <returns>List of BudgetItems by Id</returns>
        public async Task<List<BudgetItem>> GetBudgetItemDetails(int budId)
        {
            return await Database.SqlQuery<BudgetItem>("GetBudgetItemDetailsByBudId @budId",
                new SqlParameter("budId", budId)).ToListAsync();
        }

        /// <summary>
        /// Collection of All Accounts Data
        /// </summary>
        /// <returns>List of All Account Data</returns>
        public async Task<List<Account>> AllAccounts()
        {
            return await Database.SqlQuery<Account>("AllAccounts").ToListAsync();
        }

        /// <summary>
        /// Collection of Accounts by Household Id
        /// </summary>
        /// <param name="houseId"></param>
        /// <returns>List of Accounts by Household Id</returns>
        public async Task<List<Account>> GetAccounts(int houseId)
        {
            return await Database.SqlQuery<Account>("GetAccounts @houseId",
                new SqlParameter("houseId", houseId)).ToListAsync();
        }

        /// <summary>
        /// Collection of Account Details By Account Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>List of Account Details by Id</returns>
        public async Task<List<Account>> GetAccountDetails(int accountId)
        {
            return await Database.SqlQuery<Account>("GetAccountDetails @accountId",
                new SqlParameter("accountId", accountId)).ToListAsync();
        }

        /// <summary>
        /// Collection of All Transaction Data
        /// </summary>
        /// <returns>List of All Transactions</returns>
        public async Task<List<Transaction>> AllTransactions()
        {
            return await Database.SqlQuery<Transaction>("GetTransactions").ToListAsync();
        }

        /// <summary>
        /// Collection of Transactions by Account Id
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns>List of Transactions by Account Id</returns>
        public async Task<List<Transaction>> AllTransactionsByAccountId(int accountId)
        {
            return await Database.SqlQuery<Transaction>("TransactionsByAccountId @accountId",
                new SqlParameter("@accountId", accountId)).ToListAsync();
        }

        /// <summary>
        /// Collection of Transaction Details by Id
        /// </summary>
        /// <param name="tranId"></param>
        /// <returns>List of Transaction by Id</returns>
        public async Task<List<Transaction>> GetTransactionDetails(int tranId)
        {
            return await Database.SqlQuery<Transaction>("GetTransactionDetails @tranId",
                new SqlParameter("tranId", tranId)).ToListAsync();
        }

        /// <summary>
        /// Addition of Transaction
        /// </summary>
        /// <param name="AccountId"></param>
        /// <param name="BudgetItemId"></param>
        /// <param name="EnteredbyId"></param>
        /// <param name="Description"></param>
        /// <param name="Amount"></param>
        /// <param name="Type"></param>
        /// <returns>Add New Transaction</returns>
        public async Task<int> AddTransaction(int AccountId, int BudgetItemId, string EnteredbyId, string Description, decimal Amount, TransactionType Type)
        {
            return await Database.ExecuteSqlCommandAsync("AddTransaction @accountId, @budgetitemId, @enteredbyId, @description, @amount, @type ",
            new SqlParameter("accountId", AccountId),
            new SqlParameter("budgetitemId", BudgetItemId),
            new SqlParameter("enteredbyId", EnteredbyId),
            new SqlParameter("description", Description),
            new SqlParameter("amount", Amount),
            new SqlParameter("type", Type));

        }

        /// <summary>
        /// Addition of Account
        /// </summary>
        /// <param name="houseId"></param>
        /// <param name="name"></param>
        /// <param name="initialbalance"></param>
        /// <param name="currentbalance"></param>
        /// <param name="reconciledbalance"></param>
        /// <param name="lowbalancelevel"></param>
        /// <returns>Add New Account</returns>
        public async Task<int> AddAccount(int houseId, string name, decimal initialbalance, decimal currentbalance, decimal reconciledbalance, decimal lowbalancelevel )
        {
            return await Database.ExecuteSqlCommandAsync("AddMyAccount @houseId, @name, @initialbalance, @currentbalance, @reconciledbalance, @lowbalancelevel ",
            new SqlParameter("houseId", houseId),
            new SqlParameter("name", name),
            new SqlParameter("initialbalance", initialbalance),
            new SqlParameter("currentbalance", currentbalance),
            new SqlParameter("reconciledbalance", reconciledbalance),
            new SqlParameter("lowbalancelevel", lowbalancelevel));

        }

        /// <summary>
        /// Addition of Budget
        /// </summary>
        /// <param name="houseId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns>Add New Budget</returns>
        public async Task<int> AddBudget(int houseId, string name, string description)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudgets @houseId, @name, @description",
            new SqlParameter("houseId", houseId),
            new SqlParameter("name", name),
            new SqlParameter("description", description));
           

        }
        /// <summary>
        /// Edit Budget Data
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns>Edit a Budget Item by Id</returns>
        public async Task<int> EditBudget(int budgetId, string name, string description)
        {
            return await Database.ExecuteSqlCommandAsync("EditBudget @budgetId, @name, @description",
            new SqlParameter("budgetId", budgetId),
            new SqlParameter("name", name),
            new SqlParameter("description", description));


        }

        /// <summary>
        /// Addition of BudgetItem
        /// </summary>
        /// <param name="budgetId"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="targetamount"></param>
        /// <param name="currentamount"></param>
        /// <returns>Add New BudgetItem</returns>
        public async Task<int> AddBudgetItem(int budgetId, string name, string description, decimal targetamount, decimal currentamount)
        {
            return await Database.ExecuteSqlCommandAsync("AddBudgetItem @budgetId, @name, @description, @targetamount, @currentamount ",
            new SqlParameter("budgetId", budgetId),
            new SqlParameter("name", name),
            new SqlParameter("description", description),
            new SqlParameter("targetamount", targetamount),
            new SqlParameter("currentamount", currentamount));

        }

        /// <summary>
        /// Performs Deletion of Budget Item by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns>Deletes a Budget Item by Id</returns>
        public async Task<int> DeleteBudgetItemById(int Id)
        {
            return await Database.ExecuteSqlCommandAsync("DeleteBudgetItem @Id",
            new SqlParameter("Id", Id));


        }

        /// <summary>
        /// Addition of Household
        /// </summary>
        /// <param name="name"></param>
        /// <returns>Add New Household</returns>
        public async Task<int> Addhousehold(string name)
        {
            return await Database.ExecuteSqlCommandAsync("AddHouse @name ",
            new SqlParameter("name", name));

        }
    }
}