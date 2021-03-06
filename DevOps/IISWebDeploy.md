eğer web deploy 3.6 kurulmya çalılıldığında üst versiyon kurulu diyorsa ya da kurulu olduğu görüldüğü halde IIS de Managemet Delegation serice görünmüyorsa, sistemde VS kurulu olabilir bu durumda IIS modulu olmayan web deploeyment 4 versiyonu kurulmuş olabilir.

### __herşey doğru yapılduğı halde nonadmin giriş yapamaıyorsa__

https://blogs.technet.microsoft.com/leesab/2014/08/13/how-to-use-web-deploy-for-administration-of-application-pools-by-non-administrators/

şu komutu çalıştırmayı unutma





Set Permissions required for WMSVC to use the __runCommand, recycleApp__

WMSVC by default runs with basic authentication, to change this to use NTLM we need to create the following registry key. (As always back up your registry before making changes).

From a command prompt type regedit.

Navigate to HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\WebManagement\Server
Right click on Server and select new DWORD 32bit. For Value Name enter __WindowsAuthenticationEnabled set the Value data to 1__. Close regedit.

More information on this entry can be found here 

To allow the WMSVC the right to use the runCommand functionality we need to grant it the right to  __replace a Process level token__. Note: you can try granting this right through the local security policy but I could not get this to work, so I used SC Privs wmsvc  command.
From a command prompt type __sc privs wmsvc SeChangeNotifyPrivilege/SeImpersonatePrivilege/SeAssignPrimaryTokenPrivilege__
__Run  sc qprivs wmsvc to make sure SeAssignPrimaryTokenPrivilege has been added to existing privileges__. More information on this can be found [here](https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/ee619740(v=ws.10)). runCommand provider ile aynı ayarı recycleApp için de yapmak gerekiyor yani.

Recycle WMSVC with the following commands at a command prompt

- net stop wmsvc
- net start wmsvc

Let’s test our configuration!  Log in with an account that is allowed to log in locally but is not an administrator and is part of contoso\app admins.

Open a command prompt and issue the following command cd “c: \Program Files\IIS\Microsoft Web Deploy V3” This will put us in the directory for msdeploy.

First let get a list of application pools using the run Command. My Web application is called SharePoint – 80 so the command looks like below:

msdeploy.exe -verb:sync -source:runcommand -dest:runcommand="C:\Windows\System32\inetsrv\appcmd.exe list apppool",wmsvc="http://sp2010:8172/msdeploy.axd?site=SharePoint - 80",AuthType=NTLM –allowUntrusted












### __Uygun Opsiyonu seçmek__

__Choosing the Right Approach to Web Deployment__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/choosing-the-right-approach-to-web-deployment



When you work with the Internet Information Services (IIS) Web Deployment Tool (Web Deploy) 2.0 or later, there are three main approaches you can use to get your packaged web applications onto a web server. You can either:

- Deploy the application from a remote location by targeting the Web Deployment Agent Service (also known as the "remote agent") on the destination server.
- Deploy the application from a remote location using Web Deploy On Demand (also known as the "temp agent").
- Deploy the application from a remote location by targeting the IIS Web Deploy Handler on the destination server.
- Deploy the application by manually copying the web package to the destination server and importing it through IIS Manager.
- How you configure your destination web servers will depend on which approach to deployment you want to use. This topic will help you decide which approach to deployment is right for you.


This table shows the main advantages and disadvantages of each deployment approach, together with the scenarios that most typically suit each approach.




|Approach|Advantages|Disadvantages|Typical Scenarios|
|--------|----------|-------------|-----------------|
|Remote Agent|It is easy to set up. It is suitable for regular updates to web applications and content.|The user must be an administrator on the target server. the user can't supply alternative credentials.|Development environments. Test environments.|
|Temp Agent|There is no need to install Web Deploy on the target computer. The latest version of Web Deploy is automatically used.|The user must be an administrator on the target server. The user can't supply alternative credentials.|Development environments. Test environments.|
|Web Deploy Handler|Non-administrator users can deploy content. It is suitable for regular updates to web applications and content.|It is a lot more complex to set up.|Staging environments. Intranet production environments. Hosted environments.|
|Offline Deployment|It is very easy to set up. It is suitable for isolated environments.|The server administrator must manually copy and import the web package every time.|Internet-facing production environments. Isolated network environments.|



### __Detaylı Kurulum Anlatım__

https://blogs.technet.microsoft.com/leesab/2014/08/13/how-to-use-web-deploy-for-administration-of-application-pools-by-non-administrators/

### __Web Deploy Providers__


https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/dd569040(v=ws.10)

### __Web Deploy runCommand Provider__

https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/ee619740(v=ws.10)




__Operations on application pools as admin and non-admin__

https://blogs.iis.net/msdeploy/operations-on-application-pools-as-admin-and-non-admin



### __Configuring a Web Server for Web Deploy Publishing (Web Deploy Handler)__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-web-deploy-handler


### __Configuring Deployment Properties for a Target Environment__


