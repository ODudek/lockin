using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Win32;
using SharpShell.SharpContextMenu;
using System.Reflection;
using System.Runtime.InteropServices;
using SharpShell.Attributes;
using System.Management;
using System.Management.Instrumentation;
using System.Security.AccessControl;
using System.Security.Principal;

namespace lock_in
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sciezka2 = lock_in.Program.sciezka;
            //string sciezka = @"C:\Users\aleksander\Desktop\bla";
            if (password1.Text != string.Empty || password2.Text != string.Empty)
            {
                if (password1.Text == password2.Text)
                {
                    RegistryKey key1 = Registry.CurrentUser.OpenSubKey(@"Software\lock_in\password");
                    if (key1.GetValue(sciezka2).ToString() == password2.Text.ToString())
                    {
                        SelectQuery query = new SelectQuery("Win32_UserAccount");
                        ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
                        foreach (ManagementObject envVar in searcher.Get())
                        {

                            string user = (envVar["Name"].ToString());
                            DirectoryInfo myDirectoryInfo = new DirectoryInfo(sciezka2);
                            DirectorySecurity myDirectorySecurity = myDirectoryInfo.GetAccessControl();
                            string User = System.Environment.UserDomainName + "\\" + user.ToString();
                            myDirectorySecurity.RemoveAccessRule(new FileSystemAccessRule(User, FileSystemRights.FullControl, AccessControlType.Deny));
                            myDirectoryInfo.SetAccessControl(myDirectorySecurity);
                        }
                        RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\lock_in\password");
                        key.DeleteValue(sciezka2);
                        key.Close();
                        MessageBox.Show("Hasło zostało usunięte");
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Błędne hasło");
                    }
                }
                else
                {
                    MessageBox.Show("Hasła są niezgodne");
                }
            }
            else
            {
                MessageBox.Show("Musisz wpisać hasło");
            }
        }
    }
}
