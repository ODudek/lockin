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
using System.Security.Permissions;

namespace lock_in
{
    [ComVisible(true)]
    [COMServerAssociation(AssociationType.AllFiles)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath) + "\\lock_in.exe %1";
            var key = Registry.ClassesRoot.OpenSubKey(@"Directory\shell\Lock folder");
            if (key == null)
            {
                RegistryKey key1;
                key1 = Registry.ClassesRoot.CreateSubKey(@"Directory\shell\Lock folder");
                key1 = Registry.ClassesRoot.CreateSubKey(@"Directory\shell\Lock folder\command");
                key1.SetValue(string.Empty, Assembly.GetExecutingAssembly().Location + " %1");
            }
            var key3 = Registry.CurrentUser.OpenSubKey(@"Software\lock_in");
            if(key3 == null)
            {
            RegistryKey key2;
            key2 = Registry.CurrentUser.CreateSubKey(@"Software\lock_in");
            key2 = Registry.CurrentUser.CreateSubKey(@"Software\lock_in\password");
            }
            InitializeComponent();
        }

        private void haslo_Click(object sender, EventArgs e)
        {
            string sciezka2 = lock_in.Program.sciezka;
            string directory = sciezka2.Split(Path.DirectorySeparatorChar).GetValue((sciezka2.Split(Path.DirectorySeparatorChar).Length - 1)).ToString();
            Microsoft.Win32.RegistryKey open = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software").OpenSubKey(@"lock_in\password");
            if (open != null)
            {
                if (open.GetValue(sciezka2) == null)
                {
                    Form2 zaloz_haslo = new Form2();
                    zaloz_haslo.Show();
                }
                else
                {
                    MessageBox.Show("Folder is already locked");
                }
            }
        }

        private void odblokuj_Click(object sender, EventArgs e)
        {
            string sciezka2 = lock_in.Program.sciezka;
            Microsoft.Win32.RegistryKey open = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software").OpenSubKey(@"lock_in\password");
            if (open != null)
            {
                if (open.GetValue(sciezka2) == null)
                {
                    MessageBox.Show("Folder need to be locked");
                }
                else
                {
                    Form3 odblokuj_okno = new Form3();
                    odblokuj_okno.Show();
                }
            }

        }
    }
}
