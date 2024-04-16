// Author: Mohammad Raja

namespace RaheemRestaurant.Pages;

public partial class MainCoursePage : ContentPage
{
    public MainCoursePage(string username)
    {

        InitializeComponent();
        greetingLabel.Text = $"Hey, {username}!";
        
    }



    public int count = 0;

    

    


    private void ShawarmaStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int viewCounter = Convert.ToInt32(countLabel.Text);

         viewCounter = (int)e.NewValue; // Get the new value from the event args directly

        if (viewCounter < 0)
        {
            DisplayAlert("Error", "Can't order a negative item", "Okay");
            // Reset the stepper's value if it's negative
            ((Stepper)sender).Value = 0;
        }
        else
        {
            // Update the label with the new count
            countLabel.Text = viewCounter.ToString();
        }


    }


}