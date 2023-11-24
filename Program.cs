namespace Lommeregner
{
    internal class Program
    {
        // One-dimensional array to store the conversion factor for bananas
        static double[] bananaConversionFactors = { 19 };
        // One-dimensional array to store the conversion factor for inches
        static double[] inchesConversionFactors = { 1.5 };
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Overly Complicated Calculator!");

            while (true)
            {
                Console.WriteLine("\nChoose an operation:");
                Console.WriteLine("1. Addition");
                Console.WriteLine("2. Subtraction");
                Console.WriteLine("3. Multiplication");
                Console.WriteLine("4. Division");
                Console.WriteLine("5. Banana to CM Converter");
                Console.WriteLine("6. Inches to Girl Inches Converter");
                Console.WriteLine("7. Exit");

                // Method to get the users choice of operation
                int choice = GetChoice();

                if (choice == 7)
                {
                    Console.WriteLine("Exiting the calculator. Goodbye!");
                    break;
                }

                double result = PerformOperation(choice);

                Console.WriteLine($"Result: {result}");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static int GetChoice()
        {
            int choice;
            while (true)
            {
                Console.Write("Enter your choice (1-7): ");
                if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 7)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 7.");
                }
            }
            return choice;
        }

        // Method to perform the selected operation
        static double PerformOperation(int choice)
        {
            double result = 0;

            switch (choice)
            {
                case 1:
                    result = Addition();
                    break;
                case 2:
                    result = Subtraction();
                    break;
                case 3:
                    result = Multiplication();
                    break;
                case 4:
                    result = Division();
                    break;
                case 5:
                    result = BananaToCmConverter();
                    break;
                case 6:
                    result = InchesToGirlInchesConverter();
                    break;
            }

            return result;
        }

        // Method to perform addition operation
        static double Addition()
        {
            double[] numbers = GetNumbers("add");
            double sum = 0;
            foreach (double num in numbers)
            {
                sum += num;
            }
            return sum;
        }

        // Method to perform subtraction operation
        static double Subtraction()
        {
            double[] numbers = GetNumbers("subtract");
            double difference = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                difference -= numbers[i];
            }
            return difference;
        }

        // Method to perform multiplication operation
        static double Multiplication()
        {
            double[] numbers = GetNumbers("multiply");
            double product = 1;
            foreach (double num in numbers)
            {
                product *= num;
            }
            return product;
        }

        // Method to perform division operation
        static double Division()
        {
            double[] numbers = GetNumbers("divide");
            double quotient = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] != 0)
                {
                    quotient /= numbers[i];
                }
                else
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                    return 0;
                }
            }
            return quotient;
        }

        // Method to get an array of numbers from user input
        static double[] GetNumbers(string operation)
        {
            Console.Write($"Enter numbers to {operation}, separated by spaces: ");
            string[] inputNumbers = Console.ReadLine().Split(' ');
            double[] numbers = new double[inputNumbers.Length];

            for (int i = 0; i < inputNumbers.Length; i++)
            {
                if (!double.TryParse(inputNumbers[i], out numbers[i]))
                {
                    Console.WriteLine($"Error: Invalid input ({inputNumbers[i]}). Please enter valid numbers.");
                    return new double[0];
                }
            }

            return numbers;
        }

        // Method to convert bananas to centimeters using a one-dimensional array
        static double BananaToCmConverter()
        {
            Console.Write("Enter the number of bananas: ");
            if (double.TryParse(Console.ReadLine(), out double bananas))
            {
                // Retrieve the conversion factor from the one-dimensional array
                double conversionFactor = bananaConversionFactors[0];

                // Perform the conversion
                return bananas * conversionFactor;
            }
            else
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                return 0;
            }
        }


        // Method to convert inches to girl inches using a one-dimensional array
        static double InchesToGirlInchesConverter()
        {
            Console.Write("Enter the number of inches: ");
            if (double.TryParse(Console.ReadLine(), out double inches))
            {
                // Retrieve the conversion factor from the one-dimensional array
                double conversionFactor = inchesConversionFactors[0];

                // Perform the conversion
                return inches * conversionFactor;
            }
            else
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid number.");
                return 0;
            }
        }
    }
}
