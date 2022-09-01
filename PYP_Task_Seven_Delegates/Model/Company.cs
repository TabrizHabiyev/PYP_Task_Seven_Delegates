// make console red and bold
using static PYP_Task_Seven_Delegates.Delegates.Delegates;

public class Company
{
    List<User> usersList = new List<User>();
    List<string> loggedInUsers  = new List<string>();
    public string Name { get; set; }
    public (bool succest,string message) Register(string name ,string surName, string password)
    {
        EmailGenerate emailGenerate = GenerateEmail;
        var (isValid, generatedEmail) = emailGenerate(name, surName);
        if (isValid)
        {
            User user = new User()
            {
                Name = name,
                Surname = surName,
                Username = name + surName,
                Password = password,
                Email = generatedEmail
            };
            if(usersList.FirstOrDefault(x=>x.Email == user.Email) != null)
            {
                return (false, "This user name or surname is already registered");
            }
            IsValidModel isValidModel = ModelStateIsValid;
            List<string> errors = isValidModel(user);
            if (errors.Count == 0)
            {
                usersList.Add(user);
                return (true, $"User is registered succestful. Your Email is {generatedEmail}");
            }
            else
            {
                return (false, errors.First().ToString());
            }
        }
        else
        {
            return (false, $"User is not registered because name or surname not valid");
        }
    }

    public (bool isSuccest,User? loggedUser,List<User>? users) Login(string email, string password)
    {
        User? user = usersList.FirstOrDefault(u => u.Email == email && u.Password == password);
        if (user != null)
        {
            loggedInUsers.Add(user.Email);
            return (true, user, usersList);
        }
        else
        {
            return (false,null,null);
        }
    }
}