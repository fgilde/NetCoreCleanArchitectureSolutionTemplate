using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace VSIX_CCA_ProjectTemplate
{
    public partial class WizardDialogForm : Form
    {
        public Dictionary<string, string> AllCustomParameters => ReadCustomParams();

        public WizardDialogForm(Dictionary<string, string> parameters)
        {
            InitializeComponent();
            LoadInitalParamValues(parameters);
        }

        private void LoadInitalParamValues(Dictionary<string, string> parameters)
        {
            foreach (var pair in parameters)
            {
                var ctrl = GetControls().FirstOrDefault(c => c.Tag != null && c.Tag.ToString() == pair.Key);
                if (ctrl != null)
                    WriteValue(ctrl, pair.Value);
            }
        }
        
        public WizardDialogForm()
        {
            InitializeComponent();
        }

        private IEnumerable<Control> GetControls()
        {
            return Controls.OfType<Control>().Recursive(control => control.Controls.OfType<Control>());
        }

        private void buttonApply_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private Dictionary<string, string> ReadCustomParams()
        {
            return GetControls().Where(c => c.Tag != null && c.Tag.ToString().StartsWith("$")).Select(control =>
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

                try
                {
                    prop?.SetValue(control, value);
                }
                catch { }

            }
        }

    }
}
