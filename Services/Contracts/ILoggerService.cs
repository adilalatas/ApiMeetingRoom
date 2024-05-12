using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ILoggerService
    {
        void LogInFo(string message);
        void LogWarnig(string message);
        void LogError(string message);
        void LogDebug(string message);
    }
}
