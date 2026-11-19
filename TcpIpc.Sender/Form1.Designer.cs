namespace TcpIpc.Sender;

partial class Form1
{
    private System.ComponentModel.IContainer components = null;
    private Label labelHost;
    private TextBox textBoxHost;
    private Label labelPort;
    private TextBox textBoxPort;
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
        labelHost = new Label();
        textBoxHost = new TextBox();
        labelPort = new Label();
        textBoxPort = new TextBox();
        textBoxMessage = new TextBox();
        buttonSend = new Button();
        SuspendLayout();

        labelHost.AutoSize = true;
        labelHost.Location = new Point(12, 15);
        labelHost.Name = "labelHost";
        labelHost.Size = new Size(37, 15);
        labelHost.Text = "Хост";

        textBoxHost.Location = new Point(70, 12);
        textBoxHost.Name = "textBoxHost";
        textBoxHost.Size = new Size(180, 23);
        textBoxHost.TabIndex = 0;
        textBoxHost.Text = "127.0.0.1";

        labelPort.AutoSize = true;
        labelPort.Location = new Point(262, 15);
        labelPort.Name = "labelPort";
        labelPort.Size = new Size(35, 15);
        labelPort.Text = "Порт";

        textBoxPort.Location = new Point(315, 12);
        textBoxPort.MaxLength = 5;
        textBoxPort.Name = "textBoxPort";
        textBoxPort.Size = new Size(80, 23);
        textBoxPort.TabIndex = 1;
        textBoxPort.Text = "5050";

        textBoxMessage.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        textBoxMessage.Location = new Point(12, 44);
        textBoxMessage.MaxLength = 256;
        textBoxMessage.Name = "textBoxMessage";
        textBoxMessage.Size = new Size(381, 23);
        textBoxMessage.TabIndex = 2;

        buttonSend.Location = new Point(12, 76);
        buttonSend.Name = "buttonSend";
        buttonSend.Size = new Size(120, 28);
        buttonSend.TabIndex = 3;
        buttonSend.Text = "Отправить";
        buttonSend.UseVisualStyleBackColor = true;
        buttonSend.Click += buttonSend_Click;

        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(400, 116);
        Controls.Add(labelHost);
        Controls.Add(textBoxHost);
        Controls.Add(labelPort);
        Controls.Add(textBoxPort);
        Controls.Add(textBoxMessage);
        Controls.Add(buttonSend);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MaximizeBox = false;
        Name = "Form1";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "TCP IPC Sender";
        ResumeLayout(false);
        PerformLayout();
    }
}
