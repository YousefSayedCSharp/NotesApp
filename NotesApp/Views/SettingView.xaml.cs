namespace NotesApp.Views;

public partial class SettingView : ContentPage
{
    public SettingView()
    {
        InitializeComponent();

        if (MauiProgram.CheckDirection())
            this.FlowDirection = FlowDirection.RightToLeft;

        WeakReferenceMessenger.Default.Register<SettingView>(this, (r, m) =>
        {
            LoadLanguage();
            LoadTheme();
        });
    }

    public void LoadLanguage()
    {
        int LanguageNumber = Preferences.Get(NotesAppStatic.LanguageKey, 0);
        switch (LanguageNumber)
        {
            case 1:
                rdoArabic.IsChecked = true;
                break;
            case 2:
                rdoEnglish.IsChecked = true;
                break;
            default:
                rdoSystemLanguage.IsChecked = true;
                break;
        }
    }

    public void LoadTheme()
    {
        int ThemeNumber = Preferences.Get(NotesAppStatic.ThemeKey, 0);
        switch (ThemeNumber)
        {
            case 1:
                rdoLight.IsChecked = true;
                break;
            case 2:
                rdoDark.IsChecked = true;
                break;
            case 0:
                rdoSystemTheme.IsChecked = true;
                break;
        }
    }


    private void btnSave_Clicked(object sender, EventArgs e)
    {
        SaveLanguage();
        SaveTheme();
        //WeakReferenceMessenger.Default.Send(new App());
        App.Current.MainPage = new AppShell();
    }

    public void SaveLanguage()
    {
        if (rdoArabic.IsChecked)
        {
            AppResources.Culture = new CultureInfo("ar");
            Preferences.Set(NotesAppStatic.LanguageKey, 1);
        }
        else if (rdoEnglish.IsChecked)
        {
            AppResources.Culture = new CultureInfo("en");
            Preferences.Set(NotesAppStatic.LanguageKey, 2);
        }
        else if (rdoSystemLanguage.IsChecked)
        {
            var defaultCulture = CultureInfo.DefaultThreadCurrentCulture;
            AppResources.Culture = defaultCulture;
            Preferences.Set(NotesAppStatic.LanguageKey, 0);
        }
    }

    public void SaveTheme()
    {
        if (rdoLight.IsChecked)
        {
            //Use light theme
            App.Current.UserAppTheme = AppTheme.Light;
        }
        else if (rdoDark.IsChecked)
        {
            // Use dark theme
            App.Current.UserAppTheme = AppTheme.Dark;
        }
        else if (rdoSystemTheme.IsChecked)
        {
            // Use system theme
            App.Current.UserAppTheme = AppTheme.Unspecified;
        }

        var appTheme = Application.Current.UserAppTheme;
        Preferences.Set(NotesAppStatic.ThemeKey, (int)appTheme);
    }
}
