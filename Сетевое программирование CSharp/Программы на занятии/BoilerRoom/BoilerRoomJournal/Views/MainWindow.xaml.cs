using System.Windows;

namespace BoilerRoomJournal.Views;
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        PageDate.Text = DateTime.Now.ToString();
    }

}