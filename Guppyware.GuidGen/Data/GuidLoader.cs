using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Guppyware.GuidGen.Data
{
    public class GuidLoader
    {
        public List<WellKnownGuid> WellKnownGuids;

        private string filename;

        public GuidLoader()
        {
            filename = Path.Combine(Application.StartupPath, "well-known.json");
        }

        public void Load()
        {
            if (File.Exists(filename))
            {
                var json = File.ReadAllText(filename);
                WellKnownGuids = JsonConvert.DeserializeObject<List<WellKnownGuid>>(json);
            }
            else
            {
                WellKnownGuids = new List<WellKnownGuid>()
                {
                    new WellKnownGuid(Guid.Empty, "Empty")
                };

                Save();
            }
        }

        public void Save()
        {
            var json = JsonConvert.SerializeObject(WellKnownGuids, Formatting.Indented);
            File.WriteAllText(filename, json);
        }
    }
}
