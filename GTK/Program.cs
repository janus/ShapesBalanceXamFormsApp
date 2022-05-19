using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.GTK;
using ShapesBalanceXamFormsApp;
namespace GTK
{
    class MainClass
    {
        [STAThread]
        public static void Main(string[] args)
        {
            Gtk.Application.Init();
            Forms.Init();

            var app = new App();
            var window = new FormsWindow();
            window.LoadApplication(app);
            window.SetApplicationTitle("Forms App");
            window.Show();

            Gtk.Application.Run();
        }
    }
}
