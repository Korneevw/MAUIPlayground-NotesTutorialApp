using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MAUIPlayground.Models
{
    internal class AllNotes
    {
        public ObservableCollection<Note> Notes { get; set; } = new ObservableCollection<Note>();
        public AllNotes()
        {
            LoadNotes();
        }

        public void LoadNotes()
        {
            Notes.Clear();

            string appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            IEnumerable<Note> notes = Directory
                .EnumerateFiles(appDataPath, "*.notes.txt")
                .Select(fileName => new Note()
                {
                    FileName = fileName,
                    Text = File.ReadAllText(fileName),
                    Date = File.GetCreationTime(fileName)
                })
                .OrderBy(note => note.Date);

            foreach (Note note in notes)
            {
                Notes.Add(note);
            }
        }
    }
}
