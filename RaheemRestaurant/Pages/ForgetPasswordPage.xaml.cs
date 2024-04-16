// Author: Nawaf Raheem
using RaheemRestaurant.BusinessLogic;
using RaheemRestaurant.DataLayer;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace RaheemRestaurant.Pages;



public partial class ForgetPasswordPage : ContentPage
{
  
    ObservableCollection<Users> _allUsers; 

    public ForgetPasswordPage()
    {
        InitializeComponent();

        
        _allUsers = new ObservableCollection<Users>();

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







    private void SubmitForgetYourPassword_Clicked(object sender, EventArgs e)
    {


        // Ensure an email is entered
        if (string.IsNullOrEmpty(emailEntry.Text))
        {
            DisplayAlert("Alert", "Please enter your email.", "OK");
            return; // Exit early if no email is provided
        }

        // Attempt to find the user by the provided email
        var user = _allUsers.FirstOrDefault(u => u.Email == emailEntry.Text);

        if (user != null)
        {
            // User found, handle the password reset process
            row3Grid.IsVisible = true;
            DisplayAlert("User Found", "Please enter your new password.", "OK");
           
        }
        else
        {
            // No user found with that email
            DisplayAlert("Error", "No account associated with that email has been found in our system. Would you like to sign up?", "OK");
        }



    }

    private void resetPassword_Clicked (object sender, EventArgs e)
    {

        if (string.IsNullOrWhiteSpace(passwordEntry.Text))
        {
            DisplayAlert("Error", "Please enter a new password.", "OK");
            return;
        }

        var user = _allUsers.FirstOrDefault(u => u.Email == emailEntry.Text);
        if (user != null)
        {
            user.Password = passwordEntry.Text; // Update the user's password
            Repository.WriteDataToJsonFile(_allUsers, "users.json"); // Save the updated list to the JSON file
            DisplayAlert("Success", "Your password has been updated successfully.", "OK");
            Navigation.PushAsync(new MainPage());
        }
        else
        {
            DisplayAlert("Error", "Failed to update password. User not found.", "OK");
        }

    }
}