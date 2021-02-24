using log4net;
using System.Runtime.CompilerServices;

namespace RoofStockAssesment.Common
{
    public class LogHelper
    {
        public static ILog GetLogger([CallerFilePath] string fileName="") {
            return LogManager.GetLogger(fileName);
        }
    }
}
