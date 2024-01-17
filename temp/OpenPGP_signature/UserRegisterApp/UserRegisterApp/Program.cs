using System.Linq;

string password = "";
Console.Write("Enter your password: ");
ConsoleKeyInfo key;


Console.WriteLine($"\n wpisałeś hasło {GetPassword()}");
string  GetPassword() {
do
{
    key = Console.ReadKey(true);
    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
    {
        password += key.KeyChar;
        Console.Write("*");
    }
    else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
    {
        password = password.Substring(0, (password.Length - 1));
        Console.Write("\b \b");
    }
    
} while (key.Key != ConsoleKey.Enter);
    
    return password.GetHashCode().ToString();
       
 }
//ConsoleKeyInfo cki;
//// Prevent example from ending if CTL+C is pressed.
//Console.TreatControlCAsInput = true;

//Console.WriteLine("Press any combination of CTL, ALT, and SHIFT, and a console key.");
//Console.WriteLine("Press the Escape (Esc) key to quit: \n");
//do
//{
//    cki = Console.ReadKey();
//    Console.Write(" --- You pressed ");
//    if ((cki.Modifiers & ConsoleModifiers.Alt) != 0) Console.Write("ALT+");
//    if ((cki.Modifiers & ConsoleModifiers.Shift) != 0) Console.Write("SHIFT+");
//    if ((cki.Modifiers & ConsoleModifiers.Control) != 0) Console.Write("CTL+");
//    Console.WriteLine(cki.Key.ToString());
//} while (cki.Key != ConsoleKey.Escape);

//Console.Write("Enter your email: ");
//string email = Console.ReadLine();
//bool isValid = IsValidEmail(email);
//Console.WriteLine("Your email is {0}valid.", isValid ? "" : "in");
    

//    static bool IsValidEmail(string email)
//{
//    try
//    {
//        var addr = new System.Net.Mail.MailAddress(email);
//        return true;
//    }
//    catch
//    {
//        return false;
//    }
//}