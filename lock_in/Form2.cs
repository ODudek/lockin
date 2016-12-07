using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Finisar.SQLite;
using System.IO;
using Microsoft.Win32;
using SharpShell.SharpContextMenu;
using System.Reflection;
using System.Runtime.InteropServices;
using SharpShell.Attributes;
using System.Security.AccessControl;
using System.Management;
using System.Management.Instrumentation;

namespace lock_in
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sciezka2 = lock_in.Program.sciezka;
            if (password1.Text != string.Empty || password2.Text != string.Empty)
            {
                if (password1.Text == password2.Text)
                {
                    RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\lock_in\password");
                    key.SetValue(sciezka2, password2.Text);
                    key.Close();
                    SelectQuery query = new SelectQuery("Win32_UserAccount");
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                    foreach (ManagementObject envVar in searcher.Get())
                    {

                        string user = (envVar["Name"].ToString());
                        DirectoryInfo myDirectoryInfo = new DirectoryInfo(sciezka2);
                        DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                        string User = System.Environment.UserDomainName + "\\" + user.ToString();
                        myDirectorySecurity.AddAccessRule(new FileSystemAccessRule(User, FileSystemRights.Read, AccessControlType.Deny));
                        myDirectoryInfo.SetAccessControl(myDirectorySecurity);
                    }
                    MessageBox.Show("Folder is locked");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password isn't correct");
                }
            }
            else
            {
                MessageBox.Show("You need to insert password");
            }


        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void password2_TextChanged(object sender, EventArgs e)
        {

        }

        private void password1_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
