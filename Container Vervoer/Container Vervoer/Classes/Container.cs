using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Container_Vervoer.Classes
{
    public class Container
    {
        public string Naam { get; }
        public int Gewicht { get; } //IN TON NIET KG
        public Type Type { get; }

        public Container(string naam, int gewicht, Type type)
        {
            Naam = naam;
            Gewicht = gewicht;
            Type = type;
        }
        public override string ToString()
        {
            return $"Container {Naam} is {Gewicht} ton en {Type}";
        }
    }
}

