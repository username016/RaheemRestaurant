using RaheemRestaurant.Pages;

/* Author: Nawaf Raheem  */

namespace RaheemRestaurant
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            // Clear the userNameEntry and passwordEntry fields
            userNameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
        }


        // Mohammad Raja: Making use of the button to navigate to the MainCourse Page
        private async void loginBtn_ClickedAsync(object sender, EventArgs e)
        {

            var username = userNameEntry.Text; // Access the Entry's text using its x:Name
            if (!string.IsNullOrWhiteSpace(username))
            {
                await Navigation.PushAsync(new MainCoursePage(username));
            }

            // Check if either userNameEntry or passwordEntry is null or empty
            if (string.IsNullOrEmpty(userNameEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text))
            {
                // Display the alert if either field is empty or not entered
                await DisplayAlert("Error", "Please Enter your Username and Password", "I Understand");
            }
            else
            {
                // Proceed with navigation if both fields are filled
                await Navigation.PushAsync(new MainCoursePage(username));
            }



        }

        private void ForgetPassword_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgetPasswordPage());
        }

        private void createNewAccountClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AccountSignupPage());
        }

        private void adminPanelClicked(object sender, EventArgs e)
        {
            //Admin Panel Details -- Need to create admin panel page
        }
    }

}
