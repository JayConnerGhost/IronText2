using System.Windows;
using Prism.Regions;

namespace IronText2.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IRegionManager _regionManager;


        public MainWindow(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            InitializeComponent();
            ConfigureInitialLayout();
        }

        private void ConfigureInitialLayout()
        {
            _regionManager.RegisterViewWithRegion("Menu", typeof(MenuView));
            _regionManager.RegisterViewWithRegion("Main", typeof(TextContentView));
            
        }
    }
}
