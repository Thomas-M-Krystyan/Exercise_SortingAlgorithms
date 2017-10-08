using System;
using System.Runtime.InteropServices;
using static SortingAlgorithms.Utilities.UserInterfaceMessages;

namespace SortingAlgorithms.Performance
{
    public class ExecutionStopwatch
    {
        #region Variables
            [DllImport("kernel32.dll")]
            private static extern long GetThreadTimes(IntPtr threadHandle, out long createionTime,
                                                      out long exitTime, out long kernelTime, out long userTime);
            [DllImport("kernel32.dll")]
            private static extern IntPtr GetCurrentThread();

            private long _mEndTimeStamp;
            private long _mStartTimeStamp;
            private bool _mIsRunning;
        #endregion

        public void Start()
        {
            this._mIsRunning = true;

            long timestamp = GetThreadTimes();
            this._mStartTimeStamp = timestamp;
        }

        public void Stop()
        {
            this._mIsRunning = false;

            long timestamp = GetThreadTimes();
            this._mEndTimeStamp = timestamp;
        }

        public void Reset()
        {
            this._mStartTimeStamp = 0;
            this._mEndTimeStamp = 0;
        }

        public TimeSpan Elapsed
        {
            get
            {
                long elapsed = this._mEndTimeStamp - this._mStartTimeStamp;
                TimeSpan result = TimeSpan.FromMilliseconds(value: elapsed / 10_000);

                return result;
            }
        }

        public bool IsRunning
        {
            get { return this._mIsRunning; }
        }

        private long GetThreadTimes()
        {
            IntPtr threadHandle = GetCurrentThread();

            long notIntersting;
            long kernelTime;
            long userTime;

            long retcode = GetThreadTimes(threadHandle: threadHandle, createionTime: out notIntersting,
                                          exitTime: out notIntersting, kernelTime: out kernelTime,
                                          userTime: out userTime);

            bool success = Convert.ToBoolean(value: retcode);
            if (!success)
            {
                Console.WriteLine(ErrorDisplayingTime + retcode);
                Console.ReadKey();
                Environment.Exit(0);
            }
            long result = kernelTime + userTime;

            return result;
        }
    }
}
