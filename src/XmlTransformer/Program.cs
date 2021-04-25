using System;
using System.IO;
using Microsoft.Web.XmlTransform;

namespace XmlTransformer
{
    public static class Program
    {
        public static int Main(string[] args)
        {
            if (args.Length != 3)
            {
                Console.Error.WriteLine("Wrong number of arguments");
                Console.Error.WriteLine("XmlTransformer ConfigFilename TransformFilename ResultFilename");
                return ExitCode.Error;
            }

            var configFile = args[0];
            if (!File.Exists(configFile))
            {
                Console.Error.WriteLine("The config file does not exist");
                return ExitCode.Error;
            }

            var transformFile = args[1];
            if (!File.Exists(transformFile))
            {
                Console.Error.WriteLine("The transform file does not exist");
                return ExitCode.Error;
            }

            Console.WriteLine($"Apply transformation '{transformFile}' to '{configFile}'");

            try
            {
                using var doc = new XmlTransformableDocument();
                doc.Load(configFile);
                using var xmlTransformation = new XmlTransformation(transformFile);
                if (xmlTransformation.Apply(doc))
                {
                    var resultFile = args[2];
                    Console.WriteLine($"Save result to '{resultFile}'");
                    doc.Save(resultFile);
                    return ExitCode.Success;
                }
            }
            catch (Exception exception)
            {
                Console.Error.WriteLine("An exception occurred");
                Console.Error.WriteLine(exception.ToString());
            }

            Console.Error.WriteLine("Could not apply transformation");
            return ExitCode.Error;
        }
    }
}
