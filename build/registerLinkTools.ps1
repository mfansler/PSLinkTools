###############################
#
# Script to Register LinkTools.dll
#
###############################

# Set InstallUtil
#$installutil = "$env:windir/Microsoft.NET/Framework/v2.0.50727/installutil.exe"  # x86
$installutil = "$env:windir/Microsoft.NET/Framework64/v2.0.50727/installutil.exe"  # x64

# Install Debug Version
#&$installutil .\bin\Debug\LinkTools.dll

# Install Release Version
&$installutil .\bin\Release\LinkTools.dll