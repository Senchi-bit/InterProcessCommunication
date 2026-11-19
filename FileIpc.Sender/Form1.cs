namespace FileIpc.Sender;

public partial class Form1 : Form
{
    private static readonly string SharedFilePath =
        Path.Combine(Path.GetTempPath(), "ipc-lab-title.txt");

    public Form1()
    {
        InitializeComponent();
    }

    private void buttonSend_Click(object sender, EventArgs e)
    {
        var tempPath = SharedFilePath + ".tmp";
        var text = textBoxMessage.Text;

        for (var attempt = 0; ; attempt++)
        {
            try
            {
                File.WriteAllText(tempPath, text, System.Text.Encoding.UTF8);
                File.Move(tempPath, SharedFilePath, overwrite: true);
                return;
            }
            catch (IOException) when (attempt < 4)
            {
                Thread.Sleep(30);
            }
        }
    }
}
