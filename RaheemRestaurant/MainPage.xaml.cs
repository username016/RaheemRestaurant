using RaheemRestaurant.BusinessLogic;
using RaheemRestaurant.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

/* Author: Nawaf Raheem  */

namespace RaheemRestaurant
{

    public partial class MainPage : ContentPage
    {


        private ObservableCollection<Users> _allUsers = new ObservableCollection<Users>();

        public MainPage()
        {
            InitializeComponent();
            
           LoadUsersFromFile();
        }

        private void LoadUsersFromFile()
        {
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RaheemRestaurant/RaheemRestaurant/Resources/Raw");
            string filePath = Path.Combine(folderPath, "users.json");

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    try
                    {
                        _allUsers = JsonSerializer.Deserialize<ObservableCollection<Users>>(jsonString);
                    }
                    catch (JsonException ex)
                    {
                        Debug.WriteLine($"JSON deserialization error: {ex.Message}");
                        // Consider user feedback or logging
                    }
                }
            }
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
            var password = passwordEntry.Text;

          /*  if (!string.IsNullOrWhiteSpace(username))
            {
                await Navigation.PushAsync(new MainCoursePage(username));
            }
          */

            // Check if either userNameEntry or passwordEntry is null or empty
            if (string.IsNullOrEmpty(userNameEntry.Text) || string.IsNullOrEmpty(passwordEntry.Text))
            {
                // Display the alert if either field is empty or not entered
                await DisplayAlert("Error", "Please Enter your Username and Password", "I Understand");
            }
            else
            {
                var user = _allUsers.FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user != null)
                {
                    // Password matches, proceed to MainCoursePage
                    await Navigation.PushAsync(new MainCoursePage(username));
                }
                else
                {
                    // User not found or password does not match
                    await DisplayAlert("Error", "Invalid username or password", "OK");
                }
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
