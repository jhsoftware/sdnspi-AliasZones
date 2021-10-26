using System;
using System.Collections.Generic;
using JHSoftware.SimpleDNS.Plugin;
using JHSoftware.SimpleDNS;
using System.Threading.Tasks;

namespace AliasZonesPlugIn 
{
  public class AliasZones : ICloneAnswer , IOptionsUI
  {
    DomName FromZone;
    Dictionary<DomName, object> ToZones;

    private IHost _Host;
    IHost IPlugInBase.Host { get => _Host; set => _Host = value; }

    public IPlugInBase.PlugInTypeInfo GetTypeInfo()
    {
      IPlugInBase.PlugInTypeInfo rv;
      rv.Name = "Alias Zones";  
      rv.Description = "Provides DNS records for one or more 'virtual' zones by cloning records from another zone (local or remote).";
      rv.InfoURL = "https://simpledns.plus/plugin-aliaszones";
      return rv;
    }

    public OptionsUI GetOptionsUI(Guid instanceID, string dataPath)
    {
      return new SettingsUI();
    }

    void IPlugInBase.LoadConfig(string config, Guid instanceID, string dataPath)
    {
      var rdr = new System.IO.StringReader(config);
      FromZone = DomName.Parse(rdr.ReadLine().Trim());
      ToZones = new Dictionary<DomName, object>();
      string x;
      while(true) {
        x = rdr.ReadLine();
        if (x == null) break;
        x = x.Trim();
        if (x.Length == 0) continue;
        ToZones.Add(DomName.Parse(x), null);
      }
      rdr.Close();
    }

    Task<ICloneAnswer.Result> ICloneAnswer.LookupCloneAnswer(IRequestContext request)
    {
      var tz = request.QName;
      var ct = 0;
      while (true)
      {
        if (tz == DomName.Root) return Task.FromResult<ICloneAnswer.Result>(null);
        if(ToZones.ContainsKey(tz))
        {
          return Task.FromResult(new ICloneAnswer.Result
          {
            CloneFromZone = FromZone,
            PrefixLabels = ct,
            ForceAA = false
          });
        }
        ct += 1;
        tz = tz.Parent();
      }
    }

    // -------------- not used ---------------

    public bool InstanceConflict(string config1, string config2, ref string errorMsg)
    {
      return false;
    }

    public string SaveState()
    {
      return null;
    }
    public void LoadState(string state)
    {
      return;
    }

    public void StopService()
    {
      return;
    }

    Task IPlugInBase.StartService()
    {
      return Task.CompletedTask;
    }

  }
}
