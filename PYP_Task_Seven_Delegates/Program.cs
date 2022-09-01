// use of do while loop
// Add the user information in the loop to the register method in the company by asking
// Name cannot be empty or less than 3 characters.
// Surname cannot be empty or less than 3 characters.
// Password cannot be empty or less than 6 characters.
// If the entered information does not comply with the conditions, ask again
// force until user enters correctly



using PYP_Task_Seven_Delegates;

Company company = new Company();
company.Name = "PYP";
bool exit = true;
do
{
    Console.WriteLine("Regiser - 1 , Login - 2 , Exit - 3");
    string choice = Console.ReadLine();
    switch (choice)
    {
        case "1":
        againName:
            Console.Write("Enter name : ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || name.Length < 3)
            {
                Console.WriteLine("Name cannot be empty or less than 3 characters");
                goto againName;
            }
        againSurname:
            Console.Write("Enter surname : ");
            string surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname) || surname.Length < 3)
            {
                Console.WriteLine("Name cannot be empty or less than 3 characters");
                goto againSurname;
            }
        againPassword:
            Console.Write("Enter password : ");
            string password = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                Console.WriteLine("Password cannot be empty or less than 6 character");
                goto againPassword;
            }
            var result = company.Register(name, surname, password);
            if (result.succest)
            {
                Console.Clear();
                Console.WriteLine(result.message,ConsoleColor.Blue,true);
                continue;
            }
            else
            {
                Console.Clear();
                Console.WriteLine(result.message,ConsoleColor.Red,true);
                continue;
            }
            break;
        case "2":
            againLoginEmail:
            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(email))
            {
                Console.Clear();
                Console.WriteLine("Email is not be null or empity");
                goto againLoginEmail;
            }
            againLoginPassword:
            Console.WriteLine("Enter password");
            string password1 = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(password1))
            {
                Console.Clear();
                Console.WriteLine("Password is not be null or empity");
                goto againLoginPassword;
            }

            var user = company.Login(email, password1);
            if (user.isSuccest)
            {
                Console.WriteLine("User is logged in", ConsoleColor.Green, true);
                Console.Clear();
                Profile profile = new Profile(user.loggedUser, user.users);
                exit = false;
                
            }
            else
            {
                Console.WriteLine("User is not logged in", ConsoleColor.Red, true);
            }
            break;
        case "3":
            Environment.Exit(0);
            break;
        default:
            Console.Clear();
            Console.WriteLine("Please Enter Correct Choice");
            continue;
            break;
    }

} while (exit);


