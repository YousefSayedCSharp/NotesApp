namespace NotesApp;

public static class MauiProgram
{
    //start get Connection string Path
    private static ApplicationDBContext _context;
    public static ApplicationDBContext context
    {
        get
        {
            if (_context == null)
                _context = new ApplicationDBContext();

            return _context;
        }
    }
    //end Get Connection String PathConn

    public static MauiApp CreateMauiApp()
    {
        //context.Database.EnsureCreated();

        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");

                fonts.AddFont("FA6Brands.otf", "FAB");
                fonts.AddFont("FA6Regular.otf", "FAR");
                fonts.AddFont("FA6Solid.otf", "FAS");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }

    public static bool CheckDirection()
    {
        bool ch = false;
        int LanguageNumber = Preferences.Get("app_language_key", 0);
        if (LanguageNumber == 1 || (AppResources.Culture == null && CultureInfo.CurrentUICulture.Name.ToLower().StartsWith("ar-")))
            ch = true;

        return ch;
    }
}
