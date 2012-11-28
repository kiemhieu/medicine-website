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
    }
}
