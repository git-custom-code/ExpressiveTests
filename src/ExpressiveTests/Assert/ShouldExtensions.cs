namespace ExpressiveTests
{
    public static class ShouldExtensions
    {
        public static StringValidator Should(this string @string)
        {
            return new StringValidator(@string);
        }
    }
}