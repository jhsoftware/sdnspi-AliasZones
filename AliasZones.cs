using System;
using System.Collections.Generic;
using JHSoftware.SimpleDNS.Plugin;

namespace AliasZonesPlugIn 
{
  public class AliasZones : ICloneAnswerPlugIn
  {
    DomainName FromZone;
    Dictionary<DomainName, object> ToZones;

    public event IPlugInBase.AsyncErrorEventHandler AsyncError;
    public event IPlugInBase.LogLineEventHandler LogLine;
    public event IPlugInBase.SaveConfigEventHandler SaveConfig;

    public IPlugInBase.PlugInTypeInfo GetPlugInTypeInfo()
    {
      IPlugInBase.PlugInTypeInfo rv;
      rv.Name = "Alias Zones";  
      rv.Description = "Provides DNS records for one or more 'virtual' zones by cloning records from another zone (local or remote).";
      rv.InfoURL = "http://simpledns.com/plugin-aliaszones";
      rv.MultiThreaded = false;
      rv.ConfigFile = false;
      return rv;
    }

    public DNSAskAbout GetDNSAskAbout()
    {
      return new DNSAskAbout();
    }

    public OptionsUI GetOptionsUI(Guid instanceID, string dataPath)
    {
      return new SettingsUI();
    }

    public void LoadConfig(string config, Guid instanceID, string dataPath, ref int maxThreads)
    {
      var rdr = new System.IO.StringReader(config);
      FromZone = DomainName.Parse(rdr.ReadLine().Trim());
      ToZones = new Dictionary<DomainName, object>();
      string x;
      while(true) {
        x = rdr.ReadLine();
        if (x == null) break;
        x = x.Trim();
        if (x.Length == 0) continue;
        ToZones.Add(DomainName.Parse(x), null);
      }
      rdr.Close();
    }

    public void Lookup(IDNSRequest request, ref DomainName cloneFromZone, ref int prefixLabels, ref bool forceAA)
    {
      var tz = request.QName;
      var ct = 0;
      while (true)
      {
        if (tz == DomainName.Root) return;
        if(ToZones.ContainsKey(tz))
        {
          cloneFromZone = FromZone;
          prefixLabels = ct;
          forceAA = false;
          return;
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

    public void StartService()
    {
      return;
    }
    public void StopService()
    {
      return;
    }
  }
}
