using CSharpFunctionalExtensions;

namespace Teamway.PersonalityTest.Domain.Extensions
{
    public static class StringExtensions
    {
        public static Result<string> EnsureValidString(this string subject, string error)
        {
            return Result.FailureIf(string.IsNullOrEmpty(subject), subject, error);
        }
    }

    public static class ObjectExtensions
    {
        public static Result<T> EnsureNotNull<T>(this T subject, string error) where T : class
        {
            return Result.FailureIf(subject == null, subject, error);
        }
    }
}