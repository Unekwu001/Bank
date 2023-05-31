using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Login:Register
	{
		public string myemail { get; set; }
		public string mypassword { get; set; }

		public Login()
		{
			myemail = myemail;
			mypassword = mypassword;
			
			
		}

		public void ApproveLogin() // login with email and password
		{
			do
			{
				Console.WriteLine("------SHAZAM BANK LOGIN PORTAL-------");
				Console.Write("Enter your email. (E.G john@gmail.com)>>>");
				myemail = Console.ReadLine();
			} while (!Regex.IsMatch(myemail, emailPattern));


			do
			{
				Console.WriteLine(" Enter your password (Should be 6 characters and should include a special character(@,$,#,&,*)");
				mypassword = Console.ReadLine();
			} while (!Regex.IsMatch(mypassword, passwordPattern));

			VerifyCredentials();

		}





		public void VerifyCredentials()
		{
			string press;
			
			if (cusEmail == myemail && cusPassword == mypassword)
			{
				Console.Clear();
				Console.WriteLine("Successfully Logged in !.\n");
				
				var myDashboard = new DashBoard();
				myDashboard.ShowMenu();
			}
			else
			{
				do
				{
					Console.WriteLine("\n\nInvalid username or password.\n");
					Console.WriteLine("Do you want to try again ?   Y /N");
					press = Console.ReadLine();
					if (press == "Y" || press == "y")
					{
						ApproveLogin();
					}
					else if (press == "n" || press == "N")
					{
						Program.Controller();
					}
					else { Console.WriteLine("Please give it Another Try Champ!"); }
				} while (int.TryParse(press, out _) || press != "Y" || press != "y");
			}
		}
	}
}
