namespace Medical.Forms.EventArgs
{
    public class MenuItemClickedEventArgs : System.EventArgs
    {
        public string Key { get; set; }
        public string InvokeKey { get; set; }
    }

    public class InvokeKey
    {
        public const string Tranfer = "Tranfer";
        public const string OpenDialog = "OpenDialog";
        public const string SystemExit = "SystemExit";
    }
}
