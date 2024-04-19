using RaheemRestaurant.BusinessLogic;
using RaheemRestaurant.Pages;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

/* Author: Nawaf Raheem  */

// Defines a partial class MainPage that inherits from ContentPage. This class is responsible for user login and navigation to various parts of the application.
namespace RaheemRestaurant
{
    public partial class MainPage : ContentPage
    {
        // An ObservableCollection to manage user data loaded from a JSON file.
        private ObservableCollection<Users> _allUsers;

        // Constructor for MainPage initializes components and loads users from a JSON file.
        public MainPage()
        {
            InitializeComponent(); // Initializes the XAML components.
            _allUsers = new ObservableCollection<Users>(); // Initializes the user collection.
            LoadUsersFromFile(); // Loads user data from a JSON file.
        }

        // Loads user data from a JSON file located in a specific directory on the user's desktop.
        private void LoadUsersFromFile()
        {
            // Constructs the full path to the JSON file containing user data.
            string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RaheemRestaurant/RaheemRestaurant/Resources/Raw");
            string filePath = Path.Combine(folderPath, "users.json");

            // Checks if the JSON file exists before attempting to read.
            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);
                Debug.WriteLine("JSON String: " + jsonString); // Outputs the JSON string for debugging purposes.

                // Ensures the JSON string is not empty or just whitespace.
                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    try
                    {
                        // Attempts to deserialize the JSON string to an ObservableCollection of Users.
                        var users = JsonSerializer.Deserialize<ObservableCollection<Users>>(jsonString);
                        if (users != null)
                        {
                            _allUsers = users; // Assigns the deserialized users to the collection.
                            Debug.WriteLine("Loaded users count: " + _allUsers.Count); // Outputs the count of loaded users.
                        }
                        else
                        {
                            Debug.WriteLine("Deserialization returned null");
                        }
                    }
                    catch (JsonException ex)
                    {
                        Debug.WriteLine($"JSON deserialization error: {ex.Message}");
                    }
                }
                else
                {
                    Debug.WriteLine("JSON file is empty or contains only whitespace.");
                }
            }
            else
            {
                Debug.WriteLine("JSON file does not exist.");
            }
        }

        // Executes each time the MainPage becomes visible, particularly after navigation events.
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Clears the text entries for username and password to ensure privacy and readiness for new login attempts.
            userNameEntry.Text = string.Empty;
            passwordEntry.Text = string.Empty;
        }

        // Event handler for the login button click. Attempts to authenticate the user.
        private async void loginBtn_ClickedAsync(object sender, EventArgs e)
        {
            var username = userNameEntry.Text; // Retrieves the entered username.
            var password = passwordEntry.Text; // Retrieves the entered password.

            // Validates that neither the username nor password fields are empty.
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                await DisplayAlert("Error", "Please Enter your Username and Password", "I Understand");
            }
            else
            {
                // Attempts to find a user that matches both username and password.
                var user = _allUsers.FirstOrDefault(u => u.UserName == username && u.Password == password);
                if (user != null)
                {
                    // If a matching user is found, navigate to the MainCoursePage.
                    await Navigation.PushAsync(new MainCoursePage(username));
                }
                else
                {
                    // If no matching user is found, display an error message.
                    await DisplayAlert("Error", "Invalid username or password", "OK");
                }
            }
        }

        // Navigates to the ForgetPasswordPage when the corresponding button is clicked.
        private void ForgetPassword_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ForgetPasswordPage());
        }

        // Navigates to the AccountSignupPage to allow new users to create an account.
        private void createNewAccountClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AccountSignupPage());
        }

        // Placeholder for future implementation of navigation to an AdminPanelPage.
        private void adminPanelClicked(object sender, EventArgs e)
        {
            // Future implementation needed for admin panel navigation.
        }
    }
}