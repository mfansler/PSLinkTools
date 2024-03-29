###############################
#
# Script to Build LinkTools.dll
#
###############################

# Include PowerShell Reference (Requires PowerShell SDK to be installed)
$ref = "$Env:ProgramFiles\Reference Assemblies\Microsoft\WindowsPowerShell\v1.0\System.Management.Automation.dll"

# Set Compiler
#$compiler = "$env:windir/Microsoft.NET/Framework/v2.0.50727/csc.exe"  # x86
$compiler = "$env:windir/Microsoft.NET/Framework64/v2.0.50727/csc.exe"  # x64

# Build Debug Version
&$compiler /target:library /debug /r:$ref /out:bin/Debug/LinkTools.dll .\src\AllCmdletPSSnapIn.cs .\src\NewSymlinkCommand.cs .\Properties\AssemblyInfo.cs

# Build Release Version
&$compiler /target:library /o /r:$ref /out:bin/Release/LinkTools.dll .\src\AllCmdletPSSnapIn.cs .\src\NewSymlinkCommand.cs .\Properties\AssemblyInfo.cs