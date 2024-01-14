namespace MediiApp;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private void OnLoginClicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (ValidateCredentials(username, password))
        {
            Preferences.Set("isLoggedIn", true);

            Application.Current.MainPage = new AppShell();
        }
        else
        {
            DisplayAlert("Login Failed", "Invalid username or password", "OK");
        }
    }

    private bool ValidateCredentials(string username, string password)
    {
        return username == "admin" && password == "admin";
    }
}

