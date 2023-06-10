namespace NotesApp.Views;

public partial class LoadingApp : ContentPage
{
    public LoadingApp()
    {
        InitializeComponent();
        load();
    }

    //protected override void OnAppearing()
    public async void load()
    {
        //base.OnAppearing();
        await Task.Run(MauiProgram.context.Database.EnsureCreated);
        await Shell.Current.GoToAsync("///NotesView");
    }
}