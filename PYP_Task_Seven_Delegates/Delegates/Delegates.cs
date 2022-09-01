using System.Text.RegularExpressions;

namespace PYP_Task_Seven_Delegates.Delegates
{
    public class Delegates
    {
         public delegate (bool isValid,string? generatedEmail) EmailGenerate(string name, string surname);
         public delegate List<string> IsValidModel(User user);
         public static (bool isValid,string? generatedEmail) GenerateEmail(string name,string surname){
             if (string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(surname))
                {
                    return (false, null);
                }
                else
                {
                    string email = name.ToLower().Trim()+surname.ToLower().Trim() + "@gmail.com";
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(email);
                    if (match.Success)
                    {
                        return (true, email);
                    }
                    else
                    {
                        return (false, null);
                    }
                }                  
         }

          public static List<string> ModelStateIsValid(User user){
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(user.Name))
            {
                errors.Add("Name is not valid");
            }
            if (string.IsNullOrWhiteSpace(user.Surname))
            {
                errors.Add("Surname is not valid");
            }
            if (string.IsNullOrWhiteSpace(user.Username))
            {
                errors.Add("Username is not valid");
            }
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                errors.Add("Email is not valid");
            }
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                errors.Add("Password is not valid");
            }
            return errors;
          }
    }
}