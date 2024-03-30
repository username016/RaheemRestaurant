// Author: Nawaf Raheem

namespace RaheemRestaurant.Pages;

public partial class ForgetPasswordPage : ContentPage
{
    public ForgetPasswordPage()
    {
        InitializeComponent();
    }

    private void ForgetPassword_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new ForgetPasswordPage());
    }

    private void SubmitForgetYourPassword_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Submission Completed", "Your Submission Has Been Completed You Should Recieve An Email Momentarily", "OK");
        Navigation.PushAsync(new MainPage());
    }
}