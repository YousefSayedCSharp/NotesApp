using Android.App;
using Android.Content.PM;
using Android.OS;
using NotesApp.Resources.Strings;

namespace NotesApp;

[Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        //if (AppResources.Culture != null && AppResources.Culture.ToString() == "ar")
        //Preferences.Set("app_language_key", 0);
        int LanguageNumber = Preferences.Get("app_language_key", 0);
        if (LanguageNumber == 1||(AppResources.Culture==null&& CultureInfo.CurrentUICulture.Name.ToLower().StartsWith("ar-")))
            Window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Rtl;
        else
            Window.DecorView.LayoutDirection = Android.Views.LayoutDirection.Ltr;

    }
}
