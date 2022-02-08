using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Serilog;
using ShellProgressBar;


namespace ETLTool
{
    /* Class with useful methods (log, progress bar, DB connection). */
    internal class Util
    {
        private const string ConnectionString = @"Server=localhost\SQLEXPRESS;Database=ETLTool;Trusted_Connection=True;MultipleActiveResultSets=true";

        private static ProgressBar pbar;

        internal static SqlConnection DBConnect()
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        internal static void SetLog()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("../../../logs/log-.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
            LogInf("Starting");
        }

        internal static void LogInf(string Msg)
        {
            Log.Information(Msg);
        }

        internal static void LogWar(string Msg)
        {
            Log.Warning(Msg);
        }
        internal static void LogErr(string Msg)
        {
            Log.Error(Msg);
        }
        internal static void SetProgressBar()
        {
            const int totalTicks = 22;
            var options = new ProgressBarOptions
            {
                //DisplayTimeInRealTime = false,
                ForegroundColor = ConsoleColor.DarkYellow,
                ForegroundColorDone = ConsoleColor.DarkGreen,
                //ProgressBarOnBottom = true,
                BackgroundCharacter = '\u2593'
            };

            Util.pbar = new ProgressBar(totalTicks, "Processing...", options);
        }

        internal static void TickProgressBar(string Msg)
        {
            pbar.WriteLine(Msg);
            Util.pbar.Tick();
        }
    }
}
