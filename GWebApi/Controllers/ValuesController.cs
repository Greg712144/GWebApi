using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using GWebApi.Models;
using Newtonsoft.Json;
using RouteAttribute = System.Web.Http.RouteAttribute;
using RoutePrefixAttribute = System.Web.Http.RoutePrefixAttribute;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using HttpGetAttribute = System.Web.Http.HttpGetAttribute;
using HttpPutAttribute = System.Web.Http.HttpPutAttribute;
using HttpDeleteAttribute = System.Web.Http.HttpDeleteAttribute;

namespace GWebApi.Controllers
{
    /// <summary>
    /// Name of API Controller
    /// </summary>
    [RoutePrefix("api")]
    public class ValuesController : ApiController
    {
        private GWebDbContext db = new GWebDbContext();

        /// <summary>
        /// Gives ability to add a new household
        /// </summary>
        /// <param name="name">Input New Household Name</param>
        /// <returns>Add New House</returns>
        [Route("AddHousehold")]
        [HttpPost]
        public async Task<IHttpActionResult> AddHousehold(string name)
        {

            return Ok(JsonConvert.SerializeObject(await db.Addhousehold(name)));
        }

        /// <summary>
        /// Retrieves All Accounts Data
        /// </summary>
        /// <returns>List of All Account Data</returns>
        [Route("AllAccounts")]
        public Task<List<Account>> AllAccounts()
        {
            //return db.Households.ToList();
            return db.AllAccounts();

        }

        /// <summary>
        /// Gives Ability to Add a New Account
        /// </summary>
        /// <param name="houseId">Input Household Id</param>
        /// <param name="name">Input Name</param>
        /// <param name="initialbalance">Enter Initial Balance w/ cents</param>
        /// <param name="currentbalance">Enter Current Balance w/ cents</param>
        /// <param name="reconciledbalance">Enter Reconciled Balance w/ cents</param>
        /// <param name="lowbalancelevel">Enter Low Level Balance w/ cents</param>
        /// <returns>Add New Account</returns>
        [Route("AddAccount")]
        [HttpPost]
        public async Task<IHttpActionResult> AddAccount(int houseId, string name, decimal initialbalance, decimal currentbalance, decimal reconciledbalance, decimal lowbalancelevel)
        {

            return Ok(JsonConvert.SerializeObject(await db.AddAccount(houseId, name, initialbalance, currentbalance, reconciledbalance, lowbalancelevel)));
        }

        /// <summary>
        /// Gives Ability to Add a New Budget
        /// </summary>
        /// <param name="houseId">Input Household Id</param>
        /// <param name="name">Input Name</param>
        /// <param name="description">Input Description</param>
        /// <returns>Add New Budget</returns>
        [Route("AddBudget")]
        [HttpPost]
        public async Task<IHttpActionResult> AddBudget(int houseId, string name, string description)
        {

            return Ok(JsonConvert.SerializeObject(await db.AddBudget(houseId, name, description)));
        }

        /// <summary>
        /// Gives Ability to Add New BudgetItem
        /// </summary>
        /// <param name="budgetId">Input the Budget Id</param>
        /// <param name="name">Input Name</param>
        /// <param name="description">Input Description</param>
        /// <param name="targetamount">Enter Target Amount w/ cents</param>
        /// <param name="currentamount">Enter Current Amount w/ cents</param>
        /// <returns>Add New BudgetItem</returns>
        [Route("AddBudgetItem")]
        [HttpPost]
        public async Task<IHttpActionResult> AddBudgetItem(int budgetId, string name, string description, decimal targetamount, decimal currentamount)
        {

            return Ok(JsonConvert.SerializeObject(await db.AddBudgetItem(budgetId, name, description, targetamount, currentamount)));
        }

        /// <summary>
        /// Gives ability to add a new Transaction
        /// </summary>
        /// <param name="accountId">Input the Account Id</param>
        /// <param name="budgetitemId">Input the BudgetItem Id</param>
        /// <param name="enteredbyId">Input who entered the transaction</param>
        /// <param name="description">Input the description</param>
        /// <param name="amount">Input the Amount w/ cents</param>
        /// <param name="type">Choose Deposit/Withdrawal</param>
        /// <returns>Add New Transaction</returns>
        [Route("AddTransactions")]
        [HttpPost]
        public async Task<IHttpActionResult> AddTransaction(int accountId, int budgetitemId, string enteredbyId, string description, decimal amount, TransactionType type)
        {
            //var json = JsonConvert.SerializeObject(db.Households.ToList());

            return Ok(JsonConvert.SerializeObject(await db.AddTransaction(accountId, budgetitemId, enteredbyId, description, amount, type)));
        }


        /// <summary>
        /// Retrieve all household data
        /// </summary>
        /// <remarks>We need to add a few more housholds..</remarks>
        /// <returns>List of Households</returns>
        [Route("GetHousehold")]
        public Task<List<Household>> GetHouseholds()
        {
            //return db.Households.ToList();
           return db.AllHouseholds();

        }


