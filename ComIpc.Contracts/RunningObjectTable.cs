using System.Runtime.InteropServices;

namespace ComIpc.Contracts;

public static class RunningObjectTable
{
    public const int ActiveObjectStrong = 0;
    public const int MkEUnavailable = unchecked((int)0x800401E3);

    [DllImport("oleaut32.dll")]
    public static extern int RegisterActiveObject(
        [MarshalAs(UnmanagedType.IUnknown)] object punk,
        ref Guid rclsid,
        int dwFlags,
        out int pdwRegister);

    [DllImport("oleaut32.dll")]
    public static extern int RevokeActiveObject(int dwRegister, IntPtr reserved);

    [DllImport("oleaut32.dll")]
    public static extern int GetActiveObject(ref Guid rclsid, IntPtr reserved,
        [MarshalAs(UnmanagedType.IUnknown)] out object ppunk);

    public static int Register(TitleController controller, out int cookie)
    {
        var clsid = new Guid(ComIds.ClassId);
        return RegisterActiveObject(controller, ref clsid, ActiveObjectStrong, out cookie);
    }

    public static object GetTitleController()
    {
        var clsid = new Guid(ComIds.ClassId);
        var hr = GetActiveObject(ref clsid, IntPtr.Zero, out var obj);
        if (hr < 0)
            Marshal.ThrowExceptionForHR(hr);

        return obj;
    }
}
