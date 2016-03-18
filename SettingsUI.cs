using System.Windows.Forms;
using JHSoftware.SimpleDNS.Plugin;

namespace AliasZonesPlugIn
{
  public partial class SettingsUI : JHSoftware.SimpleDNS.Plugin.OptionsUI
  {
    public SettingsUI()
    {
      InitializeComponent();
    }

    public override void LoadData(string config)
    {
      if (string.IsNullOrEmpty(config)) return;
      var rdr = new System.IO.StringReader(config);
      txtFrom.Text = rdr.ReadLine().Trim();
      txtTo.Text = rdr.ReadToEnd();
      rdr.Close();
    }

    public override string SaveData()
    {
      return txtFrom.Text.Trim() + "\r\n" + txtTo.Text.Trim();
    }

    public override bool ValidateData()
    {
      DomainName d=null;
      string x;
      string y="";
      var rdr = new System.IO.StringReader(txtTo.Text.Trim());
      while (true)
      {
        x=rdr.ReadLine();
        if (x == null) break;
        if (x.Length== 0) continue;
        x = x.Replace(" ", "");
        if (!DomainName.TryParse(x, ref d))
        {
          ShowErr("Invalid domain name in 'Alias zone names': " + x);
          return false;
        }
        y += x + "\r\n";
      }
      rdr.Close();
      txtTo.Text = y;
      if (y.Length == 0)
      {
        ShowErr("At least one Alias Zone Name must be specified");
        return false;
      }

      txtFrom.Text = txtFrom.Text.Trim().ToLowerInvariant();
      if (!DomainName.TryParse(txtFrom.Text, ref d))
      {
        ShowErr("Invalid 'Clone from zone' domain name");
        return false;
      }
      return true;
    }

    private void ShowErr(string msg)
    {
      MessageBox.Show(msg, "Alias Zones plug-in", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

  }
}
