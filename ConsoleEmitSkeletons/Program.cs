using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Windows.Media.Media3D;


using ClassLibrary2;

namespace ConsoleEmitSkeletons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List IKSkeletonHuman Bones");
            CSharpCodeProvider thisCSharpCodeProvider = new CSharpCodeProvider();

            CodeDomProvider provider = CodeDomProvider.CreateProvider("CSharp");
            CompilerParameters cp = new CompilerParameters();
            cp.GenerateExecutable = false;
            cp.GenerateInMemory = true;
            cp.TreatWarningsAsErrors = false;



            cp.ReferencedAssemblies.Add(@"C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.5.2\PresentationCore.dll");
            cp.ReferencedAssemblies.Add(@"C:\Users\alexis\Documents\Visual Studio 2015\Projects\EmitSkeleton\ClassLibrary2\bin\Debug\ClassLibrary2.dll");
           CompilerResults cr = provider.CompileAssemblyFromFile(cp, new string[]
                {
                    @"c:\users\alexis\documents\visual studio 2015\Projects\EmitSkeleton\IKSkeletons\IKSkeletonHuman1.cs",
                    @"c:\users\alexis\documents\visual studio 2015\Projects\EmitSkeleton\IKBone.cs"
                   
                }
            );
            if (cr.Errors.Count > 0)
            {
                // Display compilation errors.

                foreach (CompilerError ce in cr.Errors)
                {
                    Console.WriteLine("  {0}", ce.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                // Display a successful compilation message.
                Console.WriteLine("Success");
            }
            Type myType = cr.CompiledAssembly.GetType("EmitSkeleton.IKSkeletons.IKSkeletonHuman1");

            Console.WriteLine(myType.Name);
            Console.WriteLine(myType.Namespace);
            foreach (PropertyInfo f in myType.GetProperties())
            {
                Console.WriteLine(f.Name);
            }

            Console.ReadLine();

            IKSkeleton thisIKSkeleton = (IKSkeleton)Activator.CreateInstance(myType);
            Console.WriteLine(thisIKSkeleton.ListBones());

            Console.ReadLine();
        }

    }

}
