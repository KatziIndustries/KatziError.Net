using System.Runtime.InteropServices;

namespace Katzi.Error;

internal static class Native
{
    private const string Lib = "kerror";
    private const CallingConvention CC = CallingConvention.Cdecl;

    [DllImport(Lib, EntryPoint = "kerror_init", CallingConvention = CC)]
    public extern static void Init();

    [DllImport(Lib, EntryPoint = "redraw", CallingConvention = CC)]
    public extern static void Redraw();

    [DllImport(Lib, EntryPoint = "kerror_close", CallingConvention = CC)]
    public extern static void Close();

    [DllImport(Lib, EntryPoint = "kerror_set_title", CallingConvention = CC)]
    public extern static void SetTitle(IntPtr title);

    [DllImport(Lib, EntryPoint = "kerror_set_text", CallingConvention = CC)]
    public extern static void SetText(IntPtr text);

    [DllImport(Lib, EntryPoint = "kerror_set_buttoncount", CallingConvention = CC)]
    public extern static void SetButtonCount(int buttonCount);

    [DllImport(Lib, EntryPoint = "kerror_set_button1", CallingConvention = CC)]
    public extern static void SetButton1(IntPtr text);

    [DllImport(Lib, EntryPoint = "kerror_set_button2", CallingConvention = CC)]
    public extern static void SetButton2(IntPtr text);

    [DllImport(Lib, EntryPoint = "kerror_set_progressactive", CallingConvention = CC)]
    public extern static void SetProgressActive([MarshalAs(UnmanagedType.I1)] bool active);

    [DllImport(Lib, EntryPoint = "kerror_set_progress", CallingConvention = CC)]
    public extern static void SetProgress(float progress);

    [DllImport(Lib, EntryPoint = "kerror_pull", CallingConvention = CC)]
    public extern static int Pull();
}
