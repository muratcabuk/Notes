windows server  .netframework 3.5


I had this problem as well on my machine at work. Try doing the following it worked and allowed me to download the .Net Framework 3.5 on my Windows 10 PC :  Go into RegEdit and set the HKEY_LOCAL_MACHINE\SOFTWARE\Policies\Microsoft\Windows\WindowsUpdate\AU folder.  DoubleClick on UseWUServer(UseWindowsUpdateServer) and change the value to 0.  If the value is already 0 this fix may not work for you.  You may need to restart afterwards.