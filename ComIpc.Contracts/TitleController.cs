using System.Runtime.InteropServices;

namespace ComIpc.Contracts;

[ComVisible(true)]
[Guid(ComIds.ClassId)]
[ProgId(ComIds.ProgId)]
[ClassInterface(ClassInterfaceType.None)]
[ComDefaultInterface(typeof(ITitleController))]
public sealed class TitleController : ITitleController
{
    public event EventHandler<string>? TitleChanged;

    public void SetTitle(string title)
    {
        TitleChanged?.Invoke(this, title);
    }
}
