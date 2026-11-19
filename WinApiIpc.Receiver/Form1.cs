namespace WinApiIpc.Receiver;

public partial class Form1 : Form
{
    private MarkerForm? _marker;

    public Form1()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        _marker = new MarkerForm { Owner = this };
        _marker.Show();
        _marker.Hide();
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _marker?.Dispose();
        base.OnFormClosed(e);
    }
}
