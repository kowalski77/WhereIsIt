namespace WhereIsIt;

internal static class Support
{
    public static bool Verify(string[] args)
    {
        static bool Exists(string[] args) =>
                args.Length == 1 &&
                File.Exists(args[0]);

        static bool VerifyExtension(string[] args) =>
                    Path.GetExtension(Path.GetFileName(args[0])) == ".csv";

        if (!Exists(args))
        {
            Console.WriteLine("Usage: WhereIsIt <filename>");
            return false;
        }

        if (!VerifyExtension(args))
        {
            Console.WriteLine("File must be a CSV");
            return false;
        }

        return true;
    }
}
