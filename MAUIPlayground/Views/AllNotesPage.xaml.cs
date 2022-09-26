using MAUIPlayground.Models;

namespace MAUIPlayground.Views;

public partial class AllNotesPage : ContentPage
{
	public AllNotesPage()
	{
		InitializeComponent();

		BindingContext = new AllNotes();
	}

	protected override void OnAppearing()
	{
		((AllNotes)BindingContext).LoadNotes();
	}

	private async void AddClicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync(nameof(NotePage));
	}

	private async void NotesCollectionSelectionChanged(object sender, SelectionChangedEventArgs e)
	{
		if(e.CurrentSelection.Count != 0)
		{
			Note note = (Note)e.CurrentSelection[0];

			await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.NoteFileName)}={note.FileName}");

			notesCollection.SelectedItem = null;
		}
	}
}