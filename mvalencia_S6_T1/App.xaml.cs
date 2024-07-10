namespace mvalencia_S6_T1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Views.vEstudiante());
        }
    }
}