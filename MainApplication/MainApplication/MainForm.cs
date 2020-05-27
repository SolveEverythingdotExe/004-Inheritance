using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainApplication
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        //this is just a code to open the forms
        // lets test
        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //set the formname based on MenuStrip that has been clicked
            String formName = e.ClickedItem.Text + "Form";

            //check if the form exists
            bool formExists = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                from type in assembly.GetTypes()
                where type.Name == formName
                select type).Any();

            //check if form is already opened
            bool formOpened = (Application.OpenForms[formName] != null);
            
            //open the form if it exists and not already opened
            if (formExists && !formOpened)
            {
                Form form = Activator.CreateInstance(Type.GetType("MainApplication." + formName)) as Form;
                form.MdiParent = this;
                form.Show();
                form.Location = new Point(0, 0);
            }
        }
    }
}
