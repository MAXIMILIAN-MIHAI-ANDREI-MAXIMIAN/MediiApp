namespace MediiApp;

public partial class LogoutPage : ContentPage
{
    public LogoutPage()
    {
        InitializeComponent();
    }

    private void OnLogoutClicked(object sender, EventArgs e)
    {
        Preferences.Set("isLoggedIn", false);
        Application.Current.MainPage = new LoginPage();
    }
}