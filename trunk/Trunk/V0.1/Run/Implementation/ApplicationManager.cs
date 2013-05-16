using System;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using Medical.Data;
using Medical.Data.EntitiyExtend;
using Medical.Data.Repositories;
using Medical.Forms.Entities;
using Medical.Forms.Implements;
using Medical.Forms.Interfaces;
using Medical.Forms.UI;
using Run.Implementation;

namespace Run.Implementation
{
    public class ApplicationManager
    {
        private static ILogManager log;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApplicationManager"/> class.
        /// </summary>
        public  ApplicationManager()
        {
            this._mainForm = new MainForm();
            var obj = (ContainerConfiger)ConfigurationSettings.GetConfig("MenuProvider");
            var menuProvider = Activator.CreateInstance(Type.GetType(obj.ClassName), obj.ConfigFile) as IMenuManager;
            this._mainForm.TopMenu = menuProvider;

            obj = (ContainerConfiger)ConfigurationSettings.GetConfig("ContainerProvider");
            var contianerProvider = Activator.CreateInstance(Type.GetType(obj.ClassName), obj.ConfigFile) as IContainerProvider;
            this._mainForm.ModuleContainer = contianerProvider;

            obj = (ContainerConfiger)ConfigurationSettings.GetConfig("MessageProvider");
            var messageProvider = Activator.CreateInstance(Type.GetType(obj.ClassName), obj.ConfigFile) as IMessageManager;
            this._mainForm.MessageContainer = messageProvider;

            Medical.Forms.Implements.MessageManager.Instance.Load(obj.ConfigFile);
            
            obj = (ContainerConfiger)ConfigurationSettings.GetConfig("LogProvider");
            var logProvider = Activator.CreateInstance(Type.GetType(obj.ClassName)) as ILogManager;
            logProvider.MessageProvider = messageProvider;
            this._mainForm.LogManager = logProvider;
            log = logProvider;

            //var viewManager = new ViewManager();
            //this._mainForm.ViewManager = viewManager;
            int clinicId = Int32.Parse(ConfigurationSettings.AppSettings.Get("ID"));
            IClinicRepository clinicRepository = new ClinicRepository();
            AppContext.CurrentClinic = clinicRepository.Get(clinicId);

            this._mainForm.Text = ConfigurationSettings.AppSettings.Get("Title");
            this._mainForm.Icon = System.Drawing.Icon.ExtractAssociatedIcon(ConfigurationSettings.AppSettings.Get("IconPath"));
            // this._mainForm.CommonInitilize();
        }

        /// <summary>
        /// Handles the exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        public static void HandleException(Exception ex)
        {
            MessageBox.Show(ex.Message);
            var strBuilder = new StringBuilder();
            var exception = ex;
            strBuilder.AppendLine("[Exception] -----------------------------------------------------------------------------");
            while (exception != null)
            {
                strBuilder.Append(exception.HelpLink);
                strBuilder.AppendLine("Source: " + exception.Source);
                strBuilder.AppendLine("Stack: " + exception.StackTrace);
                strBuilder.Append("Method : " + exception.TargetSite.Name + "(");
                foreach (var parameterInfo in exception.TargetSite.GetParameters())
                {
                    strBuilder.Append(parameterInfo.GetType() + "   " + parameterInfo.Name);
                }
                strBuilder.Append(");");
                strBuilder.AppendLine(); 
                strBuilder.AppendLine(exception.Message);
                strBuilder.AppendLine(); 
                strBuilder.AppendLine();
                exception = exception.InnerException;
            }
            strBuilder.AppendLine("---------------------------------------------------------------------------------------");
            log.LogError("ERR0001", strBuilder.ToString());
        }

        /// <summary>
        /// Gets the entry form.
        /// </summary>
        /// <value>The entry form.</value>
        private readonly MainForm _mainForm;
        public MainForm EntryForm
        {
            get { return this._mainForm; }
        }
    }
}
