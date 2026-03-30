using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRental_DataAccessLayar
{
    internal class clsEventLogger
    {
        public static string sourceName = "CarRental";
        public static void LogEvent(string message, EventLogEntryType entryType = EventLogEntryType.Error)
        {
            try
            {

                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }
                EventLog.WriteEntry(sourceName, message, entryType);

            }
            catch (UnauthorizedAccessException ex)
            {
                return;
            }
            catch (Exception ex)
            {

                EventLog.WriteEntry(sourceName, ex.Message, EventLogEntryType.Error);
            }
        }
    }

}
