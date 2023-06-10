namespace NotesApp.Views;

public partial class NotesView: ContentPage
{
    public NotesView()
    {
        InitializeComponent();
        if (MauiProgram.CheckDirection())
            this.FlowDirection = FlowDirection.RightToLeft;
    }
    
    private void btnNew_Clicked(object sender, EventArgs e)
    {
        cv.SelectedItem = new Note();
        txtTitle.Focus();
        //await txtTitle.HideKeyboardAsync(CancellationToken.None);
        txtTitle.IsEnabled = false;
        txtTitle.IsEnabled = true;
        txtDescription.IsEnabled = false;
        txtDescription.IsEnabled = true;
    }

    private void cv_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var di = DeviceInfo.Platform;
        if (di == DevicePlatform.WinUI)
        {
            var t = (Note)e.CurrentSelection.FirstOrDefault();
            SemanticScreenReader.Announce(t.Title + ", " + t.Description);
        }

        if (di != DevicePlatform.WinUI)
            txtTitle.Focus();
    }

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new SettingView());
        WeakReferenceMessenger.Default.Send(new SettingView());
    }
}
