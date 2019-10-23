using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace VSIX_CCA_ProjectTemplate
{
    public partial class WizardDialogForm : Form
    {
        public Dictionary<string, string> AllCustomParameters => ReadCustomParams();

        private Dictionary<string, string> ReadCustomParams()
        {
            return Controls.OfType<Control>().Where(c => c.Tag != null && c.Tag.ToString().StartsWith("$")).Select(control =>
            {
                string name = control.Tag.ToString();
                string value = ReadValue(control);
                return new KeyValuePair<string, string>(name, value);
            }).ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        private string ReadValue(Control control)
        {
            if (control is TextBox box)
                return box.Text;
            if (control is CheckBox check)
                return check.Checked ? "True" : "False";
            var bindingFlags = BindingFlags.GetProperty | BindingFlags.Public;
            var prop = control.GetType().GetProperty("Value", bindingFlags) ?? control.GetType().GetProperty("Text", bindingFlags);
            if (prop != null)
                return prop.GetValue(control).ToString();
            return null;
        }

        private void WriteValue(Control control, string value)
        {
            if (control is TextBox box)
                box.Text = value;
            else if (control is CheckBox check)
                 check.Checked = value == "True";
            else
            {
                var bindingFlags = BindingFlags.GetProperty | BindingFlags.Public;
                var prop = control.GetType().GetProperty("Value", bindingFlags) ?? control.GetType().GetProperty("Text", bindingFlags);
                if (prop != null)
                {
                    try
                    {
                        prop.SetValue(control, value);
                    }
                    catch
                    {
                    }
                }
            }
        }

        public WizardDialogForm(Dictionary<string, string> parameters)
        {
            InitializeComponent();
            LoadParams(parameters);
        }

        private void LoadParams(Dictionary<string, string> parameters)
        {
            foreach (var pair in parameters)
            {
                var ctrl = Controls.OfType<Control>().FirstOrDefault(c => c.Tag != null && c.Tag.ToString() == pair.Key);
                if (ctrl != null)
                    WriteValue(ctrl, pair.Value);
            }
        }


        public WizardDialogForm()
        {
            InitializeComponent();
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
