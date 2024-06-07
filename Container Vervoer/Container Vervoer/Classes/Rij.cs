using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Container_Vervoer.Classes
{
    public class Rij
    {
        public List<ContainerStapel> ContainerStapel = new List<ContainerStapel>();
        public Rij(int lengte)
        {
            MaakStapel(lengte);
        }
        public void MaakStapel(int lengte)
        {
            for(int i = 0; i< lengte; i++)
            {
                ContainerStapel.Add(new ContainerStapel());
            }
        }
        public bool ToevoegenContainer(Container container)
        {
            switch (container.Type)
            {
                case Type.Waardevol:
                    return ToevoegenWaardevol(container);
                case Type.Gekoeld:
                    return ToevoegenGekoeld(container);
                case Type.Normaal:
                    return ToevoegenNormaal(container);
            }
            return false;
        }
        public bool ToevoegenGekoeld(Container container)
        {
            return ContainerStapel.First().Toevoegen(container);
        }
        public bool ToevoegenNormaal(Container container)
        {
            foreach (ContainerStapel stapel in ContainerStapel.Skip(1))
            {
                if (stapel.Toevoegen(container) == true)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ToevoegenWaardevol(Container container)
        {
            for (int nummer = 0; nummer < ContainerStapel.Count; nummer++)
            {
                if (nummer % 2 == 0)
                {
                    if (ContainerStapel[nummer].Toevoegen(container))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public int Gewicht()
        {
            int gewicht = 0;
            foreach (ContainerStapel stapel in ContainerStapel)
            {
                gewicht =+ stapel.Gewicht();
            }
            return gewicht;
        }
    }
}
