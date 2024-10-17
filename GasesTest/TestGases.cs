using Assignment2OOP; 

namespace GasesTest
{
    [TestClass]
    public class TestGases
    {

        [TestMethod]
        public void TestGetThickness()
        {
            
            Gases ozone = new Ozone('Z', 5);
            ozone.GetThickness(1.5);
            Assert.AreEqual(3.5, ozone.thickness);
        }

        [TestMethod]
        public void TestMergeGasesSameType()
        {
          
            Gases gases1 = new Oxygen('X', 2);
            Gases gases2 = new Oxygen('X', 3);
            gases1.MergeGases(gases2);

            Assert.AreEqual(5.0, gases1.thickness);
        }

        [TestMethod]
        public void TestMergeGasesDifferentType()
        {

            Gases gases1 = new Oxygen('X', 2);
            Gases gases2 = new Ozone('Z', 3);

            gases1.MergeGases(gases2);
            Assert.AreEqual(2, gases1.thickness);
        }


        [TestMethod]
        public void TestCheckThicknes() {
            Gases CarbonD1 = new CarbonDioxide('C', 2);
            bool result1 =  CarbonD1.CheckThickness();
            Assert.IsTrue(result1);

            Gases CarbonD2 = new CarbonDioxide('C', 0.4);
            bool result2 = CarbonD1.CheckThickness();
            Assert.IsTrue(result2);
        }

        //tests under Other

        [TestMethod]
        public void TestChangeOzoneUnderOther()
        {
            Gases ozone = new Ozone('Z', 12);
            IVariables other = Other.Instance();

            double newLayerThickness = ozone.thickness * 0.05;
            Gases expectedL = new Oxygen('X', newLayerThickness);

            Gases result = other.ChangeOzone((Ozone)ozone);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Oxygen));
        }

        [TestMethod]
        public void TestChangeOxygenUnderOther()
        {
            Gases oxygen = new Oxygen('X', 12);
            IVariables other = Other.Instance();

            double newLayerThickness = oxygen.thickness * 0.1;
            Gases expectedL = new CarbonDioxide('c', newLayerThickness);

            Gases result = other.ChangeOxygen((Oxygen)oxygen);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CarbonDioxide));
        }

        [TestMethod]
        public void TestChangeCarbonDUnderOther()
        {
            Gases carbond = new CarbonDioxide('C', 4);
            IVariables other = Other.Instance();

            double newLayerThickness = carbond.thickness * 1;
            Gases expectedL = new CarbonDioxide('C', newLayerThickness);

            Gases result = other.ChangeCarbonD((CarbonDioxide)carbond);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CarbonDioxide));
        }

        //under Thunderstorm

        [TestMethod]
        public void TestChangeCarbonDUnderThunderstorm()
        {
            Gases carbond = new CarbonDioxide('C', 2);
            IVariables thunderstorm = Thunderstorm.Instance();

            double newLayerThickness = carbond.thickness * 1;
            Gases expectedL = new CarbonDioxide('C', newLayerThickness);

            Gases result = thunderstorm.ChangeCarbonD((CarbonDioxide)carbond);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(CarbonDioxide));
        }

        [TestMethod]
        public void TestChangeOzoneUnderThunderstorm()
        {
            Gases ozone = new Ozone('Z', 0.8);
            IVariables thunderstorm = Thunderstorm.Instance();

            double newLayerThickness = ozone.thickness * 1;
            Gases expectedL = new Ozone('Z', newLayerThickness);

            Gases result = thunderstorm.ChangeOzone((Ozone)ozone);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Ozone));
        }


        [TestMethod]
        public void TestChangeOxygenUnderThunderstorm()
        {
            Gases oxygen = new Oxygen('X', 1.5);
            IVariables thunderstorm = Thunderstorm.Instance();

            double newLayerThickness = oxygen.thickness * 0.5;
            Gases expectedL = new Ozone('Z', newLayerThickness);

            Gases result = thunderstorm.ChangeOxygen((Oxygen)oxygen);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Ozone));
        }

        //Tests under Sunshine 
        [TestMethod]
        public void TestChangeOxygenUnderSunshine()
        {
            Gases oxygen = new Oxygen('X', 15);
            IVariables sunshine = Sunshine.Instance();

            double newLayerThickness = oxygen.thickness * 0.05;
            Gases expectedL = new Ozone('Z', newLayerThickness);

            Gases result = sunshine.ChangeOxygen((Oxygen)oxygen);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Ozone));
        }

        [TestMethod]

        public void TestChangeOzoneUnderSunshine()
        {
            Gases ozone = new Ozone('Z', 0.8);
            IVariables sunshine = Sunshine.Instance();

            double newLayerThickness = ozone.thickness * 1;
            Gases expectedL = new Ozone('Z', newLayerThickness);

            Gases result = sunshine.ChangeOzone((Ozone)ozone);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Ozone));
        }

        [TestMethod]

        public void TestChangeCarbonDUnderSunshine()
        {
            Gases carbond = new CarbonDioxide('C', 12);
            IVariables sunshine = Sunshine.Instance();

            double newLayerThickness = carbond.thickness * 0.05;
            Gases expectedL = new Oxygen('X', newLayerThickness);

            Gases result = sunshine.ChangeCarbonD((CarbonDioxide)carbond);
            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Oxygen));
        }

        //Test when the newly created layers thickness is less than 0.5
        [TestMethod]

        public void TestChangeCarbonDUnderSunshineGetNull()
        {
            Gases carbond = new CarbonDioxide('C', 8);
            IVariables sunshine = Sunshine.Instance();

            double newLayerThickness = carbond.thickness * 0.05;
            Gases expectedL = new Oxygen('X', newLayerThickness);

            Gases result = sunshine.ChangeCarbonD((CarbonDioxide)carbond);
            Assert.IsNull(result);
            
        }

        [TestMethod]
        public void TestChangeOxygenUnderSunshineGetNull()
        {
            Gases oxygen = new Oxygen('X', 0.8);
            IVariables sunshine = Sunshine.Instance();

            double newLayerThickness = oxygen.thickness * 0.05;
            Gases expectedL = new Ozone('Z', newLayerThickness);

            Gases result = sunshine.ChangeOxygen((Oxygen)oxygen);
            Assert.IsNull(result);
            
        }

        [TestMethod]
        public void TestChangeOzoneUnderOtherGetNull()
        {
            Gases ozone = new Ozone('Z', 1);
            IVariables other = Other.Instance();

            double newLayerThickness = ozone.thickness * 0.05;
            Gases expectedL = new Oxygen('X', newLayerThickness);

            Gases result = other.ChangeOzone((Ozone)ozone);
            Assert.IsNull(result);
           
        }


    }
}