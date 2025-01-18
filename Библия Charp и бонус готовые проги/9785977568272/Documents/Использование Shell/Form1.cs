using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace ShellExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // get desktop folder
            IntPtr shellFolderPtr;
            ShellAPI.SHGetDesktopFolder(out shellFolderPtr);


            IShellFolder shellFolder = (IShellFolder)Marshal.GetTypedObjectForIUnknown(shellFolderPtr, typeof(IShellFolder));

            listView1.Items.Clear();

            ShellAPI.SHCONTF fileFlag = ShellAPI.SHCONTF.NONFOLDERS | ShellAPI.SHCONTF.FOLDERS;

            IntPtr fileEnumPtr = IntPtr.Zero;
            if (shellFolder.EnumObjects(IntPtr.Zero, fileFlag, out fileEnumPtr) == ShellAPI.S_OK)
            {
                IEnumIDList fileEnum = (IEnumIDList)Marshal.GetTypedObjectForIUnknown(fileEnumPtr, typeof(IEnumIDList));

                IntPtr gelt;
                int celtFetched;
                while (fileEnum.Next(1, out gelt, out celtFetched) == ShellAPI.S_OK && celtFetched == 1)
                {
                    ShellAPI.SHFILEINFO info = new ShellAPI.SHFILEINFO();
                    ShellAPI.SHGetFileInfo(gelt, 0, ref info, ShellAPI.cbFileInfo,
                        ShellAPI.SHGFI.DISPLAYNAME | ShellAPI.SHGFI.PIDL | ShellAPI.SHGFI.TYPENAME);

                    listView1.Items.Add(info.szDisplayName);
                }
            }
        }
    }
}
