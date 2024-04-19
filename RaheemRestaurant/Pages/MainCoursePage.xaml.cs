// Author: Mohammad Raja
using RaheemRestaurant.BusinessLogic;
namespace RaheemRestaurant.Pages;


// Defines a partial class for the MainCoursePage, handling the business logic for main course selections and interactions.

public partial class MainCoursePage : ContentPage
{

    Food food;

    // Constructor that initializes components and sets up the page environment.

    public MainCoursePage(string username)
    {

        InitializeComponent();
        greetingLabel.Text = $"Hi, {username} !";
        food = new Food();
        
    }
    // Variables to store the count of each main course item ordered.

    public int shawarmacount = 0;
    public int niharicount = 0;
    public int manakeeshcount = 0;
    public int biryanicount = 0;
    public int butterchickencount = 0;

    // Event handler for value changes in the chicken shawarma stepper.

    private void chickenShawarmaStepperTest_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        // Get the current value displayed in the label and update it based on the stepper's new value.

        int viewCounter = Convert.ToInt32(chickenShawarmaCountLabel.Text);

         viewCounter = (int)e.NewValue; // Get the new value from the event args directly

        // Prevent negative quantities.

        if (viewCounter < 0)
        {
            DisplayAlert("Error", "Can't order a negative item", "Okay");
            // Reset the stepper's value if it's negative
            ((Stepper)sender).Value = 0;
        }
        else
        {
            // Update the label with the new count
            chickenShawarmaCountLabel.Text = viewCounter.ToString();
        }

