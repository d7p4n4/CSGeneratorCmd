using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSGeneratorCmd
{
    class Start
    {
        private static readonly string APPSETTINGS_NAMESPACE = ConfigurationManager.AppSettings["defaultNamespace"];
        private static readonly string APPSETTINGS_OUTPATH = ConfigurationManager.AppSettings["outPath"];
        private static readonly string APPSETTINGS_INPATH = ConfigurationManager.AppSettings["inPath"];
        private static readonly string APPSETTINGS_TEMPLATES = ConfigurationManager.AppSettings["templatesFolder"];

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        static void Main(string[] args)
        {

            //Date: 2019. 11. 09. 18:35
            Boolean enoughArgs = false;
            try
            {

                if (args.Length == 4)
                {
                    enoughArgs = true;
                    CSGeneratorLib.Program.MainMethod(args[0], args[1], args[2], args[3]);
                    log.Debug(">>32");
                }
                else if (args.Length == 0)
                {
                    enoughArgs = true;

                    CSGeneratorLib.Program.MainMethod(APPSETTINGS_INPATH, APPSETTINGS_OUTPATH, APPSETTINGS_NAMESPACE, APPSETTINGS_TEMPLATES);
                }
                else
                {
                    try
                    {
                        CSGeneratorLib.Program.MainMethod(args[0], args[1], args[2], args[3]);
                    }
                    catch (Exception _exception)
                    {
                        log.Error(_exception.StackTrace);
                        if (!enoughArgs)
                        {
                            Console.WriteLine("Vagy ne írj argumentumot, vagy mind a 4 argumentumot kell megadnod! (inpath, outpath, namespace név, templates mappa)");
                        }
                    }
                }
            }
            catch (Exception _exception)
            {
                log.Error(_exception.StackTrace);
            }
        }
    }
}