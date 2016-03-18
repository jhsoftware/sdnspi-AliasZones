namespace AliasZonesPlugIn
{
  partial class SettingsUI
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
      this.label1 = new System.Windows.Forms.Label();
      this.txtFrom = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtTo = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(-3, 221);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(158, 13);
      this.label1.TabIndex = 2;
      this.label1.Text = "Clone from zone (domain name):";
      // 
      // txtFrom
      // 
      this.txtFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtFrom.Location = new System.Drawing.Point(0, 237);
      this.txtFrom.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
      this.txtFrom.Name = "txtFrom";
      this.txtFrom.Size = new System.Drawing.Size(413, 20);
      this.txtFrom.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(-3, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(327, 13);
      this.label2.TabIndex = 0;
      this.label2.Text = "Alias zone names (domain names to clone records for) - one per line:";
      // 
      // txtTo
      // 
      this.txtTo.AcceptsReturn = true;
      this.txtTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtTo.Location = new System.Drawing.Point(0, 16);
      this.txtTo.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
      this.txtTo.Multiline = true;
      this.txtTo.Name = "txtTo";
      this.txtTo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
      this.txtTo.Size = new System.Drawing.Size(413, 195);
      this.txtTo.TabIndex = 1;
      this.txtTo.WordWrap = false;
      // 
      // SettingsUI
      // 
      this.Controls.Add(this.txtTo);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.txtFrom);
      this.Controls.Add(this.label1);
      this.Name = "SettingsUI";
      this.Size = new System.Drawing.Size(413, 280);
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.TextBox txtFrom;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtTo;
  }
}
