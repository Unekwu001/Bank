using Bank;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class DashBoard : Login
	{
		public static List<Account> accounts = new List<Account>();

	
		public string accNo = "";
		public decimal accBal = 0;
		public string accType = "";
		 
		

		public void ShowMenu()
		{
			Console.WriteLine($"---{accounts[0].Fullname}'s--DASHBOARD------\n");
			Console.WriteLine($"Welcome, dear {accounts[0].Fullname}.\nWhat would you like to do today ?");
			Console.WriteLine(">Press 1 Create Account");
			Console.WriteLine(">Press 2 to Deposit");
			Console.WriteLine(">Press 3 to Withdraw");
			Console.WriteLine(">Press 4 Transfer");
			Console.WriteLine("Press 5 to get balance");
			Console.WriteLine("Press 6 to get your Statement");
			Console.WriteLine("Press 7 to Logout\n\n");
			Console.Write("Select an option: ");

			string mychoice;
			bool isValidChoice = false;
			var transact = new Transactions();
			do
			{
				mychoice = Console.ReadLine();

				if (mychoice == "1")
				{
					Create2ndAccount();
					isValidChoice = true;
				}
				else if (mychoice == "2")
				{
					transact.Deposit();
				}
				else if (mychoice == "3")
				{
					transact.Withdraw();
				}
				else if (mychoice == "4")
				{
					transact.Transfer();
				}
				else if (mychoice == "5")
				{
					transact.CheckBalance();
				}
				else if (mychoice == "7")
				{
					LogOut.LogMeOut();
				}

			} while (!isValidChoice);
		}

		private void Create2ndAccount()
		{
			Console.Clear();
			
			selectAccType();
			GenerateAnotherAccountNo();
			SaveCreatedAccDetails();
			PromptToViewAccount();
			




			void selectAccType()
			{			
				Console.WriteLine(" Please Enter your desired account type\n");
				Console.WriteLine(">  Press 1 for savings account\n>  Press 2 for current account  ");
				string input = Console.ReadLine();


				if (input == "" || input is null || !int.TryParse(input, out _))
				{
					Console.Clear();
					Console.WriteLine("You have entered an incorrect command. Please Retry");
					selectAccType();
				}
				else if (input == "1")
				{
					accType = "savings";
					Console.WriteLine("You need to deposit at least 1000 naira to open such an account");
					Console.Write("Please enter an amount greater or equal to 1000 naira: ");

					string enteredAmount;
					enteredAmount = Console.ReadLine();
							
					if(enteredAmount is null || enteredAmount == " " || !int.TryParse(enteredAmount,out _) || int.Parse(enteredAmount) < 1000)  
					{
						Console.WriteLine($"Invalid amount!. You need to enter an amount greater then 1000 naira. ");
						Console.WriteLine($"Process Restarted !");
						selectAccType();
					}							
					else if (int.Parse(enteredAmount) > 999)
					{
						decimal cleanAmount = decimal.Parse(enteredAmount);
						accBal = cleanAmount;
						Console.WriteLine($"You have successfully added {cleanAmount} naira");
					}
				}
				else if (input == "2")
				{
					accType = "current";
					accBal = 0;
					Console.WriteLine($"You have successfully created a new account.\nYour account number is >> {accNo}\n ");
					
				}
				
			}




			void GenerateAnotherAccountNo()
			{
			Random random = new Random();
			var i = random.Next(1000000000, 2099999999); //tells the range of random numbers you want to generate.
			accNo = i.ToString();
			Console.WriteLine($"Here is your generated Account Number!>> {accNo}");
			}


			void SaveCreatedAccDetails()
			{
				Account AnotherAccount = new Account(cusFullname, accNo, accType, accBal);
				if (!accounts.Contains(AnotherAccount))
				{
					accounts.Add(AnotherAccount);
					Console.WriteLine("Your details have Successfully created!");
				}
			}
			
		}



		public void PromptToViewAccount()
		{
			string choice;
			bool isValid;
			do
			{
				Console.WriteLine("\n>>To view all your accounts press Y \n>>To go back to your Menu Press N");
				choice = Console.ReadLine();
				if (choice == "Y" || choice == "y")
				{
					isValid = true;
					ShowAllAccount();
				}
				else if (choice == "N" || choice == "n")
				{
					isValid = true;
					Console.Clear();	
					Console.WriteLine("You have been redirected to your Dashboard.\n");
					ShowMenu();
				}
				else
				{
					isValid = false;
					Console.WriteLine(" Invalid input! ");
					Console.WriteLine("Please choose either 'Y' or 'N' when prompted again ?");
				}
			} while (isValid);

		}





		public void ShowAllAccount()
		{
			string allprints = "";
			foreach (Account acc in accounts)
			{
				allprints += $"|     {acc.Fullname,-15}|   {acc.AccountNumber,-15}|     {acc.AccountType,-15}|      {acc.Balance,-16}|\n";			
			}
			Console.WriteLine("|--------------------|------------------|--------------------|----------------------|");
			Console.WriteLine("|     FULLNAME       |  ACCOUNT NUMBER  |   ACCOUNT TYPE     |   ACCOUNT BALANCE    |");
			Console.WriteLine("|--------------------|------------------|--------------------|----------------------|");
			Console.WriteLine(allprints);
			Console.WriteLine("------------------------------------------------------------------------------------");
		}				
	}
}

 
			 
