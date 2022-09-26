using MAUIPlayground.Models;

namespace MAUIPlayground.Views;
[QueryProperty(nameof(NoteFileName), nameof(NoteFileName))]
public partial class NotePage : ContentPage
{
	public string NoteFileName
	{
		set
		{
			LoadNote(value);
		}
	}
	public NotePage()
	{
		InitializeComponent();

		string appLocalFilesPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

		LoadNote(Path.Combine(appLocalFilesPath, randomFileName));
	}

	private void LoadNote(string fileName)
	{
		Note model = new Note();
		model.FileName = fileName;

		if (File.Exists(fileName))
		{
            model.Text = File.ReadAllText(fileName);
			model.Date = File.GetCreationTime(fileName);
        }

		BindingContext = model;
	}

	private async void SaveButtonClicked(object sender, EventArgs e)
	{
		if (BindingContext is Note note)
			File.WriteAllText(note.FileName, TextEditor.Text);

		await Shell.Current.GoToAsync("..");
	}

	private async void DeleteButtonClicked(object sender, EventArgs e)
	{
		if (BindingContext is Note note)
		{
            if (File.Exists(note.FileName))
            {
                File.Delete(note.FileName);
            }
        }

        await Shell.Current.GoToAsync("..");
    }
}