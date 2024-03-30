namespace RaheemRestaurant.Pages;
// Author: Nawaf Raheem

public partial class AccountSignupPage : ContentPage
{
    public AccountSignupPage()
    {
        InitializeComponent();
    }

    private void createAccount_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Success", "Account Creation was Successful! Press OK to go Log in", "OK");
        Navigation.PushAsync(new MainPage());
    }
}