namespace NotesApp;

public partial class App : Application
{
    public App()
    {
        NotesAppStatic.SelectLanguageApp();
        NotesAppStatic.SelectTheme();

        InitializeComponent();

        MainPage = new AppShell();
    }
}
