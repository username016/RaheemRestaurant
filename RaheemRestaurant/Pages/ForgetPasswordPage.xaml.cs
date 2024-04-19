// Author: Nawaf Raheem
using RaheemRestaurant.BusinessLogic;
using RaheemRestaurant.DataLayer;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace RaheemRestaurant.Pages;

// Partial class for ForgetPasswordPage, handling the logic for password recovery within the application.
public partial class ForgetPasswordPage : ContentPage
{
    // Collection to hold all user data loaded from a JSON file.
    ObservableCollection<Users> _allUsers;

    // Constructor for ForgetPasswordPage, initializes components and loads user data from file.
    public ForgetPasswordPage()
    {
        InitializeComponent();  // Initialize UI components.
        _allUsers = new ObservableCollection<Users>();  // Instantiate the user collection.
        LoadUsersFromFile();  // Load existing users from a local JSON file.
    }

    // Method to load users from a JSON file stored on the user's desktop.
    private void LoadUsersFromFile()
    {
        // Build the file path from the desktop directory.
        string folderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "RaheemRestaurant/RaheemRestaurant/Resources/Raw");
        string filePath = Path.Combine(folderPath, "users.json");

        // Check if the file exists before attempting to read.
        if (File.Exists(filePath))
        {
            string jsonString = File.ReadAllText(filePath);
            // Ensure the JSON string is not empty or null.
            if (!string.IsNullOrWhiteSpace(jsonString))
            {
                try
                {
                    // Deserialize the JSON string to an ObservableCollection of Users.
                    _allUsers = JsonSerializer.Deserialize<ObservableCollection<Users>>(jsonString);
                }
                catch (JsonException ex)
                {
                    // Log or handle JSON deserialization errors.
                    Debug.WriteLine($"JSON deserialization error: {ex.Message}");
                }
            }
        }
    }

    // Event handler for the 'Submit' button click on the Forgot Password form.
    private void SubmitForgetYourPassword_Clicked(object sender, EventArgs e)
    {
        // Check if the email entry is not empty.
        if (string.IsNullOrEmpty(emailEntry.Text))
        {
            DisplayAlert("Alert", "Please enter your email.", "OK");
            return; // Exit early if no email is provided.
        }

        // Try to find a user with the provided email.
        var user = _allUsers.FirstOrDefault(u => u.Email == emailEntry.Text);

        if (user != null)
        {
            // If user is found, enable UI elements to reset the password.
            row3Grid.IsVisible = true;
            DisplayAlert("User Found", "Please enter your new password.", "OK");
        }
        else
        {
            // No user found with the provided email.
            DisplayAlert("Error", "No account associated with that email has been found in our system. Would you like to sign up?", "OK");
        }
    }

    // Event handler for the 'Reset Password' button click.
    private void resetPassword_Clicked(object sender, EventArgs e)
    {
        // Check if the new password entry is not empty.
        if (string.IsNullOrWhiteSpace(passwordEntry.Text))
        {
            DisplayAlert("Error", "Please enter a new password.", "OK");
            return;
        }

        // Find the user again by email to ensure they're still valid.
        var user = _allUsers.FirstOrDefault(u => u.Email == emailEntry.Text);
        if (user != null)
        {
            // Update the user's password in the collection.
            user.Password = passwordEntry.Text;
            // Save the updated user collection back to the JSON file.
            Repository.WriteDataToJsonFile(_allUsers, "users.json");
            // Confirm password update and redirect to the main page.
            DisplayAlert("Success", "Your password has been updated successfully.", "OK");
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            // Handle the case where the user is no longer found in the collection.
            DisplayAlert("Error", "Failed to update password. User not found.", "OK");
        }
    }
}