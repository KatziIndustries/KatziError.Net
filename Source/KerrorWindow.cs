using System.Runtime.InteropServices;

namespace Katzi.Error;

public sealed class KerrorWindow : IDisposable
{
    private IntPtr _title, _text, _button1, _button2;

    public string Title
    {
        get => MsgAccessor.Title ?? "";
        set => SetString(ref _title, value, Native.SetTitle);
    }

    public string Text
    {
        get => MsgAccessor.Text ?? "";
        set => SetString(ref _text, value, Native.SetText);
    }

    public string Button1
    {
        get => MsgAccessor.Button1 ?? "";
        set => SetString(ref _button1, value, Native.SetButton1);
    }

    public string Button2
    {
        get => MsgAccessor.Button2 ?? "";
        set => SetString(ref _button2, value, Native.SetButton2);
    }

    public int ButtonCount
    {
        get => MsgAccessor.ButtonCount;
        set => Native.SetButtonCount(value);
    }

    public bool ProgessActive
    {
        get => MsgAccessor.ProgressActive;
        set => Native.SetProgressActive(value);
    }

    public float Progress
    {
        get => MsgAccessor.Progress;
        set => Native.SetProgress(value);
    }

    public KerrorWindow()
    {
        Native.Init();
    }

    public int Pull() => Native.Pull();

    private static void SetString(ref IntPtr slot, string value, Action<IntPtr> setter)
    {
        IntPtr fresh = Marshal.StringToCoTaskMemUTF8(value);
        setter(fresh);
        if (slot != IntPtr.Zero)
            Marshal.FreeCoTaskMem(slot);
        slot = fresh;
    }

    public void Dispose()
    {
        Native.Close();

        foreach (var p in new[] { _title, _text, _button1, _button2 })
            if (p != IntPtr.Zero) Marshal.FreeCoTaskMem(p);
        _title = _text = _button1 = _button2 = IntPtr.Zero;
    }
}
