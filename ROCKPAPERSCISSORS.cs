

//ROCK PAPER SCISSORS
//1. ACCEPT USER INPUT IN VARIOUS WAYS.
//2. GENERATE A RANDOM CHOICE 
//3.COMPARE THE CHOICES
//4. DECLARE A WINNER
//5.OPTIMIZE AFTERWARDS


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Math;

namespace ROCKPAPERSCISSORS
{
	class Program
	{
		static void Main(string[] args)
		{
			string inputPlayer, inputCPU;
			int randomInt;
			
			Console.Write("Choose between ROCK, PAPER and SCISSORS: ");
			inputPlayer = Console.ReadLine();
			
			Random rnd = new Random();
			
			randomInt = rnd.Next(1,4);
		}
	}
}