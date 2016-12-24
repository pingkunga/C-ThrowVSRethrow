using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleException
{
    class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(Program));  

        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            try
            {
                log.Info("Start");
                log.Warn("Testing Throw vs Rethrow");  
                //Console.Write(TestThrowEx(5, 0));
                Console.Write(TestReThrowEx(5, 0));
            }
            catch (Exception ex)
            {
                log.Error(ex.StackTrace);
                //Console.Write(ex.StackTrace);
            }
            finally
            {
                log.InfoFormat("application completed in {0}ms", timer.ElapsedMilliseconds);  
                Console.ReadKey();
            }
        }


        public static Decimal TestReThrowEx(Decimal a, Decimal b)
        {
            try
            {
                return a / b;
            }
            catch(DivideByZeroException ex)
            {
                log.Debug(ex.StackTrace);
                throw;
            }
        }

        public static Decimal TestThrowEx(Decimal a, Decimal b)
        {
            try
            {
                return a / b;
            }
            catch (DivideByZeroException ex)
            {
                log.Debug(ex.StackTrace);
                throw ex;
            }
        }
    }
}
