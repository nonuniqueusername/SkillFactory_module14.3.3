namespace _14
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            List<Contact> phoneBook = new List<Contact>
            {
                new Contact("Игорь", "Николаев", 79990000001, "igor@example.com"),
                new Contact("Сергей", "Довлатов", 79990000010, "serge@example.com"),
                new Contact("Анатолий", "Карпов", 79990000011, "anatoly@example.com"),
                new Contact("Валерий", "Леонтьев", 79990000012, "valera@example.com"),
                new Contact("Сергей", "Брин", 799900000013, "serg@example.com"),
                new Contact("Иннокентий", "Смоктуновский", 799900000013, "innokentii@example.com")
            };

            int paginationSize = 2;

            while (true)
            {
                Console.WriteLine("Enter digit:");

                char userInput = Console.ReadKey().KeyChar;
                if (!Char.IsDigit(userInput))
                {
                    continue;
                }

                int digitInput = int.Parse(userInput.ToString());

                if ((digitInput * paginationSize) > phoneBook.Count) 
                {
                    Console.WriteLine("\nOut of range!");
                    continue;
                }

                var results = phoneBook
                    .OrderBy(c => c.Name)
                    .ThenBy(c => c.LastName)
                    .Skip((digitInput - 1)*paginationSize)
                    .Take(paginationSize);
                
                Console.WriteLine();
                foreach (Contact contact in results)
                {
                    Console.WriteLine($"{contact.Name} -- {contact.LastName} -- {contact.PhoneNumber}");
                }

            }

        }

    }
}