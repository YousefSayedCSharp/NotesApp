namespace NotesApp;

public static class NotesAppStatic
{
    public const string LanguageKey = "app_language_key";
    public const string ThemeKey = "app_theme_key";

    public static void SelectLanguageApp()
    {
        int LanguageNumber = Preferences.Get(LanguageKey, 0);
        switch (LanguageNumber)
        {
            case 1:
                //Set Arabic 
                AppResources.Culture = new CultureInfo("ar");
                break;
            case 2:
                //set english
                AppResources.Culture = new CultureInfo("en");
                break;
        }
    }

    public static void SelectTheme()
    {
        Application.Current.UserAppTheme = AppTheme.Unspecified;
        int themeNum = Preferences.Get(ThemeKey, 0);
        switch (themeNum)
        {
            case 1:
                //set laight
                Application.Current.UserAppTheme = AppTheme.Light;
                break;
            case 2:
                //set dark
                Application.Current.UserAppTheme = AppTheme.Dark;
                break;
            case 0:
                //as system default
                Application.Current.UserAppTheme = AppTheme.Unspecified;
                break;
        }
    }

}
