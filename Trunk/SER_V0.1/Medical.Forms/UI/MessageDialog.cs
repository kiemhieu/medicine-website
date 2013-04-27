using System.Windows.Forms;
using Medical.Forms.Interfaces;

namespace Medical.Forms.UI
{
    public partial class MessageDialog : System.Windows.Forms.Form
    {
        private readonly string _iconPath = Application.StartupPath + "\\Icons";
        private const string error = "msg_error.png";
        private const string warning = "msg_warning.png";
        private const string info = "msg_info.png";
        private const string confirm = "msg_confirm.png";

        public IMessageManager MessageContainer { get; set; }

        public MessageDialog()
        {
            InitializeComponent();
        }

        public DialogResult ShowMessage(IWin32Window owner, string messageId, params object [] parameter)
        {
            string message = "";
            var msg = MessageContainer.GetMessageByID(messageId, parameter);
            message =msg == null ?  "Error on loading message id " + messageId: msg.Content;
            if (msg == null)
            {
                this.pictureBox.Image = System.Drawing.Image.FromFile(_iconPath + "\\" + error);
            }
            else
            {
                switch (msg.Type)
                {
                    case MessageBoxIcon.Error:
                        this.Text = "Lỗi";
                        this.pictureBox.Image = System.Drawing.Image.FromFile(_iconPath + "\\" + error);
                        break;
                    case MessageBoxIcon.Information:
                        this.Text = "Thông báo";
                        this.pictureBox.Image = System.Drawing.Image.FromFile(_iconPath + "\\" + info);
                        break;
                    case MessageBoxIcon.Question:
                        this.Text = "Xác nhận";
                        this.pictureBox.Image = System.Drawing.Image.FromFile(_iconPath + "\\" + confirm);
                        break;
                    case MessageBoxIcon.Warning:
                        this.Text = "Cảnh báo";
                        this.pictureBox.Image = System.Drawing.Image.FromFile(_iconPath + "\\" + warning);
                        break;
                    default:
                        break;
                }

                switch (msg.Button)
                {
                    case MessageBoxButtons.OK:
                        this.btnOK.Visible = true;
                        this.btnYes.Visible = false;
                        this.btnNo.Visible = false;
                        this.btnCancel.Visible = false;
                        break;
                    case MessageBoxButtons.OKCancel:
                        this.btnOK.Visible = true;
                        this.btnCancel.Visible = true;
                        this.btnYes.Visible = false;
                        this.btnNo.Visible = false;
                        break;
                    case MessageBoxButtons.YesNo:
                        this.btnYes.Visible = true;
                        this.btnNo.Visible = true;
                        this.btnOK.Visible = false;
                        this.btnCancel.Visible = false;
                        break;
                    case MessageBoxButtons.YesNoCancel:
                        this.btnYes.Visible = true;
                        this.btnNo.Visible = true;
                        this.btnCancel.Visible = true;
                        this.btnOK.Visible = false;
                        break;
                    default:
                        break;
                }
            }

            this.lblMessage.Text = string.Format(message, parameter);
            return this.ShowDialog(owner);
        }

        private static MessageDialog _instance;
        public static MessageDialog Instance
        {
            get { return _instance ?? (_instance = new MessageDialog()); }
        }
    }
}
