using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Adapter
{
    public class CardWriter : ICardWriter
    {
        public bool WriteCard(string filePath, string content)
        {
            if (File.Exists(filePath))
            {
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
                {
                    fs.Write(Encoding.ASCII.GetBytes(content), 0, 0);
                }
                return true;
            }
            return false;
        }
    }
}
