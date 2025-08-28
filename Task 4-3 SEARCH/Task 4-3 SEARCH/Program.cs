namespace Task_4_3_SEARCH
{
    internal class Program
    {
        //1.Write a C# program that reads a list of integers from the user and throws an exception if any numbers are duplicates.
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter numbers: ");
                string[] parts = Console.ReadLine().Split(' ');
                List<int> numbers = new List<int>();

                foreach (var p in parts)
                {
                    int n = Convert.ToInt32(p);
                    if (numbers.Contains(n))
                        throw new Exception("Duplicate found: " + n);

                    numbers.Add(n);
                }

                Console.WriteLine("All numbers are unique.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


    }
}
