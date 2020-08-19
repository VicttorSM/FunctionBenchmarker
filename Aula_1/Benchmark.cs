using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Aula_1
{
    /// <summary>
    /// Class dedicated to execute benchmarks of functions
    /// </summary>
    class Benchmark
    {

        /// <summary>
        /// Calculates the SpeedUp value between 2 functions
        /// </summary>
        /// <param name="baseFunctionTime">The base function</param>
        /// <param name="otherFunctionTime">The function it will be comparing to</param>
        /// <returns>Value of the SpeedUp of the otherFunction compared to the baseFunction</returns>
        public static double SpeedUpCalculator(double baseFunctionTime, double otherFunctionTime)
        {
            return baseFunctionTime / otherFunctionTime;
        }

        /// <summary>
        /// Calculates the average time a function takes to execute
        /// </summary>
        /// <param name="function">The function to be benchmarked</param>
        /// <param name="parameter">The parameter the function takes</param>
        /// <param name="times">The number of times the function will be executed</param>
        /// <returns>The average time in milliseconds it took to execute the function</returns>
        public static double AverageBenchmark(Func<int, bool> function, int parameter, int times)
        {
            List<double> individualBenchResults = new List<double>();
            for (int i = 0; i < times; i++)
            {
                individualBenchResults.Add(BenchmarkFunction(function, parameter));
            }
            return individualBenchResults.Average();
        }

        /// <summary>
        /// Calculates the time a function takes to execute once
        /// </summary>
        /// <param name="function">The function to be benchmarked</param>
        /// <param name="parameter">The parameter the function takes</param>
        /// <returns>The time in milliseconds it took to execute the function</returns>
        public static double BenchmarkFunction(Func<int, bool> function, int parameter)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            function(parameter);
            return stopwatch.Elapsed.TotalMilliseconds;
        }

        /// <summary>
        /// Executes the whole benchmark, and returns its results
        /// </summary>
        /// <param name="functions">List of functions to be benchmarked</param>
        /// <param name="parameterValues">List of parameters each functions will take in order to execute</param>
        /// <param name="times">Number of times each function will execute with the same parameter</param>
        /// <returns>A list of dictionaries, each dictionary in the list represents the benchmark records from each function</returns>
        public static List<Dictionary<int, double>> ExecuteFullBenchmark(List<Func<int, bool>> functions, List<int> parameterValues, int times = 1)
        {
            // Starting from 0, each dictionary in the list represents the benchmark records from each function to be tested
            List<Dictionary<int, double>> benchmarkList = new List<Dictionary<int, double>>();

            for (int i = 0; i < functions.Count; i++)
            {
                // Initializes a new dictionary for this function
                benchmarkList.Add(new Dictionary<int, double>());
                var function = functions[i];

                // Adds the benchmark results for each parameter to this dictionary
                foreach (int parameter in parameterValues)
                {
                    benchmarkList[i].Add(parameter, AverageBenchmark(function, parameter, times));
                }
            }

            return benchmarkList;
        }

        /// <summary>
        /// Calculates the responses of the function for each parameter and returns them
        /// </summary>
        /// <param name="function">The function that will determine the answer</param>
        /// <param name="parameterValues">The parameters this function will be taking</param>
        /// <returns>Responses for each parameter used</returns>
        public static Dictionary<int, bool> FunctionReturn(Func<int, bool> function, List<int> parameterValues)
        {
            // This dictionary will store the results of each parameter for this function
            Dictionary<int, bool> dict = new Dictionary<int, bool>();

            foreach (var parameter in parameterValues)
            {
                dict.Add(parameter, function(parameter));
            }

            return dict;
        }
    }
}
