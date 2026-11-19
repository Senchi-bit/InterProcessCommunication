namespace ComIpc.Sender;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private TextBox textBoxMessage;
    private Button buttonSend;

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
        textBoxMessage = new TextBox();
        buttonSend = new Button();
        SuspendLayout();

        textBoxMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxMessage.Location = new Point(12, 12);
        textBoxMessage.MaxLength = 256;
        textBoxMessage.Name = "textBoxMessage";
        textBoxMessage.Size = new Size(360, 23);
        textBoxMessage.TabIndex = 0;

        buttonSend.Location = new Point(12, 44);
        buttonSend.Name = "buttonSend";
        buttonSend.Size = new Size(120, 28);
        buttonSend.TabIndex = 1;
        buttonSend.Text = "Отправить";
        buttonSend.UseVisualStyleBackColor = true;
        buttonSend.Click += buttonSend_Click;

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(384, 84);
        Controls.Add(textBoxMessage);
        Controls.Add(buttonSend);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "COM IPC Sender";
        ResumeLayout(false);
        PerformLayout();
    }
}
