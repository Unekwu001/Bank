using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Transactions
	{
		//Deposit fields
		string AccountToDepositTo;
		string AmountToDeposit;
		decimal CleanAmountToDeposit;


		//Withdraw fields
		string AmountToWithdraw;
		string AccountToWithdrawFrom;
		decimal CleanAmountToWithdraw;


		//transfer fields
		string AccountToTransferTo;
		string AccountToTransferFrom;
		decimal CleanAmountToTransfer;


		//Check Balance fields
		string AccountToCheckBalance;



		public void Deposit()
		{
			var dash = new DashBoard();
			dash.ShowAllAccount();

			Console.Write("Type in the account number you want to send money to.>>");
			AccountToDepositTo = Console.ReadLine();

			Console.WriteLine("Enter the amount you want to send");
			AmountToDeposit = Console.ReadLine().Trim();
			CleanAmountToDeposit = decimal.Parse(AmountToDeposit);

			Account accountToUpdate = DashBoard.accounts.FirstOrDefault(account => account.AccountNumber == AccountToDepositTo);

			if(accountToUpdate is null)
			{
				Console.WriteLine("The account entered does not exist!\nPlease enter a valid account number>>");
				dash.ShowAllAccount();
			}

			else if(accountToUpdate != null)
			{
				accountToUpdate.Balance += CleanAmountToDeposit;
				Console.WriteLine($"You have successfully deposited {CleanAmountToDeposit} into your account with account number {AccountToDepositTo}");
				dash.PromptToViewAccount();
			}
		}





		public void Withdraw()
		{
			var dash = new DashBoard();
			dash.ShowAllAccount();

			Console.Write("Here are your accounts above.\n Type in the account number you want to WithDraw from>>.");
			AccountToWithdrawFrom = Console.ReadLine();

			Console.Write("Enter the amount you want to Withdraw>>");
			AmountToWithdraw = Console.ReadLine();
			CleanAmountToWithdraw = decimal.Parse(AmountToWithdraw);

			Account accountToUpdate = DashBoard.accounts.FirstOrDefault(account => account.AccountNumber == AccountToWithdrawFrom);
			if(accountToUpdate is null)
			{
				Console.Clear();
				Console.WriteLine("\n\nThe account entered does not exist!\nPlease enter a valid account number\n");
				dash.PromptToViewAccount();

			}
			else if (accountToUpdate.AccountType == "savings" && accountToUpdate.Balance < 1001 )
			{
				Console.Clear();
				Console.WriteLine("\n\nUnable to withdraw. There should be a minimum of 1000 naira in your savings account \n");
				dash.PromptToViewAccount();
			}
			else if (accountToUpdate.Balance <  CleanAmountToWithdraw  )
			{
				Console.Clear();
				Console.WriteLine("\n\nInsufficient Funds!, Kindly try a lesser amount.\n");
				dash.PromptToViewAccount();
			}
			else
			{
				accountToUpdate.Balance -= CleanAmountToWithdraw;
				Console.WriteLine($"\nYou have successfully withdrawn {CleanAmountToWithdraw} from your account with account number {AccountToWithdrawFrom}");
				dash.PromptToViewAccount();
				 
			}
			 
		}






		public void Transfer()
		{

			var dash = new DashBoard();
			dash.ShowAllAccount();
			Console.WriteLine("----------Transfers-----------");


			Console.Write("Enter the account number you are  TRANSFERING FROM:>> ");
			AccountToTransferFrom = Console.ReadLine();

			Console.Write("Enter the account you want to TRANSFER TO:>> ");
			AccountToTransferTo = Console.ReadLine();

			Console.Write("Enter the amount you want to transfer:>> ");
			string AmountToTransfer = Console.ReadLine();

			CleanAmountToTransfer = decimal.Parse(AmountToTransfer);

			Account giver = DashBoard.accounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferFrom);
			Account receiver = DashBoard.accounts.FirstOrDefault(account => account.AccountNumber == AccountToTransferTo);
			


			if(giver != null && receiver != null && giver.AccountType == "savings" && giver.Balance > CleanAmountToTransfer+1000)
			{
				giver.Balance -= CleanAmountToTransfer;
				receiver.Balance += CleanAmountToTransfer;
				Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
				dash.PromptToViewAccount();
			}
			else if(giver != null && receiver != null && giver.AccountType == "current" && giver.Balance > CleanAmountToTransfer)
			{
				giver.Balance -= CleanAmountToTransfer;
				receiver.Balance += CleanAmountToTransfer;
				Console.WriteLine($"{CleanAmountToTransfer} has been Sent to {AccountToTransferTo} successfully!");
				dash.PromptToViewAccount();
			}
			else
			{
				Console.Clear();
				Console.WriteLine($"\n\nError in Transaction!\n\n");
				dash.PromptToViewAccount();
			}
			
			dash.PromptToViewAccount();
		}





		public void CheckBalance()
		{
			Console.Clear();
			var dash = new DashBoard();
			dash.ShowAllAccount();
			Console.WriteLine("----------Check Balance-----------");

			Console.Write("To check your Balance, Enter an account number Here:>> ");
			AccountToCheckBalance = Console.ReadLine();

			Account accountToseeBalance = DashBoard.accounts.FirstOrDefault(account => account.AccountNumber == AccountToCheckBalance);
			if(accountToseeBalance != null)
			{
				Console.WriteLine($" The account balance for account Number {AccountToCheckBalance} is {accountToseeBalance.Balance}");
				dash.PromptToViewAccount();
			}
			else 
			{ 
				Console.Clear(); 
				Console.WriteLine("\n\nAn Error Occured!, Please try again.");
				dash.PromptToViewAccount();
			}
		}
	}
}
