// Author: Mohammad Raja
using RaheemRestaurant.BusinessLogic;
using RaheemRestaurant.DataLayer;
namespace RaheemRestaurant.Pages;

public partial class MainCoursePage : ContentPage
{

    Food food;
    public MainCoursePage(string username)
    {

        InitializeComponent();
        greetingLabel.Text = $"Hi, {username} !";
        food = new Food();
        
    }

    public int shawarmacount = 0;
    public int niharicount = 0;
    public int manakeeshcount = 0;
    public int biryanicount = 0;
    public int butterchickencount = 0;


    private void chickenShawarmaStepperTest_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        int viewCounter = Convert.ToInt32(chickenShawarmaCountLabel.Text);

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
            chickenShawarmaCountLabel.Text = viewCounter.ToString();
        }

        shawarmacount = viewCounter;
    }

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





    private void totalBtn_Clicked(object sender, EventArgs e)
    {

        double shawarmatotal = 14.99 * shawarmacount; 
        double biryanitotal = 10.00 * biryanicount;
        double butterchickentotal = 12 * butterchickencount;
        double manakeeshtotal = 5 * manakeeshcount;
        double niharitotal = 10 * niharicount;

        double total = shawarmatotal + biryanitotal + butterchickentotal + manakeeshtotal + niharitotal + food.ToppingPrice;  

        totalLabel.Text = $"{total.ToString():C1}";
        

    }

    private void appetizerBtn_Clicked(object sender, EventArgs e)
    {
        // Call the method to calculate the total
        double total = CalculateTotal();

        string user = $"{greetingLabel.Text}";

        // Navigate to AppetizerPage, passing the calculated total
        Navigation.PushAsync(new AppetizerPage( user ,total));

    }

    private double CalculateTotal()
    {
        double shawarmatotal = 14.99 * shawarmacount;
        double biryanitotal = 10.00 * biryanicount;
        double butterchickentotal = 12 * butterchickencount;
        double manakeeshtotal = 5 * manakeeshcount;
        double niharitotal = 10 * niharicount;

        double total = shawarmatotal + biryanitotal + butterchickentotal + manakeeshtotal + niharitotal + food.ToppingPrice;

        return Convert.ToDouble(total);
    }

}