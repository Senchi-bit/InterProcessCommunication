using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TcpIpc.Receiver;

public partial class Form1 : Form
{
    public const int Port = 5050;

    private readonly CancellationTokenSource _cts = new();
    private TcpListener? _listener;

    public Form1()
    {
        InitializeComponent();
    }

    protected override void OnLoad(EventArgs e)
    {
        base.OnLoad(e);
        try
        {
            _listener = new TcpListener(IPAddress.Any, Port);
            _listener.Start();
            _ = AcceptLoopAsync(_cts.Token);
        }
        catch (SocketException ex)
        {
            Text = "TCP IPC Receiver — порт занят";
            MessageBox.Show(this, ex.Message, Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task AcceptLoopAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            TcpClient client;
            try
            {
                client = await _listener!.AcceptTcpClientAsync(token).ConfigureAwait(false);
            }
            catch (Exception ex) when (ex is OperationCanceledException or ObjectDisposedException or SocketException)
            {
                break;
            }

            _ = HandleClientAsync(client);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        using (client)
        {
            try
            {
                await using var stream = client.GetStream();
                using var reader = new StreamReader(stream, Encoding.UTF8);
                var line = await reader.ReadLineAsync().ConfigureAwait(false);
                if (line is null || IsDisposed)
                    return;

                BeginInvoke(() =>
                {
                    if (!IsDisposed)
                        Text = line;
                });
            }
            catch (IOException)
            {
            }
        }
    }

    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        _cts.Cancel();
        _listener?.Stop();
        _cts.Dispose();
        base.OnFormClosed(e);
    }
}
