using System.Runtime.InteropServices;

namespace KatziError;

public static class Kerror
{
    [DllImport("kerror", EntryPoint = "kerror")]
    public extern static int ThrowError(string text);
}
