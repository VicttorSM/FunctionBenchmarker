using System;
using System.Collections.Generic;

namespace Aula_1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Func<int, bool>> functions = new List<Func<int, bool>>
            {
                TestaPrimo.TestaPrimo1Del,
                TestaPrimo.TestaPrimo2Del,
                TestaPrimo.TestaPrimo3Del,
                TestaPrimo.TestaPrimo4Del
            };

            List<int> parameters = new List<int>
            {
                7,
                27,
                8421,
                13033,
                524287,
                664283,
                2147483647
            };

            // The benchmark will not start if there are no functions to execute
            if (functions.Count == 0)
            {
                Console.WriteLine("No functions to execute...");
                Console.ReadLine();
                return;
            }

            // Asks for user input to the "times" variable
            int times;
            Console.Write("Enter the number of times each function will be executed: ");
            while (!int.TryParse(Console.ReadLine(), out times))
            {
                Console.WriteLine("Invalid value");
                Console.Write("Enter the number of times each function will be executed: ");
            }


            Console.WriteLine($"Executing benchmark {times} {(times == 1 ? "time" : "times")} for each function");
            // All the heavy processing happens in these 2 lines
            var benchList = Benchmark.ExecuteFullBenchmark(functions, parameters, times);
            var functionAnswers = Benchmark.FunctionReturn(functions[0], parameters);


            // Here the results are displayed for each parameter
            int decimalPlaces = 5;
            foreach (var parameter in parameters)
            {
                Console.WriteLine($"Parameter: {parameter}");

                Console.WriteLine($"Prime: {functionAnswers[parameter]}");

                // Prints the average elapsed time for each function in this parameter
                for (int i = 0; i < functions.Count; i++)
                {
                    var functionNumber = i + 1;
                    var elapsedTime = benchList[i][parameter];

                    Console.WriteLine($"Funtion {functionNumber} elapsed time: {Math.Round(elapsedTime, decimalPlaces)} milliseconds");
                }


                // Prints the speedups
                var baseSpeed = benchList[0][parameter];
                for (int i = 1; i < functions.Count; i++)
                {
                    var functionNumber = i + 1;
                    var speedup = Benchmark.SpeedUpCalculator(baseSpeed, benchList[i][parameter]);
                    Console.WriteLine($"SpeedUp of {functionNumber} compared to function 1: {Math.Round(speedup, decimalPlaces)}");
                }
                Console.WriteLine();
            }

            Console.WriteLine("Press enter to close the application...");
            Console.ReadLine();
        }
    }
}
