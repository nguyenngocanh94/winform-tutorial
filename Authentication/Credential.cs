namespace WindowsFormsApp1.Authentication
{
    public class Credential
    {
        string username;
        string password;

        string capChar;

        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
        }

        public string getCapChar()
        {
            return capChar;
        }

        public Credential(string username, string password, string capChar)
        {
            this.username = username;
            this.password = password;
            this.capChar = capChar;
        }
        
    }
}