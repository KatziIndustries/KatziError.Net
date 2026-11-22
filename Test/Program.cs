using Katzi.Error;

internal static class Program
{
    public static void Main(string[] args)
    {
        KerrorWindow error = new();

        error.SetText("HIIIII");

        bool running = true;
        while (running)
        {
            error.Pull();

            Thread.Sleep(100);
        }

        error.Dispose();
    }
}
