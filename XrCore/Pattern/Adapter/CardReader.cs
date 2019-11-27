using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Adapter
{
    public class CardReader : ICardReader
    {
        public string ReadCard(string filePath)
        {
            return "Read A Card";
        }
    }
}
