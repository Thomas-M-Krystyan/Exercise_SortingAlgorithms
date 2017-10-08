using System;
using System.Diagnostics;
using static SortingAlgorithms.Utilities.UserInterfaceMessages;

namespace SortingAlgorithms.Performance
{
    internal class ThreadPerformance : IDisposable
    {
        private readonly Stopwatch _totalStopwatch = new Stopwatch();
        private readonly ExecutionStopwatch _executionStopwatch = new ExecutionStopwatch();

        public static ThreadPerformance Measure()
        {
            return new ThreadPerformance();
        }

        private ThreadPerformance()
        {
            this._totalStopwatch.Start();
            this._executionStopwatch.Start();
        }

        public void Dispose()
        {
            this._executionStopwatch.Stop();
            this._totalStopwatch.Stop();

            TimeSpan difference = this._totalStopwatch.Elapsed - this._executionStopwatch.Elapsed;

            Console.WriteLine(PerformanceHeader);
            Console.WriteLine("Waiting: {0}", difference < TimeSpan.Zero ? difference : TimeSpan.Zero);
            Console.WriteLine("CPU usage: {0}", this._executionStopwatch.Elapsed);
        }
    }
}
