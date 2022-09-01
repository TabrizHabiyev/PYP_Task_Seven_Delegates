

namespace PYP_Task_Seven_Delegates;

public class Profile
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    List<User> usersList = new List<User>();

    public Profile(User user,List<User> users)
{
        Name = user.Name;
        Surname = user.Surname;
        Username = user.Username;
        Email = user.Email;
        usersList = users;
        ShowProfile();
    }

    public void ShowProfile()
    {
        Console.WriteLine($"Welcome {Name} {Surname} \n");

        do
        {
            Console.WriteLine("See all users - 1 \n, Get User By Id - 2 \n, Update User's datas (UpdateById) - 3 \n, Delete User from Company (DeleteById) - 4 \n Exit - 5 \n");
            var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ShowAllUsers();
                    break;
                case "2":
                    GetUserById();
                    break;
                case "3":
                    UpdateUser();
                    break;
                case "4":
                    DeleteUser();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Please enter valid number");
                    break;
            }
            
        } while (true);

    }

   public void ShowAllUsers()
    {
        Console.WriteLine("All Users");
        foreach (var user in usersList)
        {
            Console.WriteLine($"Id : {user.Id} \t Name : {user.Name} \t Surname : {user.Surname} \t Username : {user.Username} \t Email : {user.Email}");
        }
    }

    public void GetUserById()
    {
        Console.WriteLine("Enter Id");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int id))
        {
            var user = usersList.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Console.WriteLine($"Id : {user.Id} \t Name : {user.Name} \t Surname : {user.Surname} \t Username : {user.Username} \t Email : {user.Email}");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        else
        {
            Console.WriteLine("Please enter valid number");
        }
    }

    public void UpdateUser()
    {
        Console.WriteLine("Enter Id");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int id))
        {
            var user = usersList.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                Console.WriteLine($"Id : {user.Id} \t Name : {user.Name} \t Surname : {user.Surname} \t Username : {user.Username} \t Email : {user.Email}");
                Console.WriteLine("Enter new Name");
                var newName = Console.ReadLine();
                Console.WriteLine("Enter new Surname");
                var newSurname = Console.ReadLine();
                Console.WriteLine("Enter new Username");
                var newUsername = Console.ReadLine();
                Console.WriteLine("Enter new Email");
                var newEmail = Console.ReadLine();
                user.Name = newName;
                user.Surname = newSurname;
                user.Username = newUsername;
                user.Email = newEmail;
                Console.WriteLine("User updated succestful");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        else
        {
            Console.WriteLine("Please enter valid number");
        }
    }

    public void DeleteUser()
    {
        Console.WriteLine("Enter Id");
        var input = Console.ReadLine();
        if (int.TryParse(input, out int id))
        {
            var user = usersList.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                usersList.Remove(user);
                Console.WriteLine("User deleted succestful");
            }
            else
            {
                Console.WriteLine("User not found");
            }
        }
        else
        {
            Console.WriteLine("Please enter valid number");
        }
    }
   
}