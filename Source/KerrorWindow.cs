using System.Runtime.InteropServices;

namespace Katzi.Error;

public sealed class KerrorWindow : IDisposable
{
    private IntPtr _title, _text, _button1, _button2;

    public KerrorWindow()
    {
        Native.Init();
    }

    private static void SetString(ref IntPtr slot, string value, Action<IntPtr> setter)
    {
        IntPtr fresh = Marshal.StringToCoTaskMemUTF8(value);
        setter(fresh);
        if (slot != IntPtr.Zero)
            Marshal.FreeCoTaskMem(slot);
        slot = fresh;
    }

    public void SetTitle(string s) => SetString(ref _title, s, Native.SetTitle);
    public void SetText(string s) => SetString(ref _text, s, Native.SetText);
    public int Pull() => Native.Pull();

    public void Dispose()
    {
        Native.Close();

        foreach (var p in new[] { _title, _text, _button1, _button2 })
            if (p != IntPtr.Zero) Marshal.FreeCoTaskMem(p);
        _title = _text = _button1 = _button2 = IntPtr.Zero;
    }
}
