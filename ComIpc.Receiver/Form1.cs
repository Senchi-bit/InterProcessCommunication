using ComIpc.Contracts;

namespace ComIpc.Receiver;

public partial class Form1 : Form
{
    private readonly TitleController _controller = new();
    private int _cookie;

    public Form1()
    {
        InitializeComponent();
        _controller.TitleChanged += OnTitleChanged;
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        var hr = RunningObjectTable.Register(_controller, out _cookie);
        if (hr < 0)
        {
            MessageBox.Show(this, "Не удалось зарегистрировать COM-объект: 0x" + hr.ToString("X8"),
                Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OnTitleChanged(object? sender, string title)
    {
        if (IsDisposed)
            return;

        if (InvokeRequired)
            BeginInvoke(() => Text = title);
        else
            Text = title;
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        if (_cookie != 0)
        {
            RunningObjectTable.RevokeActiveObject(_cookie, IntPtr.Zero);
            _cookie = 0;
        }

        base.OnFormClosed(e);
    }
}
