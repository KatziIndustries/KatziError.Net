using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential)]
internal struct Message
{
    public IntPtr Title;
    public IntPtr Text;
    public int ButtonCount;
    public IntPtr Button1;
    public IntPtr Button2;
    [MarshalAs(UnmanagedType.I1)]
    public bool ProgressActive;
    public float Progress;
}
