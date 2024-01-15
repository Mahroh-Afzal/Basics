using System;

class Program
{
    static void Main()
    {
        int startNumber = GetIntegerInput("Enter your first number: ");
        int endNumber = GetIntegerInput("Enter a number greater than your first number: ");

        Console.WriteLine($"The difference between {startNumber} and {endNumber} is: {CalculateDifference(startNumber, endNumber)}");

        int[] numbersArray = GenerateNumbersArray(startNumber, endNumber);
        SaveNumbersToFile(numbersArray, "numbers.txt");

        int sum = ReadAndPrintSumFromFile("numbers.txt");
        Console.WriteLine($"The sum of your numbers is: {sum}");

        List<double> numbersList = GenerateNumbersList(startNumber, endNumber);
        PrintPrimeNumbers(numbersList);
    }

    static int GetIntegerInput(string prompt)
    {
        int number;
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out number))
                return number;

            Console.WriteLine("Invalid input. Try Again.");
        }
    }

    static int CalculateDifference(int start, int end)
    {
        return end - start;
    }

    static int[] GenerateNumbersArray(int start, int end)
    {
        int[] numbersArray = new int[end - start + 1];
        for (int i = 0; i < numbersArray.Length; i++)
        {
            numbersArray[i] = start++;
        }
        return numbersArray;
    }

    static void SaveNumbersToFile(int[] numbers, string fileName)
    {
       
        using (var writer = new System.IO.StreamWriter(fileName))
        {
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                writer.WriteLine(numbers[i]);
            }
        }
    }

    static int ReadAndPrintSumFromFile(string fileName)
    {
       
        int sum = 0;
        using (var reader = new System.IO.StreamReader(fileName))
        {
            while (!reader.EndOfStream)
            {
                if (int.TryParse(reader.ReadLine(), out int number))
                {
                    sum += number;
                }
            }
        }
        return sum;
    }

    static List<double> GenerateNumbersList(int start, int end)
    {
        List<double> numbersList = new List<double>();
        for (double i = start; i <= end; i++)
        {
            numbersList.Add(i);
        }
        return numbersList;
    }

    static void PrintPrimeNumbers(List<double> numbers)
    {
        Console.WriteLine("The prime numbers between your inputted numbers are:");
        foreach (var number in numbers)
        {
            if (IsPrime((int)number))
            {
                Console.Write($"{number} ");
            }
        }
    }

    static bool IsPrime(int number)
    {
        if (number < 2)
            return false;

        for (int i = 2; i <= Math.Sqrt(number); i++)
        {
            if (number % i == 0)
                return false;
        }
        return true;
    }
}
