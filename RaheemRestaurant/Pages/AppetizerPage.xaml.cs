using RaheemRestaurant.BusinessLogic;
namespace RaheemRestaurant.Pages;

public partial class AppetizerPage : ContentPage
{
    Food food;
    private double totalPriceFromMainCourse; // Store the total from main course as a field

    // Variables to store the counts of each item
    int cheeseCakeCount = 0;
    int cheeseFriesCount = 0;
    int gulabJamunCount = 0;
    int marinatedRingCount = 0;
    int fruitCharcuterieCount = 0;

    public AppetizerPage(string user, double totalPriceFromMainCourse)
    {
        InitializeComponent();
        this.totalPriceFromMainCourse = totalPriceFromMainCourse;
        greetingLabel.Text = $"{user}";
        food = new Food();
        UpdateTotalPrice();
    }

    private void cheeseCakeStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        cheeseCakeCount = (int)e.NewValue;
        cheeseCakeCountLabel.Text = cheeseCakeCount.ToString();  // Update the label's text
        UpdateTotalPrice();
    }

    private void cheeseFriesStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        cheeseFriesCount = (int)e.NewValue;
        cheeseFriesCountLabel.Text = cheeseFriesCount.ToString();  // Update the label's text
        UpdateTotalPrice();
    }

    private void gulabJamunStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        gulabJamunCount = (int)e.NewValue;
        gulabJamunCountLabel.Text = gulabJamunCount.ToString();  // Update the label's text
        UpdateTotalPrice();
    }

    private void marinatedRingStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        marinatedRingCount = (int)e.NewValue;
        marinatedRingCountLabel.Text = marinatedRingCount.ToString();  // Update the label's text
        UpdateTotalPrice();
    }

    private void fruitCharcuterieStepper_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        fruitCharcuterieCount = (int)e.NewValue;
        fruitCharcuterieCountLabel.Text = fruitCharcuterieCount.ToString();  // Update the label's text
        UpdateTotalPrice();
    }

    // Method to calculate and update the total price
    private void UpdateTotalPrice()
    {
        double total = 4.99 * cheeseCakeCount +
                       5.99 * cheeseFriesCount +
                       6.99 * gulabJamunCount +
                       6.99 * marinatedRingCount +
                       7.99 * fruitCharcuterieCount;

        total += totalPriceFromMainCourse; // Add the total from the main course

        totalLabel.Text = $"Total: ${total:N2}";
    }

    private void totalBtn_Clicked(object sender, EventArgs e)
    {
        UpdateTotalPrice();  // Recalculate total when the total button is clicked
    }
}