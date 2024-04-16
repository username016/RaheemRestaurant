using RaheemRestaurant.BusinessLogic;
using RaheemRestaurant.DataLayer;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Text.Json;
using System.Text.RegularExpressions;
namespace RaheemRestaurant.Pages;

// Author: Mohammad Raja

public partial class AccountSignupPage : ContentPage
{
    Users userTest = new Users();

    
    public AccountSignupPage()
    {
        InitializeComponent();
        LoadUsersFromFile(); // Load existing users

    }

    private int GenerateUniqueId()
    {
        return _allUsers.Any() ? _allUsers.Max(u => u.ID) + 1 : 1;
    }


    public void LoadUsersFromFile()
    {
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RaheemRestaurant/RaheemRestaurant/Resources/Raw");
        string filePath = Path.Combine(folderPath, "users.json");

        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            // Only proceed if the jsonString is not empty or whitespace
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                try
                {
                    var existingUsers = JsonSerializer.Deserialize<ObservableCollection<Users>>(jsonString);
                    if (existingUsers != null)
                    {
                        foreach (var user in existingUsers)
                        {
                            // Check to avoid adding duplicate users if they're already loaded
                            if (!_allUsers.Any(u => u.UserName == user.UserName))
                            {
                                _allUsers.Add(user);
                            }
                        }
                    }
                }
                catch (JsonException ex) // Catches serialization errors
                {
                    // Log the error or handle it as appropriate for your application
                    Debug.WriteLine($"JSON deserialization error: {ex.Message}");
                }
            }
            else
            {
                // Optionally log or handle the fact that the JSON file was empty
                Debug.WriteLine("JSON file is empty or contains invalid data.");
            }
        }
        else
        {
            // Optionally log or handle the absence of the file
            Debug.WriteLine("No existing user file found.");
        }
    }


    public ObservableCollection<Users> _allUsers = new ObservableCollection<Users>();
    private void createAccount_Clicked(object sender, EventArgs e)
    {
        

        bool isValid = true;

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


        else if (isValid)
        {
            userTest.SetUserName(userNameEntry.Text);
        }

        // If all fields are valid, display success message and navigate to the main page
        if (isValid)
        {
            int newId = GenerateUniqueId();
            Users user = new Users(firstNameEntry.Text, lastNameEntry.Text, userNameEntry.Text, passwordEntry.Text, emailEntry.Text, phoneNumberEntry.Text)
            {
                ID = newId
            };
            _allUsers.Add(user);
            Repository.WriteDataToJsonFile(_allUsers, "users.json");
            DisplayAlert("Success", "Account created successfully.", "OK");
            Navigation.PushAsync(new MainPage());
        }

    }
}