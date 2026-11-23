using System.Runtime.InteropServices;

namespace Katzi.Error;

internal static class MsgAccessor
{
    private static readonly IntPtr _msgAddr;

    static MsgAccessor()
    {
        IntPtr lib = NativeLibrary.Load("kerror");
        _msgAddr = NativeLibrary.GetExport(lib, "msg");
    }

    private static IntPtr Field(string name) => IntPtr.Add(_msgAddr, (int)Marshal.OffsetOf<Message>(name));

    public static string? Title => Marshal.PtrToStringUTF8(Marshal.ReadIntPtr(Field(nameof(Message.Title))));
    public static string? Text => Marshal.PtrToStringUTF8(Marshal.ReadIntPtr(Field(nameof(Message.Text))));
    public static string? Button1 => Marshal.PtrToStringUTF8(Marshal.ReadIntPtr(Field(nameof(Message.Button1))));
    public static string? Button2 => Marshal.PtrToStringUTF8(Marshal.ReadIntPtr(Field(nameof(Message.Button2))));

    public static int ButtonCount => Marshal.ReadInt32(Field(nameof(Message.ButtonCount)));
    public static bool ProgressActive => Marshal.ReadByte(Field(nameof(Message.ProgressActive))) != 0;
    public static float Progress => BitConverter.Int32BitsToSingle(Marshal.ReadInt32(Field(nameof(Message.Progress))));
}
