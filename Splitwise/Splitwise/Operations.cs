using Splitwise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Splitwise
{
    public class Operations
    {
        public List<string> PerformOperation(string input, List<User> userList)
        {
            List<string> result = new List<string>();
            string[] entries = input.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            OperationsEnum op;
            Enum.TryParse(entries[0].ToUpper(), out op);
            if (op != 0)
            {
                if (op == OperationsEnum.EXPENSE)
                {
                    try
                    {
                        int currentIndex = 1;
                        User userPaid = userList.Where(x=>(x.userId== entries[currentIndex++])).Single();
                        decimal paidAmount = decimal.Parse(entries[currentIndex++]);
                        int borrowers = int.Parse(entries[currentIndex]);
                        List<User> borrowerList = new List<User>() ;
                        for(int i=1;i<=borrowers; i++)
                        {
                            borrowerList.AddRange(userList.Where(x => x.userId == entries[3 + i]));
                            
                        }
                        currentIndex += borrowers + 1;

                        var shareType = Enum.Parse(typeof(ExpenseEnum), entries[currentIndex++]);

                        result.AddRange(SplitExpensesByType(input, currentIndex, userPaid, paidAmount, borrowerList, shareType));

                    }
                    catch (Exception ex)
                    {
                        return new List<string>() { "Invalid entry in operation" };
                    }
                }
                else if(op == OperationsEnum.SHOW)
                {

                }
            }
            else
            {
                result.Add("invalid operation");
            }

            return new List<string>();
        }

        private List<string> SplitExpensesByType(string[] input,int currentIndex, User userPaid,decimal paidAmount,
                                                 List<User> borrowerList,int borrowers,ExpenseEnum shareType)
        {

            if (shareType is ExpenseEnum.EQUAL)
            {
                decimal amountForEach = decimal.Round(paidAmount / borrowers, 2);

                //Add Transactions
                userPaid.transactions = new List<Transaction>();

                Random rand = new Random();
                User randomUser = borrowerList[rand.Next(0, borrowers)];
                borrowerList.Remove(randomUser);
                AllTransactions txnList = new AllTransactions();
                Transaction txn;
                foreach (var borrower in borrowerList)
                {
                    if(userPaid.userId!=borrower.userId)
                    {
                        txn = new Transaction(userPaid.userId, borrower.userId, amountForEach);
                        txnList.txnList.Add(txn);
                    }
                }

                decimal leftAmount = paidAmount - amountForEach * borrowers;
                txn = new Transaction(userPaid.userId, randomUser.userId, leftAmount);
                txnList.txnList.Add(txn);

            }

            else if(shareType is ExpenseEnum.EXACT)
            {

            }
        }
    }
}
