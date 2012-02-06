using System;
using System.Management.Automation;
using System.ComponentModel;


namespace com.mervinfansler.LinkTools
{
    #region PowerShell snap-in

    [RunInstaller(true)]
    public class LinkToolsPSSnapIn : PSSnapIn
    {
        public LinkToolsPSSnapIn() : base() {
        }

        public override string Name {
            get { return "LinkTools"; }
        }

        public override string Vendor {
            get { return "Mervin Fansler"; }
        }

        public override string Description {
            get { return "This is a PowerShell snap-in that includes the New-Symlink cmdlet."; }
        }
    }

    #endregion PowerShell snap-in
}
