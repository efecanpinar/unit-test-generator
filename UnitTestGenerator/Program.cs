using System.Reflection;
using System.Runtime.CompilerServices;
using UnitTestGenerator;


using (var file = File.CreateText("C:\\Users\\efeca\\OneDrive\\Desktop\\Projects\\UnitTestGenerator\\UnitTestGenerator\\Tests\\Test.cs"))
{
    TestFileBuilder testFileBuilder = new TestFileBuilder();
    testFileBuilder.WriteUsingBlock(file);
    testFileBuilder.WriteHeader(file);
    testFileBuilder.WriteTestMethods(file);
    testFileBuilder.WriteFooter(file);
    testFileBuilder.WriteDescription(file);
}