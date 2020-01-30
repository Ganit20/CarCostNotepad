using CarCostNotepad.Model;
using CarCostNotepad.View;
using CarCostNotepad.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CarCostNotepad.View.PopupWindows;
using CarCostNotepad.View.SettingsWindows;

namespace CarCostNotepad
{

    public partial class MainWindow : Window
    {
        public List<Card> CardList = new List<Card>();
        public List<IMainObject> Objects = new List<IMainObject>();
        Settings Config;
        public MainWindow()
        {

            InitializeComponent();
            Settings config = new SaveSystem().LoadSettings();
            Config = config;
            new MainWindowViewModel().LoadObjects(this,Config);
        }

        
        private void MoveState(object sender, RoutedEventArgs e)
        {
            var card = (Card)MainFrame.Content;
            card.MoveState();
        }

        private void Choose(object sender, RoutedEventArgs e)
        {
            var card = (Card) MainFrame.Content;
            var choose = new ChooseWindows(card.MObject,Config);
            choose.ShowDialog();

            MainFrame.Navigate(new Card(choose.Result,Config));
            var CardObject = CardList.IndexOf(CardList.Find(e => e.MObject.Name == choose.Result.Name));
            CardList[CardObject].MObject = choose.Result;
            new SaveSystem().Save(choose.Result);
        }

        private void AddC(object sender, RoutedEventArgs e)
        {
            var create = new MainObjectCreator(Config,this);
            create.ShowDialog();
            new MainWindowViewModel().LoadObjects(this,Config);
        }

        private void Settings(object sender, RoutedEventArgs e)
        {
            var set = new SettingsWindow(Config) ;
            set.ShowDialog();
        }
    }
}
