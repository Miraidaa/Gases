using System;
using System.Collections.Generic;
using System.Text;
using TextFile;

namespace Assignment2OOP
{
    public class Program
    {        
        static void Main(string[] args)
        {
            TextFileReader reader = new TextFileReader("input.txt");

          
            reader.ReadLine(out string line);
            int n = int.Parse(line);
            List<Gases> gases = new List<Gases>();

            for (int i = 0; i < n; i++)
            {
                if (reader.ReadLine(out line))
                {
                    string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                    char g = char.Parse(tokens[0]);
                    double t = double.Parse(tokens[1]);

                    switch (g)
                    {
                        case 'X': gases.Add(new Oxygen(g, t)); break;
                        case 'Z': gases.Add(new Ozone(g, t)); break;
                        case 'C': gases.Add(new CarbonDioxide(g, t)); break;
                    }
                }
            }


            reader.ReadLine(out line);
            string finalString = line;
            char[] arrayChar = finalString.ToCharArray();

            List<IVariables> atmosphericVars = new();
            foreach (char c in arrayChar)
            {
                switch (c)
                {
                    case 'O': atmosphericVars.Add(Other.Instance()); break;
                    case 'S': atmosphericVars.Add(Sunshine.Instance()); break;
                    case 'T': atmosphericVars.Add(Thunderstorm.Instance()); break;
                }
            }

         
            int round = 0;
            foreach (var variable in atmosphericVars)
            {
                round++;
                Console.WriteLine($"Round: {round}");

                for (int i = 0; i < gases.Count; i++)
                {
                    Gases currentLayer = gases[i];
                    Gases newLayer = gases[i].ApplyVariables(variable);

                    Console.WriteLine($"Applying {variable.GetType().Name} to {currentLayer}");
                    Console.WriteLine($"Result: {newLayer}\n");

                    if (!newLayer.CheckThickness()) 
                    {
                        if (i > 0 && gases[i - 1].type == newLayer.type) 
                        {
                            gases[i - 1].MergeGases(newLayer); 
                        }
                        else
                        {
                            Console.WriteLine($"Layer {newLayer.GetType().Name} with thickness {newLayer.thickness} needs to be destroyed"); 
                            gases.RemoveAt(i); 
                            i--;

                            Console.WriteLine("Reason: Thickness below 0.5"); 
                        }
                    }
                }
            }


           

        }
    }
}