https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/configuring-deployment-properties-for-a-target-environment






### __web deployment esnasında  siteyi kapatma__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/advanced-enterprise-web-deployment/taking-web-applications-offline-with-web-deploy

### __msbuild ile powershell çalıştırma__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/advanced-enterprise-web-deployment/running-windows-powershell-scripts-from-msbuild-project-files

### __Scenario: Configuring a Test Environment for Web Deployment__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/scenario-configuring-a-test-environment-for-web-deployment

### __Scenario: Configuring a Staging Environment for Web Deployment__


https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/scenario-configuring-a-staging-environment-for-web-deployment


### __Scenario: Configuring a Production Environment for Web Deployment__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/scenario-configuring-a-production-environment-for-web-deployment

### __Configuring a Web Server for Web Deploy Publishing (Remote Agent)__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-remote-agent


### __Configure the Web Deployment Handler__

https://docs.microsoft.com/en-us/iis/publish/using-web-deploy/configure-the-web-deployment-handler

### __Configuring a Web Server for Web Deploy Publishing (Web Deploy Handler)__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-web-deploy-handler


### __Configuring a Web Server for Web Deploy Publishing (Offline Deployment)__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/configuring-a-web-server-for-web-deploy-publishing-offline-deployment


### __Creating a Server Farm with the Web Farm Framework__

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/configuring-server-environments-for-web-deployment/creating-a-server-farm-with-the-web-farm-framework



### __Web Deoplay PowerShell Cmdlets__

https://docs.microsoft.com/en-us/iis/publish/using-web-deploy/web-deploy-powershell-cmdlets





### Asp.Net Web Form Deployment

https://docs.microsoft.com/en-us/aspnet/web-forms/overview/deployment/


https://github.com/aspnet/websdk

https://docs.microsoft.com/en-us/aspnet/core/host-and-deploy/visual-studio-publish-profiles?view=aspnetcore-2.2

https://gist.github.com/nul800sebastiaan/5866613


https://mattmillican.com/blog/build-deploy-aspnetcore-bamboo

https://www.codeproject.com/Articles/1184858/Deploying-a-Web-App-from-a-Command-Line-using-MSBu

https://root-project.org/2011/10/13/work/dotnet/automated-web-deployment-with-msbuild-and-msdeploy/

http://enehana.nohea.com/general/continuous-deployment-for-asp-net-using-git-msbuild-msdeploy-and-teamcity/

https://blog.codeinside.eu/2010/11/21/howto-msdeploy-msbuild/


### bamboo example

http://www.22bugs.co/post/ms-web-deploy-with-bamboo/


### __msdeploy komutlar__



__Web Deploy Link Extensions__

Link extensions include data that would not normally be included by a provider in a Web Deploy operation. Link extensions and providers work together to create a view of a Web server that can be dumped, archived, or synchronized. Link extensions are executed for all Web Deploy verbs, including dump operations.

örneğin

You can use the -enableLink  and -disableLink  settings to enable or disable a Web Deploy link extension. For example, if you specify -disableLink:ContentExtension on the command line, you can prevent content from being included in a sync operation. This enables you to synchronize two Web servers without moving any content.


- web deploy quick lookup

https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/dd569103(v=ws.10)


- yeni başlayanlar için temel msdeploy komutları

https://blogs.iis.net/timamm/web-deploy-quot-starter-quot-commands-for-common-scenarios


- Enabling metaKey="siteName" Syntax  (IIS 6 ve oncesinde geçerli)

https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/ff968984(v=ws.10)

|IIS Version|Web site|Web server|
|-----------|--------|----------|
|IIS 6.0|metaKey=/lm/w3svc/1|webServer60|
|IIS 7|appHostConfig="Default Web Site"|webServer|

- msdeploy operations

https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/dd568989(v=ws.10)

delete, sync, dump

- msdeploy (web deploy) operation settings 

https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/dd569089%28v%3dws.10%29


- msdeploy (web deploy) rules

https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/dd568992%28v%3dws.10%29






- apppool u stop etmek için

.\msdeploy.exe -verb:sync -source:recycleApp -dest:recycleApp="sitename",recycleMode="StopAppPool",computerName="https://servername:8172/msdeploy.axd",authType="Basic",userName="servername\username",password="password" -allowUntrusted


- apppool start etmek için

.\msdeploy.exe -verb:sync -source:recycleApp -dest:recycleApp="sitename",recycleMode="StartAppPool",computerName="https://servername:8172/msdeploy.axd",authType="Basic",userName="servername\username",password="password" -allowUntrusted



- deploy ornek

msdeploy.exe
-source:package='C:\SomeWebProject\obj\Release\Package\SomeWebProject.zip'
-dest:auto,ComputerName='https://TargetServer:8172/MsDeploy.axd?site=TargetWebSite',UserName='Username',Password='Password',IncludeAcls='False',AuthType='Basic'
-verb:sync
-disableLink:AppPoolExtension
-disableLink:ContentExtension
-disableLink:CertificateExtension
-allowUntrusted
-retryAttempts=2
-setParam:'IIS Web Application Name'='TargetWebSite/TargetWebApp'


