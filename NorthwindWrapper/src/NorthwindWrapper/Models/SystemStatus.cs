using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NorthwindWrapper.Utilities;
using System.Diagnostics;

namespace NorthwindWrapper.Models
{
    /// <summary>
    /// Defines the status object for this system.
    /// </summary>
    public class SystemStatus
    {
        /// <summary>
        /// Create the status object.
        /// </summary>
        /// <param name="settings">The access settings.</param>
        public SystemStatus(AccessSettings settings)
        {
            this.Requested = DateTime.UtcNow;

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            this.DatabaseTime = AccessWrapper.QueryDatabase<DateTime>(settings, "SELECT Now() AS [Date]", (reader) => {
                DateTime result = DateTime.MinValue;
                if (reader.HasRows)
                {
                    reader.Read();
                    int ordinal = reader.GetOrdinal("Date");
                    result = reader.GetDateTime(ordinal);
                }
                return result;
            });

            stopWatch.Stop();

            this.QueryTimeInMilliseconds = stopWatch.ElapsedMilliseconds;
            this.QueryTimeInTicks = stopWatch.ElapsedTicks;
        }

        /// <summary>
        /// Get the status requested time.
        /// </summary>
        public DateTime Requested { get; private set; }

        /// <summary>
        /// Get the database time.
        /// </summary>
        public DateTime DatabaseTime { get; private set; }

        /// <summary>
        /// Get the total time in milliseconds.
        /// </summary>
        public long QueryTimeInMilliseconds { get; private set; }

        /// <summary>
        /// Get the totaltime in ticks.
        /// </summary>
        public long QueryTimeInTicks { get; private set; }
    }
}
