using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Medical.Data
{
    public class EntityBase : System.ComponentModel.IDataErrorInfo
    {
        private string errorString = string.Empty;
        private Dictionary<string, string> errorDic = new Dictionary<string, string>();

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. The default is an empty string ("").</returns>
        public string Error
        {
            get
            {
                if (this.errorDic.Count > 0) return this.errorString != string.Empty ? this.errorString : "Đang có " + this.errorDic.Count + " lỗi";
                return string.Empty;
            }
        }

        /// <summary>
        /// Gets the error message for the property with the given name.
        /// </summary>
        /// <returns>The error message for the property. The default is an empty string ("").</returns>
        public string this[string columnName]
        {
            get
            {
                return !this.errorDic.ContainsKey(columnName) ? string.Empty : this.errorDic[columnName];
            }
        }

        /// <summary>
        /// Adds the error.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="error">The error.</param>
        public void AddError(string propertyName, string error)
        {
            if (!errorDic.ContainsKey(propertyName)) errorDic.Add(propertyName, error);
        }

        /// <summary>
        /// Removes the error.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void RemoveError(string propertyName)
        {
            if (errorDic.ContainsKey(propertyName)) errorDic.Remove(propertyName);
        }

        /// <summary>
        /// Validates this instance.
        /// </summary>
        public virtual void Validate()
        {
            this.errorDic.Clear();
        }

        /// <summary>
        /// Gets a value indicating whether this instance is valid.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is valid; otherwise, <c>false</c>.
        /// </value>
        public bool IsValid
        {
            get { return this.Error.Equals(string.Empty); }
        }

        /// <summary>
        /// Sets the info.
        /// </summary>
        /// <param name="isUpdate">if set to <c>true</c> [is update].</param>
        public void SetInfo(bool isUpdate)
        {
            this.SetInfo("LastUpdatedDate", DateTime.Now);
            this.SetInfo("LastUpdatedUser", AppContext.LoggedInUser.Id);
            UpdateVersion();

            if (isUpdate) return;
            this.SetInfo("CreatedDate", DateTime.Now);
            this.SetInfo("CreatedUser", AppContext.LoggedInUser.Id);
        }

        /// <summary>
        /// Sets the info.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <param name="value">The value.</param>
        private void SetInfo(String key, Object value)
        {
            var property = this.GetType().GetProperty(key);
            if (property != null) property.SetValue(this, value, null);
        }

        /// <summary>
        /// Updates the version.
        /// </summary>
        private void UpdateVersion()
        {
            var property = this.GetType().GetProperty("Version");
            if (property == null) return;
            var value = property.GetValue(this, null);
            if (value == null)
            {
                property.SetValue(this, 0, null);
                return;
            }

            var intValue = Convert.ToInt32(value);
            property.SetValue(this, intValue + 1, null);
        }
    }
}
