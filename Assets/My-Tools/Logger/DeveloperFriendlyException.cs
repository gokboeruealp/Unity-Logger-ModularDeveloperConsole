using System;

namespace Gokboerue.Tools
{
    public class DeveloperFriendlyException : Exception
    {
        public DeveloperFriendlyException(string message, LogType logType = LogType.LOG) : base(message)
        {
            switch (logType)
            {
                case LogType.LOG:
                    Log.L(message);
                    break;
                case LogType.WARNING:
                    Log.W(message);
                    break;
                case LogType.ERROR:
                    Log.E(message);
                    break;
            }
        }
    }
}
