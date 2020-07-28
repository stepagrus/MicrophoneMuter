namespace MicrophoneMuter
{
  partial class Form1
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
      this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
      this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.contextMenuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // notifyIcon1
      // 
      this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
      this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
      this.notifyIcon1.Text = "Харибол!";
      this.notifyIcon1.Visible = true;
      // 
      // contextMenuStrip1
      // 
      this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
      this.contextMenuStrip1.Name = "contextMenuStrip1";
      this.contextMenuStrip1.Size = new System.Drawing.Size(109, 26);
      // 
      // выходToolStripMenuItem
      // 
      this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
      this.выходToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
      this.выходToolStripMenuItem.Text = "Выход";
      this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
      // 
      // Form1
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(800, 450);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "Form1";
      this.ShowInTaskbar = false;
      this.Text = "Microphone Muter";
      this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
      this.contextMenuStrip1.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.NotifyIcon notifyIcon1;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
  }
}

