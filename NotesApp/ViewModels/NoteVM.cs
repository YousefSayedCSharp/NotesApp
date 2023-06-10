namespace NotesApp.ViewModels;

public partial class NoteVM : BaseVM
{
    private NoteEntity DataHelper;

    public NoteVM()
    {
        DataHelper = new();
        ClearAsync();
    }

    public async void ClearAsync()
    {
        NoteTitle = "";
        NoteDescription = "";

        SelectedNote = new();

        Notes = await DataHelper.GetAllAsync();
        btnAddText = AppResources.txtBtnAdd;
    }

    public void SelectNote(int id) =>
        SelectedNote = Notes.FirstOrDefault(n => n.Id == id);

    private string _NoteTitle;
    public string NoteTitle { get => _NoteTitle; set => SetValue(ref _NoteTitle, value); }

    private string _NoteDescription;
    public string NoteDescription { get => _NoteDescription; set => SetValue(ref _NoteDescription, value); }

    private string _btnAddText;
    public string btnAddText { get => _btnAddText; set => SetValue(ref _btnAddText, value); }

    private Note _SelectedNote;
    public Note SelectedNote
    {
        get => _SelectedNote;
        set
        {
            if (value!=null&& value.Id>=1)
            {
                SetValue(ref _SelectedNote, value);
                NoteTitle = SelectedNote.Title;
                NoteDescription = SelectedNote.Description;
                btnAddText = AppResources.txtBtnSave;
            }
        }
    }

    private List<Note> _Notes;
    public List<Note> Notes{get => _Notes;set => SetValue(ref _Notes,value);}

    public ICommand btnNewCommand =>
    new Command(() =>
        ClearAsync());

    public ICommand btnSaveCommand =>
        new Command(async () =>
        {   
            if (btnAddText == "Save"|| btnAddText == "حفظ")
            {
                SelectedNote.Title = NoteTitle.Trim();
                SelectedNote.Description = NoteDescription.Trim();
                await DataHelper.UpdateAsync(SelectedNote);
            }
            else if(btnAddText=="Add"|| btnAddText == "إضافة")
            {
                Note note = new();
                note.Title = NoteTitle.Trim();
                note.Description = NoteDescription.Trim();
                await DataHelper.AddAsync(note  );
            }
            ClearAsync();
        });

    public ICommand DeleteNoteCommand =>
    new Command(async (id) =>
    {
            SelectNote((int)id);

        var ch = await App.Current.MainPage.DisplayAlert("Delete" + SelectedNote.Id + ". " + SelectedNote.Title, "do you wont delete this note?", "Delete", "Cancel");
        if (ch)
        {
            await DataHelper.RemoveAsync(SelectedNote);
            ClearAsync();
        }
    });

    public ICommand btnSelectCommand =>
    new Command((id) =>
    {
        SelectNote((int)id);
    });

    private string _txtBtnClear;
    public string txtBtnClear { get => _txtBtnClear; set => SetValue(ref _txtBtnClear, value); } //= AppResources.Welcome;
}
