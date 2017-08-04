using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using NLog;

//***Log4Net_Test: include this entire file
namespace mvc_Log4Net2NLog.Controllers
{
    public class Log4Net_TestController : Controller
    {
        private static Logger Log = LogManager.GetCurrentClassLogger();

        //ctor, test code, exercise the logger
        public Log4Net_TestController()
        {
            //uncomment to run Log_Test_Entries automatically
            //Log_Test_Entries();
        }

        public ActionResult Log_Test_Entries()
        {

            Log.Debug("Debug message");
            Log.Debug("Debug Format {0} {1}", new[] { "debugArg1", "debugArg2" });

            Log.Error("Error Message");
            Log.Error("Error Format {0}, {1}", new object[] { "errorArg1", "errorArg2" });

            Log.Info("INFO message");
            Log.Info("Info: {0}", new object[] { "infoArg1" });

            Log.Warn("Warning message");
            Log.Warn("Warning on {0}, {1}, {2}", new object[] { "warnArg1", "warnArg2", "warnArg3" });

            try
            {
                throw new Exception("ERROR in Log4Net_TestController.Log_Test_Entries (TEST)");
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                Log.Error("Error Format Exception {0}, {1}", new object[] { "errorArg1", "errorArg2" });
            }

            try
            {
                throw new Exception("FATAL error in Log4Net_TestController.Log_Test_Entries  (TEST)");
            }
            catch (Exception ex)
            {
                Log.Fatal("Fatal Error message in Exception");
                Log.Fatal(ex, string.Format("FATAL Format {0}, {1}", new object[] { "errorArg1", "errorArg2" }));
            }

            return RedirectToAction("ShowFile");
        }

        // GET: Log4Net_Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ShowApp_Log()
        {
            return RedirectToAction("ShowFile");
        }

        [HttpGet]
        public ActionResult ShowFile()
        {
            string filePath = Path.Combine(Server.MapPath("~"), ConfigurationManager.AppSettings["LogFile_RelPath"]);
            string fileDir = Path.GetDirectoryName(filePath);
            string fileName = Path.GetFileName(filePath);

            if (!Directory.Exists(fileDir))
                Directory.CreateDirectory(fileDir);

            if (!System.IO.File.Exists(filePath))
                System.IO.File.Create(filePath);

            string content = "Contents of " + fileName +"<br />" + "<br />";
            try
            {
                string[] lines = System.IO.File.ReadAllLines(filePath);
                {
                    foreach (var line in lines)
                        content += line + "<br />";
                }
            }
            catch (Exception exc)
            {
                Log.Error(string.Format("Could not read [{0}]: [{1}]", new object[] { filePath, exc.Message }));
                return Content("Error displaying file");
            }

            return (Content(content));
        }
    }
}