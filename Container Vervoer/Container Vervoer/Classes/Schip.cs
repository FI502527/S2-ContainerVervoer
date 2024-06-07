using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace Container_Vervoer.Classes
{
    public class Schip
    {
        public List<Rij> Rijen = new List<Rij>();
        public int MaxGewicht { get; }
        public int Breedte { get; }
        public int Lengte { get; }
        public Schip(int maxGewicht, int breedte, int lengte)
        {
            MaxGewicht = maxGewicht;
            Breedte = breedte;
            Lengte = lengte;
            MaakRijen();
        }
        public void MaakRijen()
        {
            for(int i = 0; i < Breedte; i++)
            {
                Rijen.Add(new Rij(Lengte));
            }
        }
        public int Gewicht()
        {
            int gewicht = 0;
            foreach(Rij rij in Rijen)
            {
                gewicht =+ rij.Gewicht();
            }
            return gewicht;
        }
        public bool ToevoegenContainers(List<Container> containers)
        {
            int gewichtContainers = containers.Sum(container => container.Gewicht);
            if (gewichtContainers + Gewicht() < MaxGewicht / 2 || gewichtContainers + Gewicht() > MaxGewicht)
            {
                throw new Exception("Gewicht te zwaar of te licht.");
            }
            foreach (Container container in containers)
            {
                PlaatsContainer(container);
            }
            return true;
        }
        public bool PlaatsContainer(Container container)
        {
            if (Rijen.Count % 2 != 0)
            {
                if (Rijen[Rijen.Count / 2].ToevoegenContainer(container))
                {
                    return true;
                }
            }
            return PlaatsRichting(container);
        }
        public bool PlaatsRichting(Container container)
        {
            return (LinkseRij().Sum(row => row.Gewicht()) <= RechtseRij().Sum(row => row.Gewicht())
                ? PlaatsLinks(container)
                : PlaatsRechts(container));
        }
        public List<Rij> LinkseRij()
        {
            List<Rij> linkseRij = Rijen.GetRange(0, Rijen.Count / 2);
            linkseRij.Reverse();
            return linkseRij;
        }
        public List<Rij> RechtseRij()
        {
            return Rijen.GetRange(Rijen.Count % 2 == 0 ? Rijen.Count / 2 : Rijen.Count / 2 + 1, Rijen.Count / 2);
        }
        public bool PlaatsLinks(Container container)
        {
            foreach (Rij rij in LinkseRij())
            {
                if (rij.ToevoegenContainer(container))
                {
                    return true;
                }
            }
            return false;
        }
        public bool PlaatsRechts(Container container)
        {
            foreach (Rij rij in RechtseRij())
            {
                if (rij.ToevoegenContainer(container))
                {
                    return true;
                }
            }
            return false;
        }
        public int LinkseGewicht()
        {
            int linkseGewicht = 0;
            foreach (Rij rij in LinkseRij())
            {
                int gewicht = rij.Gewicht();
                linkseGewicht =+ gewicht;
            }
            return linkseGewicht;
        }
        public int RechtseGewicht()
        {
            int rechtseGewicht = 0;
            foreach (Rij rij in RechtseRij())
            {
                int gewicht = rij.Gewicht();
                rechtseGewicht =+ gewicht;
            }
            return rechtseGewicht;
        }
        public bool Balans()
        {
            if (Math.Abs(RechtseGewicht() - LinkseGewicht()) <= 0.2 * Gewicht())
            {
                return true;
            }
            return false;
        }
    }
}