        /// <summary>
        /// Retrieve All Transaction Data
        /// </summary>
        /// <returns>List of All Transactions</returns>
        [Route("GetTransactions")]
        public Task<List<Transaction>> GetTransactions()
        {
            //return db.Households.ToList();
            return db.AllTransactions();

        }

        /// <summary>
        /// Retrieves Transaction Under Specific Account by Id
        /// </summary>
        /// <param name="accountId">Input the Account Id</param>
        /// <returns>List of Transactions by Account Id</returns>
        [Route("GetTransactionsByAccountId")]
        public Task<List<Transaction>> GetTransactionsByAccountId(int accountId)
        {
            //return db.Households.ToList();
            return db.AllTransactionsByAccountId(accountId);

        }

        /// <summary>
        /// Retrieve Transaction Details by Id
        /// </summary>
        /// <param name="tranId">Input the PK of the Transaction</param>
        /// <returns>List of Transaction by Id</returns>
        [Route("GetTransactionDetails")]
        public Task<List<Transaction>> GetTransactionDetails(int tranId)
        {
            //return db.Households.ToList();
            return db.GetTransactionDetails(tranId);

        }

      

        /// <summary>
        /// Retrieves All Budgets Data
        /// </summary>
        /// <returns>List of Budgets</returns>
        [Route("GetBudgets")]
        public Task<List<Budget>> GetBudgets()
        {
            //return db.Households.ToList();
            return db.AllBudgets();

        }

        /// <summary>
        /// Retrieves All Budgets By Specific Household Id
        /// </summary>
        /// <param name="houseId">Input the PK of the Household</param>
        /// <returns>List of Budgets by Household Id</returns>
        [Route("GetBudgetsByHouseId")]
        public Task<List<Budget>> GetBudgetsByHouseId(int houseId)
        {
            //return db.Households.ToList();
            return db.GetBudgetsByHouseId(houseId);

        }

        /// <summary>
        /// Retrieves Budget Details By Id
        /// </summary>
        /// <param name="budgetId">Input the PK of the Budget</param>
        /// <returns>List of Budget Details by Id</returns>
        [Route("GetBudgetDetails")]
        public Task<List<Budget>> GetBudgetDetails(int budgetId)
        {
            //return db.Households.ToList();
            return db.GetBudgetDetailsById(budgetId);

        }

       

        /// <summary>
        /// Retrieves All BudgetItems Data
        /// </summary>
        /// <returns>Lists of all BudgetItems</returns>
        [Route("GetBudgetItems")]
        public Task<List<BudgetItem>> GetBudgetItems()
        {
            //return db.Households.ToList();
            return db.AllBudgetItems();

        }

        /// <summary>
        /// Retrieves All BudgetItems By Budget Id
        /// </summary>
        /// <param name="budgetId">Input the Budget Id</param>
        /// <returns>List of BudgetItems by BudgetId</returns>
        [Route("GetAllBudgetItemsByBudgetId")]
        public Task<List<BudgetItem>> GetAllBudgetItemsByBudgetId(int budgetId)
        {
            //return db.Households.ToList();
            return db.AllBudgetItemsByBudgetId(budgetId);

        }

        /// <summary>
        /// Retrieve BudgetItem Details by Id
        /// </summary>
        /// <param name="budId">Input the BudgetItem Id</param>
        /// <returns>List of BudgetItems by Id</returns>
        [Route("GetBudgetItemDetails")]
        public Task<List<BudgetItem>> GetBudgetItemDetailsByBudgetId(int budId)
        {
            //return db.Households.ToList();
            return db.GetBudgetItemDetails(budId);

        }

       

        /// <summary>
        /// Retrieves Accounts by Household Id
        /// </summary>
        /// <param name="houseId">Input the Household Id</param>
        /// <returns>List of Accounts by Household Id</returns>
        [Route("GetAccounts")]
        public Task<List<Account>> GetAccounts(int houseId)
        {
            //return db.Households.ToList();
            return db.GetAccounts(houseId);

        }

        /// <summary>
        /// Retrieves Account Details by Id
        /// </summary>
        /// <param name="accountId">Input the PK of the Account</param>
        /// <returns>List of Account Details by Id</returns>
        [Route("GetAccountDetails")]
        public Task<List<Account>> GetAccountDetails(int accountId)
        {
            //return db.Households.ToList();
            return db.GetAccountDetails(accountId);

        }

        /// <summary>
        /// Edit a Budget
        /// </summary>
        /// <param name="budgetId">Input the PK of the Budget</param>
        /// <param name="name">Input New Name</param>
        /// <param name="description">Input New Description</param>
        [HttpPut]
        [Route("EditBudget")]
        public async Task<IHttpActionResult>EditBudget(int budgetId, string name, string description)
        {
            return Ok(JsonConvert.SerializeObject(await db.EditBudget(budgetId, name, description)));
        }

        /// <summary>
        /// Performs Deletion of Budget Item by Id
        /// </summary>
        /// <param name="Id">Input the PK of the BudgetItem</param>
        [HttpDelete]
        [Route("DeleteBudgetItem")]
        public async Task<IHttpActionResult> Delete(int Id)
        {
            return Ok(JsonConvert.SerializeObject(await db.DeleteBudgetItemById(Id)));
        }
   
    }
}