        shawarmacount = viewCounter;
    }

    // Similar event handlers for other dishes like butter chicken, biryani, manakeesh, and nihari.
    // Each handler follows the same pattern to update dish counts based on stepper interactions and ensures no negative values.
    private void butterChickenstepperTest_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int viewCounter = Convert.ToInt32(butterChickenCountLabel.Text);

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
            butterChickenCountLabel.Text = viewCounter.ToString();
        }

        butterchickencount = viewCounter;
    }

    private void chickenBiryaniStepperTest_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int viewCounter = Convert.ToInt32(chickenBiryaniCountLabel.Text);

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
            chickenBiryaniCountLabel.Text = viewCounter.ToString();
        }

        biryanicount = viewCounter;

    }

    private void manakeeshStepperTest_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int viewCounter = Convert.ToInt32(manakeeshCountLabel.Text);

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
            manakeeshCountLabel.Text = viewCounter.ToString();
        }

        manakeeshcount = viewCounter;
    }

    private void nihariStepperTest_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int viewCounter = Convert.ToInt32(nihariCountLabel.Text);

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
            nihariCountLabel.Text = viewCounter.ToString();
        }
        niharicount = viewCounter;
    }

    // Methods to handle property changes for various toppings for each dish.
    // These methods typically check if a dish's count is more than one to apply toppings and adjust the food's topping price accordingly.
    // If a switch is toggled on, the price for that topping is added; if toggled off, the price is subtracted.
    // This logic ensures that topping prices are adjusted dynamically as users customize their dish with different toppings.

    private void chickenShawarmaLettuceTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (shawarmacount > 1)
        {
            ShawarmaTopping_PropertyChanged(sender, e);
        }
    }

    private void chickenShawarmaCucumberTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (shawarmacount > 1)
        {
            ShawarmaTopping_PropertyChanged(sender, e);
        }
    }

    private void butterChickenLettuceTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (butterchickencount > 1)
        {
            ButterChickenTopping_PropertyChanged(sender, e);
        }
    }

    private void butterChickenTomatoTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (butterchickencount > 1)
        {
            ButterChickenTopping_PropertyChanged(sender, e);
        }
    }

    private void butterChickenPickleTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (butterchickencount > 1)
        {
            ButterChickenTopping_PropertyChanged(sender, e);
        }
    }

    private void butterChickenOlivesTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (butterchickencount > 1)
        {
            ButterChickenTopping_PropertyChanged(sender, e);
        }
    }

    private void butterChickenCucumberTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (butterchickencount > 1)
        {
            ButterChickenTopping_PropertyChanged(sender,e);
        }
    }

    private void chickenBiryaniLettuceTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (biryanicount > 1)
        {
            BiryaniTopping_PropertyChanged(sender, e);
        }
    }

    private void chickenBiryaniTomatoTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (biryanicount > 1)
        {
            BiryaniTopping_PropertyChanged(sender, e);
        }
    }

    private void chickenBiryaniPickleTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (biryanicount > 1)
        {
            BiryaniTopping_PropertyChanged(sender, e);
        }
    }

    private void chickenBiryaniOlivesTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (biryanicount > 1)
        {
            BiryaniTopping_PropertyChanged(sender, e);
        }
    }

    private void chickenBiryaniCucumberTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (biryanicount > 1)
        {
            BiryaniTopping_PropertyChanged(sender, e);
        }
    }

    private void manakeeshLettuceTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (manakeeshcount > 1)
        {
            ManakeeshTopping_PropertyChanged(sender, e);
        }
    }

    private void manakeeshTomatoTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (manakeeshcount > 1)
        {
            ManakeeshTopping_PropertyChanged(sender, e);
        }
    }

    private void manakeeshPickleTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (manakeeshcount > 1)
        {
            ManakeeshTopping_PropertyChanged(sender, e);
        }
    }

    private void manakeeshOlivesTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (manakeeshcount > 1)
        {
            ManakeeshTopping_PropertyChanged(sender, e);
        }
    }

    private void manakeeshCucumberTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (manakeeshcount > 1)
        {
            ManakeeshTopping_PropertyChanged(sender, e);
        }
    }

    private void nihariLettuceTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (niharicount > 1)
        {
            NihariTopping_PropertyChanged(sender, e);
        }
    }

    private void nihariTomatoTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (niharicount > 1)
        {
            NihariTopping_PropertyChanged(sender, e);
        }
    }

    private void nihariPickleTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (niharicount > 1)
        {
            NihariTopping_PropertyChanged(sender, e);
        }
    }

    private void nihariOlivesTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (niharicount > 1)
        {
            NihariTopping_PropertyChanged(sender, e);
        }
    }

    private void nihariCucumberTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (niharicount > 1)
        {
            NihariTopping_PropertyChanged(sender, e);
        }
    }

    private void chickenShawarmaTomatoTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (shawarmacount > 1)
        {
            ShawarmaTopping_PropertyChanged(sender, e);
        }
    }

    private void chickenShawarmaPickleTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (shawarmacount > 1)
        {
            ShawarmaTopping_PropertyChanged(sender, e);
        }
    }

    private void chickenShawarmaOlivesTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (shawarmacount > 1)
        {
            ShawarmaTopping_PropertyChanged(sender, e);
        }
    }

    private void ShawarmaTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsToggled")
        {
            var toggle = sender as Switch;
            if (toggle != null)
            {
                // Adjust the topping price based on the toggle state
                if (toggle.IsToggled)
                {
                    food.ToppingPrice += 1 * shawarmacount; // Increment topping price by $1
                }
                else
                {
                    food.ToppingPrice -= 1 * shawarmacount;  // Decrement topping price by $1
                }
            }
        }
    }


    private void BiryaniTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsToggled")
        {
            var toggle = sender as Switch;
            if (toggle != null)
            {
                // Adjust the topping price based on the toggle state
                if (toggle.IsToggled)
                {
                    food.ToppingPrice += 1 * biryanicount; // Increment topping price by $1
                }
                else
                {
                    food.ToppingPrice -= 1 * biryanicount;  // Decrement topping price by $1
                }
            }
        }
    }

    private void ManakeeshTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsToggled")
        {
            var toggle = sender as Switch;
            if (toggle != null)
            {
                // Adjust the topping price based on the toggle state
                if (toggle.IsToggled)
                {
                    food.ToppingPrice += 1 * manakeeshcount; // Increment topping price by $1
                }
                else
                {
                    food.ToppingPrice -= 1 * manakeeshcount;  // Decrement topping price by $1
                }
            }
        }
    }

    private void NihariTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsToggled")
        {
            var toggle = sender as Switch;
            if (toggle != null)
            {
                // Adjust the topping price based on the toggle state
                if (toggle.IsToggled)
                {
                    food.ToppingPrice += 1 * niharicount; // Increment topping price by $1
                }
                else
                {
                    food.ToppingPrice -= 1 * niharicount;  // Decrement topping price by $1
                }
            }
        }
    }

    private void ButterChickenTopping_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == "IsToggled")
        {
            var toggle = sender as Switch;
            if (toggle != null)
            {
                // Adjust the topping price based on the toggle state
                if (toggle.IsToggled)
                {
                    food.ToppingPrice += 1 * butterchickencount; // Increment topping price by $1
                }
                else
                {
                    food.ToppingPrice -= 1 * butterchickencount;  // Decrement topping price by $1
                }
            }
        }
    }




    // Method to calculate the total price for all selected dishes and toppings.
    private void totalBtn_Clicked(object sender, EventArgs e)
    {
        double shawarmatotal = 15 * shawarmacount;  // Calculate total price for chicken shawarma.

        double biryanitotal = 17.99 * biryanicount;  // Calculate total price for biryani.

        double butterchickentotal = 12 * butterchickencount;  // Calculate total price for butter chicken.

        double manakeeshtotal = 15 * manakeeshcount;  // Calculate total price for manakeesh.

        double niharitotal = 15 * niharicount;  // Calculate total price for nihari.

        double total = shawarmatotal + biryanitotal + butterchickentotal + manakeeshtotal + niharitotal + food.ToppingPrice;  // Sum up all dish totals and topping price.
        totalLabel.Text = $"{total.ToString("C")}";  // Display the formatted total price.
    }



    // Method to navigate to the AppetizerPage with the calculated total price.
    private void appetizerBtn_Clicked(object sender, EventArgs e)
    {
        double total = CalculateTotal();  // Calculate the total from helper method.

        string user = $"{greetingLabel.Text}";  // Retrieve the user's name.

        Navigation.PushAsync(new AppetizerPage(user, total));  // Navigate to AppetizerPage with the user's name and calculated total.
    }

    // Helper method to calculate the total price for all selected dishes and toppings.

    private double CalculateTotal()
    {
        double shawarmatotal = 14.99 * shawarmacount;  // Calculate total price for chicken shawarma.
        double biryanitotal = 10.00 * biryanicount;  // Calculate total price for biryani.
        double butterchickentotal = 12 * butterchickencount;  // Calculate total price for butter chicken.
        double manakeeshtotal = 5 * manakeeshcount;  // Calculate total price for manakeesh.
        double niharitotal = 10 * niharicount;  // Calculate total price for nihari.

        double total = shawarmatotal + biryanitotal + butterchickentotal + manakeeshtotal + niharicount + food.ToppingPrice;  // Sum up all dish totals and topping price.
        return Convert.ToDouble(total);  // Return the total price as a double.
    }

    //Nawaf Making Edits to unused Pages
    private void CheckoutPageButton_Clicked(object sender, EventArgs e)
    {
        DisplayAlert("Coming Soon", "Checkout Page is not yet available an attendant has been notified and will verify your order", "OK");
    }

    private void dessertAndDrinksBtnPressed(object sender, EventArgs e)
    {
        DisplayAlert("Coming Soon", "Dessert and Drinks are not yet available due to a restaurant supply issue", "OK");
    }
}