using System.Collections;
using System.ComponentModel;
using System.Linq.Expressions;

namespace CodeGenerator
{
    internal class Program
    {
        private const string MainPath = $@"D:\CodeGenerator";
        private const string ModelsPath = $@"D:\CodeGenerator\Models\";
        private const string DtoPath = $@"{MainPath}\Dto\";
        private const string ApplicationServicePath = $@"{MainPath}\ApplicationService\";
        private const string IApplicationServicePath = $@"{MainPath}\IApplicationService\";
        private const string TemplatePath = $@"{MainPath}\Template.txt";
        static void Main(string[] args)
        {
            string templateCode = File.ReadAllText(TemplatePath);

            Directory.CreateDirectory(MainPath);
            Directory.CreateDirectory(DtoPath);
            Directory.CreateDirectory(ApplicationServicePath);
            Directory.CreateDirectory(IApplicationServicePath);
            var models = Directory.GetFiles(ModelsPath);

            foreach (var item in models)
            {
                try
                {
                    string modelCode = File.ReadAllText(item);
                    var className = modelCode.Split("class").LastOrDefault().Split(' ')[1];
                    var lowerClassName = className.Substring(0, 1).ToUpper() + className.Remove(0, 1);
                    string dtoCode = modelCode.Replace($"public class {className} : BaseModel", $"public class {className}Dto : BaseDto");
                    templateCode = templateCode.Replace("%%%%", className).Replace("&&&&", lowerClassName);
                    var slices = templateCode.Split("//interfaceArea");
                    File.WriteAllText(ApplicationServicePath + className + "ApplicationService.cs", slices.FirstOrDefault());
                    File.WriteAllText(IApplicationServicePath + "I" + className + "ApplicationService.cs", slices.LastOrDefault());
                    File.WriteAllText(DtoPath + className + "Dto.cs", dtoCode);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    continue;
                }
            }
            //var className = ""
        }

    }
}