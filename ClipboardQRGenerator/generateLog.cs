using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ClipboardQRGenerator
{
    public class generateLogWrapper
    {
        public List<string> ReadLog()
        {
            List<string> logs = new List<string>();
            using (StreamReader sr = new StreamReader(@"logs/geneLog.json", Encoding.UTF8))
            {
                var json = sr.ReadToEnd();
                logs = JsonConvert.DeserializeObject<List<string>>(json);
            }
            if (logs == null) { logs = new List<string>(); }
            return logs;
        }
        public void WriteLog(dynamic log)
        {
            var json = JsonConvert.SerializeObject(log);
            using (StreamWriter sw = new StreamWriter("logs/geneLog.json", false, Encoding.UTF8))
            {
                sw.Write(json);
            }
        }
    }
}