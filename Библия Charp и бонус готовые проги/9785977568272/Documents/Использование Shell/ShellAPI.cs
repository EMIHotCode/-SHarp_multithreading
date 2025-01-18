using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace ShellExample
{
    public class ShellAPI
    {
        public const int S_OK = 0;
        public const int S_FALSE = 1;
        public const int MAX_PATH = 260;

        public static int cbFileInfo = Marshal.SizeOf(typeof(SHFILEINFO));

        [Flags]
        public enum SHCONTF
        {
            FOLDERS = 0x0020,
            NONFOLDERS = 0x0040,
            INCLUDEHIDDEN = 0x0080,
            INIT_ON_FIRST_NEXT = 0x0100,
            NETPRINTERSRCH = 0x0200,
            SHAREABLE = 0x0400,
            STORAGE = 0x0800,
        }

        [Flags]
        public enum SHGNO
        {
            NORMAL = 0x0000,
            INFOLDER = 0x0001,
            FOREDITING = 0x1000,
            FORADDRESSBAR = 0x4000,
            FORPARSING = 0x8000
        }

        [Flags]
        public enum SHGFI : uint
        {
            ADDOVERLAYS = 0x20,
            ATTR_SPECIFIED = 0x20000,
            ATTRIBUTES = 0x800,
            DISPLAYNAME = 0x200,
            EXETYPE = 0x2000,
            ICON = 0x100,
            ICONLOCATION = 0x1000,
            LARGEICON = 0,
            LINKOVERLAY = 0x8000,
            OPENICON = 2,
            OVERLAYINDEX = 0x40,
            PIDL = 8,
            SELECTED = 0x10000,
            SHELLICONSIZE = 4,
            SMALLICON = 1,
            SYSICONINDEX = 0x4000,
            TYPENAME = 0x400,
            USEFILEATTRIBUTES = 0x10
        }

        [Flags]
        public enum SFGAO : uint
        {
            BROWSABLE = 0x8000000,
            CANCOPY = 1,
            CANDELETE = 0x20,
            CANLINK = 4,
            CANMONIKER = 0x400000,
            CANMOVE = 2,
            CANRENAME = 0x10,
            CAPABILITYMASK = 0x177,
            COMPRESSED = 0x4000000,
            CONTENTSMASK = 0x80000000,
            DISPLAYATTRMASK = 0xfc000,
            DROPTARGET = 0x100,
            ENCRYPTED = 0x2000,
            FILESYSANCESTOR = 0x10000000,
            FILESYSTEM = 0x40000000,
            FOLDER = 0x20000000,
            GHOSTED = 0x8000,
            HASPROPSHEET = 0x40,
            HASSTORAGE = 0x400000,
            HASSUBFOLDER = 0x80000000,
            HIDDEN = 0x80000,
            ISSLOW = 0x4000,
            LINK = 0x10000,
            NEWCONTENT = 0x200000,
            NONENUMERATED = 0x100000,
            READONLY = 0x40000,
            REMOVABLE = 0x2000000,
            SHARE = 0x20000,
            STORAGE = 8,
            STORAGEANCESTOR = 0x800000,
            STORAGECAPMASK = 0x70c50008,
            STREAM = 0x400000,
            VALIDATE = 0x1000000
        }

        [Flags]
        public enum FILE_ATTRIBUTE
        {
            READONLY = 0x00000001,
            HIDDEN = 0x00000002,
            SYSTEM = 0x00000004,
            DIRECTORY = 0x00000010,
            ARCHIVE = 0x00000020,
            DEVICE = 0x00000040,
            NORMAL = 0x00000080,
            TEMPORARY = 0x00000100,
            SPARSE_FILE = 0x00000200,
            REPARSE_POINT = 0x00000400,
            COMPRESSED = 0x00000800,
            OFFLINE = 0x00001000,
            NOT_CONTENT_INDEXED = 0x00002000,
            ENCRYPTED = 0x00004000
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public SFGAO dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }


        [DllImport("shell32.dll")]
        public static extern Int32 SHGetDesktopFolder(out IntPtr ppshf);

        [DllImport("shell32", EntryPoint = "SHGetFileInfo", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SHGetFileInfo(string pszPath, FILE_ATTRIBUTE dwFileAttributes, ref SHFILEINFO sfi, int cbFileInfo, SHGFI uFlags);
        [DllImport("shell32", EntryPoint = "SHGetFileInfo", ExactSpelling = false, CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SHGetFileInfo( IntPtr ppidl, FILE_ATTRIBUTE dwFileAttributes, ref SHFILEINFO sfi, int cbFileInfo, SHGFI uFlags);
    }
}
