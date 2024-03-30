// Author: Mohammad Raja

namespace RaheemRestaurant.Pages;

public partial class MainCoursePage : ContentPage
{
    public MainCoursePage(string username)
    {
        InitializeComponent();
        greetingLabel.Text = $"Hey, {username}!";
    }



    int count = 0;

    private void decrementBtnClicked(object sender, EventArgs e)
    {
        if (count !<= 0)
        {
            countLabel.Text = Convert.ToString(count--);
        }
        else { count = 0; }


    }

    private void incrementBtnClicked(object sender, EventArgs e)
    {
        if (count !>= 0)
        {
            countLabel.Text = Convert.ToString(count++);

        }
        else { count = 0; }





    }
}