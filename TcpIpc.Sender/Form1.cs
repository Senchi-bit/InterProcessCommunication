using System.Net.Sockets;
using System.Text;

namespace TcpIpc.Sender;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void buttonSend_Click(object sender, EventArgs e)
    {
        var host = textBoxHost.Text.Trim();
        if (host.Length == 0 || !int.TryParse(textBoxPort.Text.Trim(), out var port) || port is < 1 or > 65535)
        {
            MessageBox.Show(this, "Укажите имя хоста или IP-адрес и номер порта.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        buttonSend.Enabled = false;
        try
        {
            using var client = new TcpClient();
            using var timeout = new CancellationTokenSource(TimeSpan.FromSeconds(3));
            await client.ConnectAsync(host, port, timeout.Token);

            await using var stream = client.GetStream();
            await using var writer = new StreamWriter(stream, new UTF8Encoding(encoderShouldEmitUTF8Identifier: false))
            {
                AutoFlush = true
            };
            await writer.WriteLineAsync(textBoxMessage.Text);
        }
        catch (Exception ex) when (ex is SocketException or IOException or OperationCanceledException or TimeoutException)
        {
            MessageBox.Show(
                this,
                "Не удалось отправить текст: " + ex.Message,
                Text,
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning);
        }
        finally
        {
            buttonSend.Enabled = true;
        }
    }
}
