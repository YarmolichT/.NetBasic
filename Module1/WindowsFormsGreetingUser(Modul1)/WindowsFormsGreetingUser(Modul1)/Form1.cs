using ClassLibrary2;
using System;
using System.Windows.Forms;

namespace WindowsFormsGreetingUser_Modul1_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
          
        
        private void btnShowGreeting_Click(object sender, EventArgs e)
        {
            
            var name = txtUserName.Text;
            var greetingMessage = ($" Hello, {name}!");
            
            AddTime addTime = new AddTime();
            string TimeGreeting =  addTime.ConcatenateString(greetingMessage);

            lblUserGreeting.Text = ($"{TimeGreeting}");


        }


    }
}
