using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment2OOP
{
   public abstract class Gases
    {
        public char type { get; }
        public double thickness { get; set; }

        public Gases(char type, double thickness)
        {
            this.type = type;
            this.thickness = thickness;
        }


        public void GetThickness(double reduce)
        {
            thickness -= reduce; 
        }

        public bool CheckThickness()
        {
            return thickness >= 0.5;
        }

        public void MergeGases(Gases gase)
        {
            if (type == gase.type)
            {
                thickness += gase.thickness;
            } else { Console.WriteLine("This layer need to be destroyed");  }

           
        }

        public Gases ApplyVariables(IVariables variable)
        {
            Console.WriteLine($"Applying {variable.GetType().Name} to {this}");

            switch (this)
            {
                case Oxygen oxygen:
                    variable.ChangeOxygen(oxygen);
                    break;
                case Ozone ozone:
                    variable.ChangeOzone(ozone);
                    break;
                case CarbonDioxide carbonDioxide:
                    variable.ChangeCarbonD(carbonDioxide);
                    break;
            }

            Console.WriteLine($"Result: {this}\n");
            return this;
        }


        protected abstract void GetVariables(IVariables variables);

       
    }

   public class Oxygen : Gases
    {
        public Oxygen(char type, double thickness) : base(type, thickness) { }
        protected override void GetVariables(IVariables variables)
        {
            variables.ChangeOxygen(this); 
        }

        public override string ToString()
        {
            return $"X {thickness}";
        }
        private Oxygen() : base('X', 0) { }

        private static Oxygen instance = null;

        public static Oxygen Instance()
        {

            if (instance == null)
            {
                instance = new Oxygen();
            }
            return instance;

        }

    }

  public  class Ozone : Gases
    {
        public Ozone(char type, double thickness) : base(type, thickness) { }

        protected override void GetVariables(IVariables variables)
        {
            variables.ChangeOzone(this);
        }

        public override string ToString()
        {
            return $"Z {thickness}";
        }
        private Ozone() : base('Z', 0) { }

        private static Ozone instance = null;

        public static Ozone Instance()
        {

            if (instance == null)
            {
                instance = new Ozone();
            }
            return instance;

        }
    }


   public  class CarbonDioxide : Gases
    {
        public CarbonDioxide(char type, double thickness) : base(type, thickness) { }

        protected override void GetVariables(IVariables variables)
        {
            variables.ChangeCarbonD(this);
        }

        public override string ToString()
        {
            return $"C {thickness}";
        }
        private CarbonDioxide() : base('C', 0) { }

        private static CarbonDioxide instance = null;

        public static CarbonDioxide Instance()
        {
            if (instance == null)
            {
                instance = new CarbonDioxide();
            }
            return instance;

        }
    }

}





