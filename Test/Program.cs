using Katzi.Error;

internal static class Program
{
    public static void Main(string[] args)
    {
        KerrorWindow error = new()
        {
            Text = "hiiii",
            Title = "Aaronohaftiger titel",
            ButtonCount = 2,
            Button1 = "Buttonop uno",
            Button2 = "Buttonop zwuno",
            ProgessActive = false,
            Progress = 0.5f,
        };

        bool running = true;
        while (running)
        {
            int result = error.Pull();

            if (result != 0)
                running = false;
        }

        error.Dispose();
    }
}
