namespace FileIpc.Receiver;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private System.Windows.Forms.Timer timerPoll;

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
        timerPoll = new System.Windows.Forms.Timer(components);
        SuspendLayout();

        timerPoll.Interval = 400;
        timerPoll.Tick += timerPoll_Tick;
        timerPoll.Enabled = true;

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(480, 240);
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "File IPC Receiver";
        ResumeLayout(false);
    }
}
