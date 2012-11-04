using System.Windows.Forms;

namespace Medical.Forms.Entities
{

    public class SystemMessage
    {
        public string ID { get; set; }

        public string Content { get; set; }

        public MessageBoxButtons Button { get; set; }

        public MessageBoxIcon Type { get; set; }
    }
}
