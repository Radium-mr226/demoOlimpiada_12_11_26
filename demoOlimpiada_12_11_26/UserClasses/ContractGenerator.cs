using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;

namespace demoOlimpiada_12_11_26.UserClasses
{
    public static class ContractGenerator
    {
        public static void Create(string templatePath, string outputPath, Dictionary<string, string> values)
        {
            File.Copy(templatePath, outputPath, true);

            using (var fs = new FileStream(outputPath, FileMode.Open, FileAccess.ReadWrite))
            using (var zip = new ZipArchive(fs, ZipArchiveMode.Update))
            {
                var entry = zip.GetEntry("word/document.xml");
                string xml;
                using (var reader = new StreamReader(entry.Open(), Encoding.UTF8))
                    xml = reader.ReadToEnd();

                foreach (var kv in values)
                    xml = xml.Replace("{" + kv.Key + "}", SecurityElement.Escape(kv.Value));

                xml = xml.Replace("<w:highlight w:val=\"yellow\"/>", "");

                entry.Delete();
                var newEntry = zip.CreateEntry("word/document.xml");
                using (var writer = new StreamWriter(newEntry.Open(), new UTF8Encoding(false)))
                    writer.Write(xml);
            }
        }
    }
}
