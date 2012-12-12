using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevComponents.DotNetBar.Controls;

namespace Medical.Forms.Common
{
    public class Validator
    {
        public static bool MandatoryChecking(RadioButton [] radios)
        {
            var valid = true;
            for (var i = 0; i < radios.Count(); i++)
            {
                if (radios[i].Checked) return false;
            }
            return true;
        }

        public static bool MandatoryChecking(TextBoxX textbox)
        {
            return !String.IsNullOrEmpty(textbox.Text);
        }

        public static bool MandatoryChecking(ComboBox combobox)
        {
            var value = combobox.SelectedValue;
            if (value == null) return false;
            var selectedVal = Convert.ToInt32(value);
            return selectedVal != 0;
        }
    }
}
