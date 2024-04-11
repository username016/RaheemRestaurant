using RaheemRestaurant.BusinessLogic;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
namespace RaheemRestaurant.Pages;
// Author: Nawaf Raheem

public partial class AccountSignupPage : ContentPage
{
    Users userTest = new Users();

    
    public AccountSignupPage()
    {
        InitializeComponent();
    }
    
    private void createAccount_Clicked(object sender, EventArgs e)
    {
        bool isValid = true;

        // Check each field individually
        if (string.IsNullOrWhiteSpace(firstNameEntry.Text))
        {
            DisplayAlert("Alert", "Please Enter Your First Name!", "OK");
            isValid = false;
        }

        if (isValid && string.IsNullOrWhiteSpace(lastNameEntry.Text))
        {
            DisplayAlert("Alert", "Please Enter Your Last Name!", "OK");
            isValid = false;
        }



        if (isValid && string.IsNullOrWhiteSpace(passwordEntry.Text))
        {
            DisplayAlert("Alert", "Please Enter Your Password!", "OK");
            isValid = false;
        }

        if (isValid && (string.IsNullOrWhiteSpace(emailEntry.Text) || !emailEntry.Text.Contains("@")))
        {
            DisplayAlert("Alert", "Please Enter a Valid Email!", "OK");
            isValid = false;
        }

        Regex phoneRegex = new Regex(@"^\d{10}$");
        if (isValid && (string.IsNullOrWhiteSpace(phoneNumberEntry.Text) || !phoneRegex.IsMatch(phoneNumberEntry.Text)))
        {
            DisplayAlert("Alert", "Please Enter a Valid Phone Number!", "OK");
            isValid = false;
        }

        // Check if the username already exists before setting it
        if (isValid && (string.IsNullOrWhiteSpace(userNameEntry.Text) || userTest.UserIDs.ContainsKey(userNameEntry.Text)))
        {
            DisplayAlert("Alert", "Please Enter a Valid Username!", "OK");
            isValid = false;
        }
        else if (isValid)
        {
            userTest.SetUserName(userNameEntry.Text);
        }

        // If all fields are valid, display success message and navigate to the main page
        if (isValid)
        {
            Users user = new Users(firstNameEntry.Text, lastNameEntry.Text, userNameEntry.Text, passwordEntry.Text, emailEntry.Text, phoneNumberEntry.Text);
            DisplayAlert("Success", "Account created successfully.", "OK");
            Navigation.PushAsync(new MainPage());
        }

    }
}