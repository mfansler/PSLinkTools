using System.Management.Automation; // PowerShell SDK
using System.Runtime.InteropServices; // Required to import DLL's
using System;

namespace com.mervinfansler.LinkTools
{
    [Cmdlet(VerbsCommon.New, "Symlink")]
    public class NewSymlinkCommand : Cmdlet
    {

        #region Parameters

        [Parameter(Mandatory = true,Position=0)]
        public string LiteralPath
        {
            get { return literalPath; }
            set { literalPath = value; }
        }
        private string literalPath;

        [Parameter(Mandatory = true,Position=1)]
        public string Target
        {
            get { return target; }
            set { target = value; }
        }
        private string target;

        [Parameter(Mandatory = false)]
        public ItemTypes Type
        {
            get { return itemType; }
            set { itemType = value; }
        }
        private ItemTypes itemType = ItemTypes.File;

        #endregion

        #region CreateSymbolicLink extern

        // ** Documentation for Win32 CreateSymbolicLink() function
        //
        // BOOLEAN WINAPI CreateSymbolicLink(
        //   __in  LPTSTR lpSymlinkFileName,
        //   __in  LPTSTR lpTargetFileName,
        //   __in  DWORD dwFlags
        // );

        [DllImport("Kernel32.dll", EntryPoint="CreateSymbolicLinkW", CharSet=CharSet.Unicode)]
        private static extern int CreateSymbolicLink(
            [In] String symlinkFileName,
            [In] String targetFileName,
            int flags);

        #endregion

        #region Cmdlet Overrides

        protected override void ProcessRecord()
        {
            // return of 0 means failure; otherwise success
            WriteObject( CreateSymbolicLink( LiteralPath, Target, (Int32)Type ) );
        }

        #endregion

        #region ItemTypes

        public enum ItemTypes
        {
            File        = 0x0,
            Directory   = 0x1
        }

        #endregion

    }
}
