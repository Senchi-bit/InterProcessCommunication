namespace ComIpc.Receiver;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(480, 240);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "COM IPC Receiver";
    }
}
