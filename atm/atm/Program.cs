using System;

namespace atm
{
    class Program
    {
        static void Main(string[] args)
        {
            Start();
        }

        static void Start()
        {
            User[] users = new User[5];
            users[0] = new User("User1Name", "User1Surname", new Card("123456789012", "1234", "123", "06/25", 700));
            users[1] = new User("User2Name", "User2Surname", new Card("345612789876", "7685", "345", "08/25", 500));
            users[2] = new User("User3Name", "User3Surname", new Card("126579789012", "3462", "789", "05/24", 600));
            users[3] = new User("User4Name", "User4Surname", new Card("345615989876", "1078", "327", "07/23", 400));
            users[4] = new User("User5Name", "User5Surname", new Card("123456788523", "6745", "831", "02/24", 800));

            Run(users);

        }

        static int countInvalid = 1;

        static void Run(User[] users)
        {
            Console.WriteLine("Enter PIN code:");
            string PinCode = Console.ReadLine();
            int count = PinCode.Length;
            Boolean found = false;

            if (count == 4)
            {
                for (int i = 0; i < users.Length; i++)
                {
                    if (PinCode == users[i].CreditCard.PIN)
                    {
                        Console.WriteLine($"\nWelcome {users[i].Name} {users[i].SurName}. Please choose one from followings: ");
                        Choose(users, i);
                        found = true;
                    }
                }
                if (!found)
                {
                    Console.WriteLine("Such card is not found.");
                    Run(users);
                }
            }
            else
            {
                countInvalid++;
                Console.WriteLine("Invalid number");
                if (countInvalid <= 3)
                {
                    Run(users);
                }
                else
                {
                    Console.WriteLine("Your card is blocked");
                }
            }
        }

        static void Choose(User[] users, int i)
        {
            Console.WriteLine("\n1.Balance \n2.Cash\n");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    Console.WriteLine($"Your balance is {users[i].CreditCard.Balance}");
                    break;
                case 2:
                    TakeCash(users, i);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please retry");
                    Choose(users, i);
                    break;
            }
        }

        static void TakeCash(User[] users, int i)
        {
            Console.WriteLine("Choose one of them ");
            Console.WriteLine("1. 10 AZN \n2. 20 AZN \n3. 50 AZN \n4. 100 AZN \n5. Other\n");
            int.TryParse(Console.ReadLine(), out int choice);
            switch (choice)
            {
                case 1:
                    CheckBalance(users, i, 10);
                    break;
                case 2:
                    CheckBalance(users, i, 20);
                    break;
                case 3:
                    CheckBalance(users, i, 50);
                    break;
                case 4:
                    CheckBalance(users, i, 100);
                    break;
                case 5:
                    Console.WriteLine("Enter cash:");
                    int.TryParse(Console.ReadLine(), out int amount);
                    CheckBalance(users, i, amount);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please retry\n");
                    TakeCash(users, i);
                    break;
            }
        }

        static void CheckBalance(User[] users, int i, int amount)
        {
            if (users[i].CreditCard.Balance > amount)
            {
                users[i].CreditCard.Balance -= amount;
                Console.WriteLine("Withdraw done succesfully");
                Choose(users, i);
            }
            else
            {
                Console.WriteLine("There is no enough money.");
            }
        }
    }

    class Card
    {
        public Card(string pAN, string pIN, string cVC, string expireDate, decimal balance)
        {
            PAN = pAN;
            PIN = pIN;
            CVC = cVC;
            ExpireDate = expireDate;
            Balance = balance;
        }

        public string PAN { get; set; }
        public string PIN { get; set; }
        public string CVC { get; set; }
        public string ExpireDate { get; set; }
        public decimal Balance { get; set; }

    }

    class User
    {
        public User(string name, string surName, Card creditCard)
        {
            Name = name;
            SurName = surName;
            CreditCard = creditCard;
        }

        public string Name { get; set; }
        public string SurName { get; set; }
        public Card CreditCard { get; set; }
    }
}
