using System.Runtime.InteropServices;

namespace ComIpc.Contracts;

[ComVisible(true)]
[Guid(ComIds.InterfaceId)]
[InterfaceType(ComInterfaceType.InterfaceIsDual)]
public interface ITitleController
{
    [DispId(1)]
    void SetTitle([MarshalAs(UnmanagedType.BStr)] string title);
}
