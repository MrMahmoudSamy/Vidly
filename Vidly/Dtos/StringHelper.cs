namespace Vidly.Dtos
{
    public static class StringHelper
    {
        public static bool IsNullOrWhiteSpace(string s)
        {
            if (s == null)
                return true;

            return (s.Trim() == string.Empty);
        }
    }
}