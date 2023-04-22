using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Text;
using System.Text;

namespace Generator
{
    [Generator]
    public class ClassGenerator:ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context) { }

        public void Execute(GeneratorExecutionContext context)
        {
            context.AddSource("GeneratedClass.cs", SourceText.From(@"
namespace GeneratedNamespace
{
    public class GeneratedClass
    {
        public static void GeneratedMethod()
        {
            Console.WriteLine(""Irokez go brrrrr! "");
        }
    }
}", Encoding.UTF8));
        }
    }
}