namespace FileIpc.Receiver;

public partial class Form1 : Form
{
    private static readonly string SharedFilePath =
        Path.Combine(Path.GetTempPath(), "ipc-lab-title.txt");

    private string? _lastText;

    public Form1()
    {
        InitializeComponent();
    }

    private void timerPoll_Tick(object sender, EventArgs e)
    {
        if (!File.Exists(SharedFilePath))
            return;

        try
        {
            string text;
            using (var stream = new FileStream(SharedFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            using (var reader = new StreamReader(stream, System.Text.Encoding.UTF8))
            {
                text = reader.ReadToEnd();
            }

            if (text == _lastText)
                return;

            _lastText = text;
            Text = text;
        }
        catch (IOException)
        {
        }
    }
}
