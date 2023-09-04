using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestGenerator
{
    public class TestFileBuilder
    {
        public List<string> GetAllMethodNames()
        {

            List<string> MethodNameList = new List<string>();
            MethodInfo[] mInfos = typeof(Methods).GetMethods(BindingFlags.Public | BindingFlags.Instance);
            Array.Sort(mInfos,
delegate (MethodInfo methodInfo1, MethodInfo methodInfo2)
{
    return methodInfo1.Name.CompareTo(methodInfo2.Name);
});
            foreach (MethodInfo mInfo in mInfos)
            {
                MethodNameList.Add(mInfo.Name);
            }
            return MethodNameList;
        }

        public void WriteUsingBlock(TextWriter textWriter)
        {
            textWriter.WriteLine("using System;");
            textWriter.WriteLine("using System.Linq;");
            textWriter.WriteLine("using Microsoft.VisualStudio.TestTools.UnitTesting;");
        }
        public void WriteHeader(TextWriter textWriter)
        {
            textWriter.WriteLine("namespace UnitTestGenerator.Tests");
            textWriter.WriteLine("{");
            textWriter.WriteLine("  [TestClass]");
            textWriter.WriteLine("  public class Tests");
            textWriter.WriteLine("  {");
        }
        public void WriteFooter(TextWriter textWriter)
        {
            textWriter.WriteLine("  }");
            textWriter.WriteLine("}");
        }
        public void WriteTestMethods(TextWriter textWriter)
        {
            List<string> methodNames = GetAllMethodNames();
            foreach (string name in methodNames)
            {
                textWriter.WriteLine("   [TestMethod]");
                textWriter.WriteLine($"   public void Tests_Methods_{name}()");
                textWriter.WriteLine("   {");
                textWriter.WriteLine("      // Write your code here");
                textWriter.WriteLine("   }");
            }
        }
        public void WriteDescription(TextWriter textWriter)
        {
            textWriter.WriteLine("");
            textWriter.WriteLine("   //This file is automatically created for you to write your tests.");
        }
    }
}
