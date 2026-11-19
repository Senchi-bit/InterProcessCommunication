namespace WinApiIpc.Receiver;

public sealed class MarkerForm : Form
{
    public const string MarkerTitle = "WinApiIpc.Receiver.Marker";

    public MarkerForm()
    {
        Text = MarkerTitle;
        ShowInTaskbar = false;
        FormBorderStyle = FormBorderStyle.FixedToolWindow;
        StartPosition = FormStartPosition.Manual;
        Location = new Point(-32000, -32000);
        ClientSize = new Size(1, 1);
        Opacity = 0;
    }
}