- klasoru ziplemek için

msdeploy.exe -verb:sync -source:contentPath="d:\myProject" -dest:package="c:\myZipFile.zip"


- uygulamayı publish oncesi offline a çekmek

msdeploy.exe -verb:sync -source:iisApp=mySite -dest:auto,computername=<publishUrl> -enableRule:AppOffline
  
- uygulama yayına alınırken hata olursa
 
 If an error occurred during publishing, the htm file will remain in the site root to keep it offline because it is now in an unknown state. After fixing your publishing issue, you will need to bring the application back online. To do this, you can either manually delete the App_Offline.htm file from your application root on the server, or republish your site. Here is an example of how to delete the App_Offline.htm file from the command line:
 
 msdeploy.exe -verb:delete -dest:contentPath=siteName/App_Offline.htm,computername=<publishUrl>
  
- Halihazırda çalışan web siteyi backup restore yapmak

msdeploy.exe -verb:sync -source:apphostconfig="Default Web Site" -dest:package=c:\dws.zip > DWSpackage7.log

msdeploy.exe -verb:sync -source:package=c:\dws.zip -dest:apphostconfig="Default Web Site" > DWSpackage7.log


_ paketleri kullanarak senkronize etmek

https://docs.microsoft.com/en-us/previous-versions/windows/it-pro/windows-server-2008-R2-and-2008/ff800880(v=ws.10)

- zip dosyasından deploy etmek

echo bolümü işin toplam bitiş zamanını görmek için eklendi

echo %time%	
"C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -source:package="C:\publish\publish.zip" -dest:contentpath="C:\inetpub\testsite",computerName="https://domainname:8172/msdeploy.axd",authType="Basic",userName="servername\username",password="password" -allowUntrusted -disableLink:AppPoolExtension -disableLink:ContentExtension -disableLink:CertificateExtension
echo %time%


echo bolümü işin toplam bitiş zamanını görmek için eklendi

echo %time%	
"C:\Program Files\IIS\Microsoft Web Deploy V3\msdeploy.exe" -verb:sync -source:contentpath="C:\publish\publish3" -dest:contentpath="C:\inetpub\testsite",computerName="https://domainname:8172/msdeploy.axd",authType="Basic",userName="servername\username",password="password"  -allowUntrusted -disableLink:AppPoolExtension -disableLink:ContentExtension -disableLink:CertificateExtension
echo %time%




### __msbuild komutlar__

- dotnet msbuild zip file

dotnet publish -c release /p:WebPublishMethod=Package /p:PackageFileName="c:\publish\package.zip" /p:DesktopBuildPackageLocation="c:\publish\package.zip" /p:PackageAsSingleFile=true /p:DeployTarget=Package /p:PackageLocation="c:\publish\package.zip"



### __Örnek Bazı Komutlar__


Example usages
1) Synchronize the contents of the default Web site to a package file.

msdeploy.exe -verb:sync -source:contentPath="Default Web Site" -dest:package=c:\DWS.zip

2) Return the paths of the files in a package file.

msdeploy.exe -verb:dump -source:package=c:\DWS.zip

3) Return, in XML format, the paths and attributes of the files in a package file.

msdeploy.exe -verb:dump -source:package=c:\DWS.zip -xml

4) Synchronize the output of the appHostConfig provider for the default Web site to a package file.

msdeploy.exe -verb:sync -source:appHostConfig="Default Web Site" -dest:package=c:\DWS.zip

5) Synchronize the contents of a package file to the site lm/wm3svc/2.

msdeploy.exe -verb:sync -source:package=c:\Site1.zip -dest:metaKey=lm/w3svc/2

6) Set the "defaultpage" parameter to the value "MyDefaultWebPage.htm" and synchronize the ParameterPackage.zip file to its destination.

msdeploy -verb:sync -source:package=ParameterPackage.zip -dest:auto -setParam:name=defaultpage,value=MyDefaultWebPage.htm

7) Unpackage the contents of the Package.zip file and put them in the C:\temp folder. Do not delete other files that already exist in the destination folder.

msdeploy.exe -verb:sync -source:package=C:\package.zip -dest:contentpath=C:\temp -enableRule:DoNotDeleteRule

8) Unpackage the contents of the Package.zip file and put them in the C:\temp folder. Remove any files in the destination folder that are not present in the package.

msdeploy.exe -verb:sync -source:package=C:\package.zip -dest:contentpath=C:\temp


### __Toplu İşlemler__

https://github.com/aspnet/websdk#microsoftnetsdkpublish

http://blog.chudinov.net/how-to-build-and-deploy-web-deployment-package-using-msbuild/

https://blog.greatrexpectations.com/2013/02/02/publish-an-azure-web-site-from-the-command-line

https://forums.iis.net/t/1228804.aspx?MSBuild+and+Publish+Profile


__buna bakmalısın__

https://stackoverflow.com/questions/48484457/extracting-msdeploy-zip-package-using-variables






