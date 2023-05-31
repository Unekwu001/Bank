using Bank;
using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Bank_app
{
	internal class Program
	{
 
		
		public static string choice;
 
		static void Main(string[] args)
		{
			
			Controller();
			
		}

      //------------------------------------------------------------------------------------------------
		
		//The controller
		public static void Controller()
		{
			
			do
			{
				Console.Clear();
				Console.WriteLine("Welcome to Shazam Bank\n\n\n>Press 1 To Register\n\n>Press 2 To login\n\n>Press 3 To Exit.\n\n ");
				choice = Console.ReadLine();
				
				if (choice == "1")
				{
					var customa = new Register();
					customa.Registration();
					
				}
				if (choice == "2")
				{
				
					Console.Clear();
					var mylogin = new Login();
					mylogin.ApproveLogin();
				}
				if (choice == "3")
				{

					Console.Clear();
					LogOut.LogMeOut();
				}

			}
			while (!int.TryParse(choice, out _) || int.Parse(choice) != 1 || int.Parse(choice) != 2 || int.Parse(choice) != 3);		
		}
	}
}
