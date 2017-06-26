using System;
using System.Collections.Generic;
using System.Linq;

namespace _04_Hospital
{
    class Startup
    {
        static void Main()
        {
            var departments = new Dictionary<string, Dictionary<string, int>>();
            var doctors = new Dictionary<string, List<string>>();

            string input;

            while ((input = Console.ReadLine().Trim()) != "Output")
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string department = tokens[0];
                string doctor = tokens[1] + " " + tokens[2];
                string patient = tokens[3];

                if (!doctors.ContainsKey(doctor))
                {
                    doctors.Add(doctor, new List<string>());
                }

                if (!departments.ContainsKey(department))
                {
                    departments.Add(department, new Dictionary<string, int>());
                    departments[department].Add(patient, 1);
                    doctors[doctor].Add(patient);
                }
                else
                {
                    int currentBad = departments[department].Count + 1;

                    if (currentBad <= 60)
                    {
                        departments[department].Add(patient, ((currentBad - 1) / 3) + 1);
                        doctors[doctor].Add(patient);
                    }
                }
            }

            while ((input = Console.ReadLine().Trim()) != "End")
            {
                var tokens = input.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                if (tokens.Length == 1)
                {
                    if (departments.ContainsKey(tokens[0]))
                    {
                        foreach (var patient in departments[tokens[0]])
                        {
                            Console.WriteLine(patient.Key);
                        }

                    }
                }
                else if (int.TryParse(tokens[1], out int room))
                {
                    foreach (var patient in departments[tokens[0]].Where(p => p.Value == room).OrderBy(p => p.Key))
                    {
                        Console.WriteLine(patient.Key);
                    }
                }
                else
                {
                    foreach (var patient in doctors[tokens[0] + " " + tokens[1]].OrderBy(p => p))
                    {
                        Console.WriteLine(patient);
                    }
                }
            }
        }
    }
}