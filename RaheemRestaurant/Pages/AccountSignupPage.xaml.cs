using RaheemRestaurant.BusinessLogic;
using RaheemRestaurant.DataLayer;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.RegularExpressions;
namespace RaheemRestaurant.Pages;

// Author: Mohammad Raja

// Partial class for AccountSignupPage, handling the logic for user account creation.
public partial class AccountSignupPage : ContentPage
{
    // Test user object for current session.
    Users userTest = new Users();

    // Constructor for the AccountSignupPage.
    public AccountSignupPage()
    {
        InitializeComponent(); // Initializes the component from the XAML file.
        LoadUsersFromFile(); // Loads existing users from the file on creation.
    }

    // Generate a unique ID for new users, ensuring no duplicate IDs exist.
    private int GenerateUniqueId()
    {
        // Return the highest current user ID + 1, or 1 if no users exist.
        return _allUsers.Any() ? _allUsers.Max(u => u.ID) + 1 : 1;
    }

    // Loads users from a JSON file stored locally on the user's desktop.
    public void LoadUsersFromFile()
    {
        // Setting up the file path to the users JSON data.
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RaheemRestaurant/RaheemRestaurant/Resources/Raw");
        string filePath = Path.Combine(folderPath, "users.json");

        // Check if the JSON file exists before attempting to read.
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            // Proceed only if the jsonString contains data.
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                try
                {
                    // Deserialize the JSON string to an ObservableCollection of Users.
                    var existingUsers = JsonSerializer.Deserialize<ObservableCollection<Users>>(jsonString);
                    if (existingUsers != null)
                    {
                        // Add users to the collection if they aren't already included.
                        foreach (var user in existingUsers)
                        {
                            if (!_allUsers.Any(u => u.UserName == user.UserName))
                            {
                                _allUsers.Add(user);
                            }
                        }
                    }
                }
                catch (JsonException ex) // Catch serialization errors.
                {
                    Debug.WriteLine($"JSON deserialization error: {ex.Message}");
                }
            }
            else
            {
                Debug.WriteLine("JSON file is empty or contains invalid data.");
            }
        }
        else
        {
            Debug.WriteLine("No existing user file found.");
        }
    }

    // Collection to hold all users.
    public ObservableCollection<Users> _allUsers = new ObservableCollection<Users>();

    // Event handler for clicking the Create Account button.
    private void createAccount_Clicked(object sender, EventArgs e)
    {
        bool isValid = true; // Flag to track the validation status.

        // Validate the username is not empty and doesn't already exist.
        string newUsername = userNameEntry.Text;
        if (string.IsNullOrWhiteSpace(userNameEntry.Text))
        {
            DisplayAlert("Error", "Username field cannot be empty.", "OK");
            isValid = false;
        }
        if (_allUsers.Any(u => u.UserName == newUsername))
        {
            DisplayAlert("Error", "Username already exists. Choose another.", "OK");
            isValid = false;
        }

        // Validate other user inputs with specific conditions.
        if (isValid && string.IsNullOrWhiteSpace(firstNameEntry.Text))
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

        // Validate phone number with a regular expression.
        Regex phoneRegex = new Regex(@"^\d{10}$");
        if (isValid && (string.IsNullOrWhiteSpace(phoneNumberEntry.Text) || !phoneRegex.IsMatch(phoneNumberEntry.Text)))
        {
            DisplayAlert("Alert", "Please Enter a Valid Phone Number!", "OK");
            isValid = false;
        }

        if (isValid)
        {
            // Create a new user object and add to users collection.
            int newId = GenerateUniqueId();
            Users user = new Users(firstNameEntry.Text, lastNameEntry.Text, userNameEntry.Text, passwordEntry.Text, emailEntry.Text, phoneNumberEntry.Text)
            {
                ID = newId
            };
            _allUsers.Add(user);
            // Save the updated users collection to JSON.
            Repository.WriteDataToJsonFile(_allUsers, "users.json");
            DisplayAlert("Success", "Account created successfully.", "OK");
            // Navigate to the main application page.
            Navigation.PushAsync(new MainPage());
        }
    }
}