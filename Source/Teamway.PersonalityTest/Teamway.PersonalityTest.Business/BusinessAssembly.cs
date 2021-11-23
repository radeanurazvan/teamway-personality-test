using System.Reflection;

namespace Teamway.PersonalityTest.Business
{
    public static class BusinessAssembly
    {
        public static Assembly Value { get; } = typeof(BusinessAssembly).Assembly;
    }
}