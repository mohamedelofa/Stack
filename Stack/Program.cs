using System.Drawing;
using System.Security.Cryptography;

namespace Stack
{
	internal class Program
	{                          //  0         1        2          3                      4                     5          6            7
		static string[] str = { " Push ", " Pop ", " Top ", " Display All ", " Display specific element "," Size " ,  " Return ", " Exit " };
		static string[] stacks = { " Stack1 ", " Stack2 ", " Stack1 + Stack2 ", " Exit " };
		static int mainHeight = 0;
		static int stackHeight = 0;
		static Stack stack1= default;
		static Stack stack2 = default;
		static void Main(string[] args)
		{
			while(true)
			{
				MainScreen();
				MoveOnMainScreen();
			}
		}

		static void MainScreen()
		{
			Console.Clear();
			int Xspace = Console.WindowWidth / 2;
			int Yspace = Console.WindowHeight / (stacks.Length + 1);
			for (int i = 0; i < stacks.Length; i++)
			{
				if (i == mainHeight)
					Console.BackgroundColor = ConsoleColor.Green;
				Console.SetCursorPosition(Xspace, Yspace * (i + 1));
				Console.WriteLine(stacks[i]);
				Console.ResetColor();
			}
		}

		static void MoveOnMainScreen()
		{
			switch(Console.ReadKey().Key)
			{
				case ConsoleKey.UpArrow:
					if (mainHeight == 0)
						mainHeight = stacks.Length - 1;
					else
						mainHeight--;
					break;
				case ConsoleKey.DownArrow:
					if (mainHeight == stacks.Length - 1)
						mainHeight = 0;
					else
						mainHeight++;
					break;
				case ConsoleKey.Enter:
					Console.Clear();
					stackHeight = 0;
					switch(mainHeight)
					{
						case 0:
							if(stack1 is null)
							{
								Console.Write($"Enter size of stack 1 : ");
								int stack1Size = int.Parse(Console.ReadLine());
								stack1 = new Stack(stack1Size);
							}
							StackScreen(1);
							MoveOnStackScreen(stack1 , 1);
							break;
						case 1:
                            if (stack2 is null)
                            {
								Console.Write($"Enter size of stack 2 : ");
								int stack2Size = int.Parse(Console.ReadLine());
								stack2 = new Stack(stack2Size);
							}
							StackScreen(2);
							MoveOnStackScreen(stack2 , 2);
							break;
						case 2:
							if(stack1 is null || stack2 is null || stack1.Top == 0 || stack2.Top == 0)
							{
								Console.WriteLine($"Stack1 or Stack2 should not be empty.....");
								Console.Write("Enter any key to return : ");
								Console.ReadKey();
							}
							else
							{
								Stack stack3 = stack1 + stack2;
								StackScreen(3);
								MoveOnStackScreen(stack3, 3);
							}
							break;
						case 3:
							System.Environment.Exit(0);
							break;
					}
					break;
			}
		}


		static void StackScreen(int stacknumber)
		{
			Console.Clear();
			Console.SetCursorPosition(Console.WindowWidth / 2, 0);
			Console.WriteLine($"Stack {stacknumber}");
			for(int i = 0; i < str.Length; i++)
			{
				if(i == stackHeight)
					Console.BackgroundColor= ConsoleColor.Green;
				Console.WriteLine(str[i]);
				Console.ResetColor();
			}
			//Console.ReadKey();
		}


		static void MoveOnStackScreen(Stack stack , int stacknumber)
		{
			while(true)
			{
				switch (Console.ReadKey().Key)
				{
					case ConsoleKey.UpArrow:
						if (stackHeight == 0)
							stackHeight = str.Length - 1;
						else
							stackHeight--;
						break;
					case ConsoleKey.DownArrow:
						if (stackHeight == str.Length - 1)
							stackHeight = 0;
						else
							stackHeight++;
						break;
					case ConsoleKey.Enter:
						Console.Clear();
						switch(stackHeight)
						{
							case 0:
								Console.Write($"Enter value : ");
								int value = int.Parse(Console.ReadLine());
								stack.Push(value);
								Console.Write("Enter any key to return : ");
								Console.ReadKey();
								break;
							case 1:
								//Console.Clear();
								int v = stack.Pop();
								if (v == -1)
									Console.WriteLine("No number to pop");
								else
								{
									Console.WriteLine($"Number {v} is poped");
								}
								Console.Write("Enter any key to return : ");
								Console.ReadKey();
								break;
							case 2:
								//Console.Clear();
								int last = stack.Last();
								if (last == -1)
									Console.WriteLine("No number exist");
								else
								{
									Console.WriteLine($"Number {last} is Top");
								}
								Console.Write("Enter any key to return : ");
								Console.ReadKey();
								break;
							case 3:
								//Console.Clear();
								if (stack.Top == 0)
								{
									Console.WriteLine("No numbers to display");
								}
								else
								{
									int x = stack.Pop();
									while (x != -1)
									{
										Console.WriteLine($"Number = {x}");
										x = stack.Pop();
									}
								}
								Console.Write("Enter any key to return : ");
								Console.ReadKey();
								break;
							case 4:
								//Console.Clear();
								if (stack.Top == 0)
								{
									Console.WriteLine("No numbers to display");
								}
								else
								{
									int ind;
									do
									{
										Console.Write($"Enter index of number you want (index between 1 to {stack.Top}) : ");
										ind = int.Parse(Console.ReadLine());
										ind--;
									} while (ind < 0 || ind >= stack.Top);
									Console.WriteLine($"number = {stack[ind]}");
								}
								Console.Write("Enter any key to return : ");
								Console.ReadKey();
								break;
							case 5:
								Console.WriteLine($"Size of Stack {stacknumber} = {stack.Size}");
								Console.Write("Enter any key to return : ");
								Console.ReadKey();
								break;
							case 6:
								return;
							case 7:
								System.Environment.Exit(0);
								break;
						}
						break;
				}
				StackScreen(stacknumber);
			}
		}




		
	}
}
