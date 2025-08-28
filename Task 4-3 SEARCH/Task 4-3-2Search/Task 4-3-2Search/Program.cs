namespace Task_4_3_2Search
{
    internal class Program
    {
        //2. Write a C# program to create a method that takes a string as input and throws an exception if the string does not contain vowels.

        static void CheckVowels(string input)
        {
            try
            {
                if (input.Contains("a") || input.Contains("e") ||
                    input.Contains("i") || input.Contains("o") ||
                    input.Contains("u"))
                {
                    Console.WriteLine("The string contains vowels.");
                }
                else
                {
                    int x = int.Parse("error");
                }
            }
            catch
            {
                Console.WriteLine("Error: The string does not contain vowels.");
            }
        }

        static void Main()
        {
            Console.Write("Enter a string: ");
            string input = Console.ReadLine();

            CheckVowels(input);
        }
    }
}
