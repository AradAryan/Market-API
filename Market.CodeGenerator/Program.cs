using System.Diagnostics;

namespace CodeGenerator
{
    internal class Program
    {
        private const string MainPath = $@"D:\CodeGenerator";
        private const string ModelsPath = $@"D:\CodeGenerator\Models\";
        private const string DtoPath = $@"{MainPath}\Dto\";
        private const string ApplicationServicePath = $@"{MainPath}\ApplicationService\";
        private const string IApplicationServicePath = $@"{MainPath}\IApplicationService\";
        private const string ControllerPath = $@"{MainPath}\Controller\";
        private const string TemplatePath = $@"{MainPath}\Template.txt";
        static void Main(string[] args)
        {
            string templateCode = File.ReadAllText(TemplatePath);

            Directory.CreateDirectory(MainPath);
            Directory.CreateDirectory(DtoPath);
            Directory.CreateDirectory(ControllerPath);
            Directory.CreateDirectory(ApplicationServicePath);
            Directory.CreateDirectory(IApplicationServicePath);
            var models = Directory.GetFiles(ModelsPath);

            foreach (var item in models)
            {
                try
                {
                    string modelCode = File.ReadAllText(item);
                    string className = modelCode.Split("class").LastOrDefault().Split(' ')[1];
                    string lowerClassName = className.Substring(0, 1).ToLower() + className.Remove(0, 1);
                    string dtoCode = modelCode.Replace($"public class {className} : BaseModel", $"public class {className}Dto : BaseDto");
                    string codes = templateCode.Replace("%%%%", className).Replace("&&&&", lowerClassName);
                    if (codes.Contains("Addresss"))
                        codes = codes.Replace("Addresss", "Addresses");
                    if (codes.Contains("Categorys"))
                        codes = codes.Replace("Categorys", "Category");
                    string[] slices = codes.Split("//Area");
                    File.WriteAllText(ApplicationServicePath + className + "ApplicationService.cs", slices[0]);
                    File.WriteAllText(IApplicationServicePath + "I" + className + "ApplicationService.cs", slices[1]);
                    File.WriteAllText(ControllerPath + className + "Controller.cs", slices[2]);
                    File.AppendAllText(MainPath + @"\DIScoped.txt", slices[3]);
                    File.AppendAllText(MainPath + @"\DISingleton.txt", slices[4]);
                    File.AppendAllText(MainPath + @"\DbSets.txt", slices[5]);
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