using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.IO;
using System.Linq;
using System.Text;

namespace Generator
{
    [Generator]
    public class AddGenerator : ISourceGenerator
    {

        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            var sb = new StringBuilder();
            var myFiles = context.AdditionalFiles.Where(f=>f.Path.EndsWith(".txt"));
            foreach (var file in myFiles)
            {
                var content = File.ReadAllLines(file.Path);
                foreach(var line in content)
                {
                    sb.AppendLine($"Console.WriteLine(@\"{line.Trim()}\");");
                }
            }
           
            context.AddSource($"MegaPrint.generated.cs", SourceText.From($@"
namespace TotalPrint
{{
    public static class MegaPrintClass
    {{

        public static void GeneratedMethod()
        {{
            {sb.ToString()}
        }}
    }}
}}", Encoding.UTF8));

        }
    }
}