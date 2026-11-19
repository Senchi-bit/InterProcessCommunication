using System.Runtime.InteropServices;
using ComIpc.Contracts;
using Microsoft.CSharp.RuntimeBinder;

namespace ComIpc.Sender;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void buttonSend_Click(object sender, EventArgs e)
    {
        try
        {
            dynamic controller = RunningObjectTable.GetTitleController();
            controller.SetTitle(textBoxMessage.Text);
        }
        catch (COMException ex) when (ex.HResult == RunningObjectTable.MkEUnavailable)
        {
            MessageBox.Show(this, "Сначала запустите ComIpc.Receiver.", Text,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
        catch (Exception ex) when (ex is COMException or InvalidCastException or RuntimeBinderException)
        {
            MessageBox.Show(this, "Не удалось передать текст: " + ex.Message, Text,
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
