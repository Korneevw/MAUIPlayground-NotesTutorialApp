using MAUIPlayground.Models;

namespace MAUIPlayground.Views;

public partial class NewPage1 : ContentPage
{
	public NewPage1()
	{
		InitializeComponent();
	}

	private async void AuthorButtonClicked(object sender, EventArgs e)
	{
		if (BindingContext is About model)
		{
            await Launcher.Default.OpenAsync(model.AuthorURL);
        }
	}
}