using System.Windows;

namespace WpfAppTest;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    // В MainWindow.xaml в пространстве имен указали привязку на саму себя DataContext="{Binding RelativeSource={RelativeSource Self}
    // Теперь в MainWindow.xaml.cs можно обращатся к этим данным xaml напрямую 
    

    public MainWindow()
    {
        InitializeComponent();

    }
}