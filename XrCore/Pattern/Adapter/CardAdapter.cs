using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XrCore.Pattern.Adapter
{
    public class CardAdapter : ICardReader
    {
        public ICardWriter Writer;
        public CardAdapter(ICardWriter writer)
        {
            this.Writer = writer;
        }
        public string ReadCard(string filePath)
        {
            return new CardReader().ReadCard(filePath);
        }
        public bool WriteCard(string filePath, string content)
        {
            return Writer.WriteCard(filePath, content);
        }
    }
}
