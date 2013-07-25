using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;


namespace DBCustomAction
{
    [RunInstaller(true)]
    public partial class DBCustomAction : System.Configuration.Install.Installer
    {
        public DBCustomAction()
        {
            InitializeComponent();
        }

        public override void Install(IDictionary stateSaver)
        {
            try
            {
                base.Install(stateSaver);
                String dbName = this.Context.Parameters["dbName"];
                if (String.IsNullOrEmpty(dbName)) return;
                this.AddDbTable(this.Context.Parameters["dbName"]);
            }
            catch (Exception)
            {
                this.Rollback(stateSaver);
                throw;
            }
        }

        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);

            String dbName = this.Context.Parameters["dbName"];
            if (String.IsNullOrEmpty(dbName)) return;
            this.DropDbTable(this.Context.Parameters["dbName"]);
        }

        private String GetSQL(String name)
        {
            try
            {
                var asm = Assembly.GetExecutingAssembly();
                // MessageBox.Show(asm.GetName().Name + "." + name);
                var stream = asm.GetManifestResourceStream(asm.GetName().Name + "." + name);
                var streamReader = new StreamReader(stream);
                return streamReader.ReadToEnd();
            } catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message);
                return "";
            }
        }

        private void ExecuteSQL(String dbName, String sql)
        {
            var connection = new SqlConnection(@"Data Source=Localhost\SQLEXPRESS;Initial Catalog=master;Integrated Security=True");
            var sqlCommand = new SqlCommand(sql, connection);

            String[] commands = sql.Split(new string[] { "\nGO" }, StringSplitOptions.RemoveEmptyEntries);

            sqlCommand.Connection.Open();
            sqlCommand.Connection.ChangeDatabase(dbName);

            var curr = String.Empty;
            try
            {

                foreach (String cmd in commands)
                {
                    curr = cmd;
                    sqlCommand.CommandText = cmd;
                    sqlCommand.ExecuteNonQuery();
                }

            }
            catch (Exception)
            {
                var form = new LogShow("Error at: " + curr);
                form.ShowDialog();
                throw;
            }
            finally
            {
                sqlCommand.Connection.Close();
            }
        }

        private void AddDbTable(String dbName)
        {
            try
            {
                var builder = new StringBuilder();
                builder.AppendLine(String.Format("IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}') ", dbName));
                builder.AppendLine("BEGIN ");
                builder.AppendLine(String.Format("CREATE DATABASE [{0}];", dbName));
                builder.AppendLine("END ");
                // ExecuteSQL("master", "CREATE DATABASE " + dbName);
                ExecuteSQL("master", builder.ToString());
                String str = GetSQL("sql.txt");

                var form = new LogShow(str);
                form.ShowDialog();
                ExecuteSQL(dbName, str);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw ex;
            }
        }

        private void DropDbTable(String dbName)
        {
            try
            {
                var builder = new StringBuilder();
                builder.AppendLine(String.Format("IF EXISTS (SELECT name FROM sys.databases WHERE name = N'{0}') ", dbName));
                builder.AppendLine("BEGIN ");
                builder.AppendLine(String.Format("DROP DATABASE [{0}];", dbName));
                builder.AppendLine("END ");
                // ExecuteSQL("master", "CREATE DATABASE " + dbName);
                ExecuteSQL("master", builder.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
                throw ex;
            }
        }
    }
}
