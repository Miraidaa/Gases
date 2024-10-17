using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP
{
   public interface IVariables
    {
        Gases ChangeOxygen(Oxygen X);
        Gases ChangeOzone(Ozone Z);
        Gases ChangeCarbonD(CarbonDioxide CD); 
      
    }


   public  class Thunderstorm : IVariables
    {
        public Gases ChangeOxygen(Oxygen X)
        {
            double toBeReduced = X.thickness * 0.5;
            X.GetThickness(toBeReduced);
            Gases newLayer = new Ozone('Z', toBeReduced);
           
            if (newLayer.CheckThickness()) { 
                Console.WriteLine($"New Ozone layer created: {newLayer}");
                return newLayer;
            } 
            else{
                Console.WriteLine($"The newly created layer was destroyed due to unacceptable thickness: {newLayer}");
                return null; 
            }
           

        }

        public Gases ChangeOzone(Ozone Z)
        {
           
            return Ozone.Instance();
        }

        public Gases ChangeCarbonD(CarbonDioxide CD)
        {
           
            return CarbonDioxide.Instance();
        }

        private Thunderstorm() { }
        private static Thunderstorm instance = null;

        public static Thunderstorm Instance()
        {

            if (instance == null)
            {
                instance = new Thunderstorm();
            }
            return instance;

        }
    }


   public  class Sunshine : IVariables
    {
        public Gases ChangeOxygen(Oxygen X)
        {
            double toBeReduced = X.thickness * 0.05;
            X.GetThickness(toBeReduced);
            Gases newLayer = new Ozone('Z', toBeReduced);
          
            if (newLayer.CheckThickness()) {
                Console.WriteLine($"New Ozone layer created: {newLayer}");
                return newLayer;
            }
            else
            {
                Console.WriteLine($"The newly created layer was destroyed due to unacceptable thickness: {newLayer}");
                return null;
            }


        }

        public Gases ChangeOzone(Ozone Z)
        {
          
            return Ozone.Instance();
        }

        public Gases ChangeCarbonD(CarbonDioxide CD)
        {
            double toBeReduced = CD.thickness * 0.05;
            CD.GetThickness(toBeReduced);
             Gases newLayer = new Oxygen('X', toBeReduced);
           
            if (newLayer.CheckThickness()) { 
                Console.WriteLine($"New Oxygen layer created: {newLayer}"); 
                return newLayer;
            }
            else
            {
                Console.WriteLine($"The newly created layer was destroyed due to unacceptable thickness: {newLayer}");
                return null;
            }
        }


        private Sunshine() { }
        private static Sunshine instance = null;

        public static Sunshine Instance()
        {

            if (instance == null)
            {
                instance = new Sunshine();
            }
            return instance;

        }
    }



    public class Other : IVariables
    {
        public Gases ChangeOxygen(Oxygen X)
        {
            double toBeReduced = X.thickness * 0.1;
            X.GetThickness(toBeReduced);
            Gases newLayer = new CarbonDioxide('C', toBeReduced);
            if (newLayer.CheckThickness())
            {
                Console.WriteLine($"New Carbon Dioxide layer created: {newLayer}");
                return newLayer;
            }
            else
            {
                Console.WriteLine($"The newly created layer was destroyed due to unacceptable thickness: {newLayer}");
                return null;
            }

        }

        public Gases ChangeOzone(Ozone Z)
        {
            double toBeReduced = Z.thickness * 0.05;
            Z.GetThickness(toBeReduced);
            Gases newLayer = new Oxygen('X', toBeReduced);
            if (newLayer.CheckThickness())
            {
                Console.WriteLine($"New Oxygen layer created: {newLayer}");
                return newLayer;
            }
            else
            {
                Console.WriteLine($"The newly created layer was destroyed due to unacceptable thickness: {newLayer}");
                return null;
            }

        }

        public Gases ChangeCarbonD(CarbonDioxide CD)
        {
           
            return CarbonDioxide.Instance();
        }


        private Other() { }
        private static Other instance = null;

        public static Other Instance()
        {

            if (instance == null)
            {
                instance = new Other();
            }
            return instance;

        }
    }

}


