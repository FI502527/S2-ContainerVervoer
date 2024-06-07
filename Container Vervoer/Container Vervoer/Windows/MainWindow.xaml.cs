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
using Container_Vervoer.Windows;

namespace Container_Vervoer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitButton(object sender, RoutedEventArgs e)
        {
            LogicaSchip logica = new LogicaSchip(int.Parse(tbLengte.Text), int.Parse(tbBreedte.Text), int.Parse(tbGewicht.Text));
            ContainerWindow container = new ContainerWindow(logica);
            container.Show();
            this.Close();
        }
    }
}
