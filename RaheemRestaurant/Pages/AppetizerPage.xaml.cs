using RaheemRestaurant.BusinessLogic;
namespace RaheemRestaurant.Pages;

// Author: Mohammed Raja
// Partial class for the AppetizerPage, handling logic related to appetizer ordering within the application.
public partial class AppetizerPage : ContentPage
{
    // Field to hold Food object, assuming it holds additional data or methods relevant to the food items.
    Food food;

    // Field to store the total price from main course page to carry forward.
    private double totalPriceFromMainCourse;

    // Variables to store the counts of each item in the appetizer menu.
    int cheeseCakeCount = 0;
    int cheeseFriesCount = 0;
    int gulabJamunCount = 0;
    int marinatedRingCount = 0;
    int fruitCharcuterieCount = 0;

    // Constructor for the AppetizerPage that initializes components and sets up initial data.
    public AppetizerPage(string user, double totalPriceFromMainCourse)
    {
        InitializeComponent();  // Initialize the UI components as defined in XAML.
        this.totalPriceFromMainCourse = totalPriceFromMainCourse;  // Store the passed total price from the main course.
        greetingLabel.Text = $"{user}";  // Display greeting with the user's name.
        food = new Food();  // Instantiate the Food object.
        UpdateTotalPrice();  // Update the total price displayed on the page.
    }

    // Event handler for change in Cheese Cake stepper value.
    private void cheeseCakeStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        cheeseCakeCount = (int)e.NewValue;  // Update the cheese cake count.
        cheeseCakeCountLabel.Text = cheeseCakeCount.ToString();  // Update the label's text to reflect new count.
        UpdateTotalPrice();  // Recalculate the total price.
    }

    // Event handler for change in Cheese Fries stepper value.
    private void cheeseFriesStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        cheeseFriesCount = (int)e.NewValue;
        cheeseFriesCountLabel.Text = cheeseFriesCount.ToString();
        UpdateTotalPrice();
    }

    // Similar event handlers for other appetizer items updating their respective counts and total price.
    private void gulabJamunStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        gulabJamunCount = (int)e.NewValue;
        gulabJamunCountLabel.Text = gulabJamunCount.ToString();
        UpdateTotalPrice();
    }

    private void marinatedRingStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        marinatedRingCount = (int)e.NewValue;
        marinatedRingCountLabel.Text = marinatedRingCount.ToString();
        UpdateTotalPrice();
    }

    private void fruitCharcuterieStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        fruitCharcuterieCount = (int)e.NewValue;
        fruitCharcuterieCountLabel.Text = fruitCharcuterieCount.ToString();
        UpdateTotalPrice();
    }

    // Method to calculate and update the total price of the appetizers plus the total from the main course.
    private void UpdateTotalPrice()
    {
        // Calculate the total based on item counts and their prices.
        double total = 4.99 * cheeseCakeCount +
                       5.99 * cheeseFriesCount +
                       6.99 * gulabJamunCount +
                       6.99 * marinatedRingCount +
                       7.99 * fruitCharcuterieCount;

        total += totalPriceFromMainCourse; // Add the total from the main course.

        totalLabel.Text = $"Total: ${total:N2}"; // Display the formatted total.
    }

    // Event handler for the 'Total' button click, to recalculate the total.
    private void totalBtn_Clicked(object sender, EventArgs e)
    {
        UpdateTotalPrice();  // Recalculate and update the total price displayed.
    }

    //Nawaf Making edits to unused pages
    private void checkoutPageBtnClicked(object sender, EventArgs e)
    {
        DisplayAlert("Coming Soon", "Checkout Page is not yet available an attendant has been notified and will verify your order", "OK");
    }

    private void dessertAndDrinksClicked(object sender, EventArgs e)
    {
        DisplayAlert("Coming Soon", "Dessert and Drinks are not yet available due to a restaurant Supply Issue", "OK");
    }
}