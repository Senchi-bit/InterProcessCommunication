namespace WinApiIpc.Sender;

public partial class Form1 : Form
{
    public const string MarkerTitle = "WinApiIpc.Receiver.Marker";

    public Form1()
    {
        InitializeComponent();
    }

    private void buttonSend_Click(object sender, EventArgs e)
    {
        var marker = NativeMethods.FindWindow(null, MarkerTitle);
        if (marker == IntPtr.Zero)
        {
            MessageBox.Show(this, "Сначала запустите WinApiIpc.Receiver.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var main = NativeMethods.GetWindow(marker, NativeMethods.GwOwner);
        if (main == IntPtr.Zero || !NativeMethods.SetWindowText(main, textBoxMessage.Text))
        {
            MessageBox.Show(this, "Не удалось изменить заголовок окна получателя.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
