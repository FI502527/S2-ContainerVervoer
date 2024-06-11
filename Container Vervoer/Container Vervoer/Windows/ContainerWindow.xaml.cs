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
using System.Windows.Shapes;
using Container_Vervoer.Classes;

namespace Container_Vervoer.Windows
{
    /// <summary>
    /// Interaction logic for ContainerWindow.xaml
    /// </summary>
    public partial class ContainerWindow : Window
    {
        int nummerContainers = 0;
        LogicaSchip Logica;
        public ContainerWindow(LogicaSchip logica)
        {
            InitializeComponent();
            VeranderInfo(logica);
            Logica = logica;
        }
        public void VeranderInfo(LogicaSchip logica)
        {
            tLengte.Text = $"Lengte: {logica.Schip.Lengte}";
            tBreedte.Text = $"Breedte: {logica.Schip.Breedte}";
            tGewicht.Text = $"Gewicht: {logica.Schip.MaxGewicht}";
        }

        private void Randomize(object sender, RoutedEventArgs e)
        {
            for (int a = 0; a < Logica.Schip.Lengte; a++)
            {
                for (int b = 0; b < Logica.Schip.Breedte; b++)
                {
                    Container container = new Container(nummerContainers.ToString(), RandomGewicht(), RandomType());
                    nummerContainers++;

                    int huidigeGewicht = Logica.ContainersPlaatsen.Sum(cntrs => cntrs.Gewicht);
                    if (huidigeGewicht + container.Gewicht <= Logica.Schip.MaxGewicht)
                    {
                        lbContainers.Items.Add(container);
                        Logica.ContainersPlaatsen.Add(container);
                    }
                }
            }
        }
        private TypeContainer RandomType()
        {
            //Kies random type
            //https://stackoverflow.com/questions/3132126/how-do-i-select-a-random-value-from-an-enumeration
            Array waardes = Enum.GetValues(typeof(TypeContainer));
            Random random = new Random();
            TypeContainer type = (TypeContainer)waardes.GetValue(random.Next(waardes.Length));
            return type;
        }
        private int RandomGewicht()
        {
            Random random = new Random();
            int nummer = random.Next(4, 30);
            return nummer;
        }
        private void ToevoegenContainer(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(tbGewicht.Text, out int gewicht))
            {
                string typeString = cbType.SelectedItem.ToString().Split(' ').Skip(1).FirstOrDefault();
                TypeContainer type = TypeContainer.Normaal;
                switch (typeString)
                {
                    case "Normaal":
                        type = TypeContainer.Normaal;
                        break;
                    case "Gekoeld":
                        type = TypeContainer.Gekoeld;
                        break;
                    case "Waardevol":
                        type = TypeContainer.Waardevol;
                        break;
                }
                Container container = new Container(nummerContainers.ToString(), gewicht, type);
                nummerContainers++;
                lbContainers.Items.Add(container.ToString());
                Logica.ContainersPlaatsen.Add(container);
            }
            else
            {
                MessageBox.Show("Vul aub alleen nummers in");
            }
        }

        private void Sorteer(object sender, RoutedEventArgs e)
        {
            if (Logica.SorteerContainers())
            {
                ResultaatWindow resultaat = new ResultaatWindow(Logica);
                resultaat.Show();
                this.Hide();
                return;
            }
        }
    }
}
