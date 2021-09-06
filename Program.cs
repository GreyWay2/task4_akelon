using System;

public class Program
{
	static string SumDistribution(string type, double sum, double[] distrSums)
	{
		double[] resSum = new double[distrSums.Length];
		string result = "";
		switch (type)
		{
			case "ПРОП":
				double amount = 0.0;
				for (int i = 0; i < distrSums.Length; i++)
				{
					amount += distrSums[i];
				}
				for (int i = 0; i < distrSums.Length; i++)
				{
					var p = (double) distrSums[i] / amount;
					resSum[i] = Math.Round(p * sum, 2);
				}
				double sumRes = 0.0;
				foreach (double value in resSum)
				{
					sumRes += value;
				}
				if(sumRes != sum)
				{
					resSum[^1] += sum - sumRes;
				}
				break;
			case "ПЕРВ":
				double tempSum = sum;
				for (int i = 0; i < distrSums.Length; i++)
				{
					if (tempSum > 0)
					{
						if (distrSums[i] < tempSum)
						{
							resSum[i] = distrSums[i];
							tempSum -= resSum[i];
						} 
						else
                        {
							resSum[i] = tempSum;
							tempSum -= tempSum;
						}
					}
                    else
                    {
						resSum[i] = 0;
					}
				}
				break;
			case "ПОСЛ":
				double tempSumm = sum;
				for (int i = distrSums.Length-1; i >= 0; i--)
				{
					if (tempSumm > 0)
					{
						if (distrSums[i] < tempSumm)
						{
							resSum[i] = distrSums[i];
							tempSumm -= resSum[i];
						}
						else
						{
							resSum[i] = tempSumm;
							tempSumm -= tempSumm;
						}
					}
					else
					{
						resSum[i] = 0;
					}
				}
				break;
			default:
				Console.WriteLine("Что-то не так с вводимым типом распредления!!!");
				return "";
		}
		foreach (double value in resSum)
		{
			result = result + value.ToString("") + ";";
		}
		return result;
	}
	public static void Main()
	{
		do
		{
			try
			{
				Console.WriteLine("\nВведите тип распределения:");
				string type = Console.ReadLine();
				Console.WriteLine("Сумма:");
				double sum = Convert.ToDouble(Console.ReadLine());
				Console.WriteLine("Суммы распределения в формате (сумма;сумма;сумма и т.д.):");
				double[] sums = Array.ConvertAll(Console.ReadLine().Split(";"), double.Parse);
				
				Console.WriteLine($"Результат распределения: {SumDistribution(type, sum, sums)}");
			}
            catch(Exception e)
            {
				Console.WriteLine($"Исключение: {e.Message}");
			}
			Console.WriteLine("Esc чтобы выйти или Enter для повторного ввода...");
		}
		while (Console.ReadKey().Key != ConsoleKey.Escape);
	}
}