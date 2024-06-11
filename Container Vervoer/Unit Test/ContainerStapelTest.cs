using Container_Vervoer;
using Container_Vervoer.Classes;
using System.ComponentModel;
using Container = Container_Vervoer.Classes.Container;

namespace Unit_Test
{
    [TestClass]
    public class ContainerStapelTest
    {
        [TestMethod]
        public void ToevoegenContainerTest()
        {
            //Arrange
            Container container1 = new Container("Container1", 20, TypeContainer.Normaal);
            ContainerStapel stapel = new ContainerStapel();
            stapel.Toevoegen(container1);
            Container container2 = new Container("Container2", 15, TypeContainer.Waardevol);

            //Act
            bool result = stapel.Toevoegen(container2);

            //Assert
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void ToevoegenFoutContainerTest()
        {
            //Arrange
            Container container1 = new Container("Container1", 20, TypeContainer.Waardevol);
            ContainerStapel stapel = new ContainerStapel();
            stapel.Toevoegen(container1);
            Container container2 = new Container("Container2", 15, TypeContainer.Normaal);

            //Act
            bool result = stapel.Toevoegen(container2);

            //Assert
            Assert.IsFalse(result);
        }
    }
}