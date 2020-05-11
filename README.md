# GCH17223

1.	Download  SQL Server 2019 R2 Express Edition with Advanced Services (64 bit) from the following URL: https://go.microsoft.com/fwlink/?linkid=866658 once the download is complete, continue with the Step-by-Step Installation section below.

2.	Double click the SQL2019-SSEI-Expr.exe file. When prompted to Choose Directory for Extracted Files, click OK to use the default directory, or click Browse...and select a different directory

3.	Click New SQL Server stand-alone installation or add features to an existing installation.

4.	Select I accept the license terms checkbox to accept the license terms, and click next.
5.	Select the features to install. We are going to choose our features manually in the Feature Selection window
6.	Choose the following features to install:
Instance Features:
o	Database Engine Services
o	Reporting Services – Native

Note: 	It is highly recommend not to choose all the features on a production server if you don't need them. Choose only the features listed above. You can also specify a custom directory for Instance directory and shared components by using the field at the bottom of the Feature Selection page. To change the installation path, either update the path in the field at the bottom of the window, or click Browse to move to 

 

7.	By default, SQL Server uses the system operation disk. Thus it is highly recommended to use the best practice according to your specific system and usage. Separating the log files from the data files can improve performance significantly.The system database tempDB is used extensively by the SQL Server. This database is rebuilt each time the server restarts. It is highly recommended to use a fast disk for this database. It is best practice to separate data, transaction logs, and tempDB for environments where you can guarantee that separation.  There are important points to consider and this document does not cover them all. For small systems you can use the default configuration and later on change as needed. Click Next to continue to the Reporting Service Configuration window.
 
8.	Choose Install and configure and then click Next The installation now starts. The Installation Progress window is displayed, listing the components being configured and indicating the installation progress

 
9.	That is all. Considering everything went well, you should get a final report which indicates the successful completion of each installed service. You may be asked to restart your computer. Click OK and restart the computer. If no restart is required, click Close to close the Setup Wizard.
 

10.	Close the SQL Server Installation Center.

11.	Open application folder and navigate to Database, double click on BSMSscript.sql

 


12.	Once Microsoft SQL Management Studio is open as shown in the above referenced figure, click on the execute or press F5 key from the keyboard, Note : run shut cut key might varies from pc producer and version of OS


	Visual Studio 2019
1.	First of all download Visual Studio Enterprise/community 2019. If you have DreamSpark, BizSpark or MSDN account, you can download it from there. Here, I’ve downloaded it from my MSDN account. After login in your account, you can find all software in subscriber download section and choose any version of visual studio from here.

 


2.	Click on any version of visual studio, and then you will see below section in a new page. 

 


3.	Go to the destination folder and open the folder.


4.	Start Installation Process



Then the installation process will start. It’ll take some time based on your computer configuration. High configuration PCs take average one and a half or, two hour.



5.	Restarting Your Computer

After completing the installation process, you will see an option to restart your computer to complete the installation process. 

Hit the “Restart Now” button. It’ll restart your computer. After some moment your installation process will be done.


6.	Launching Visual Studio  2019

Now launch Visual Studio  2019 from the installed software list 


7.	Sign in with your Microsoft account, you can do so or just click “Not now, may be later”.

              

8.	Now Your Visual Studio  2019 is ready to use. 

9.	Activating Visual Studio


10.	Get Ready to Use Visual Studio

Now you are ready to run BSMS on your local computer, alternative you could install IIS server and host application on this server without installing visual studio

11.	Open BSMS Application Directory .

 

15.	 Double Click on BSMS to open the source code of this project then click on the start button from the top-most part of the IDE.
Note: you might be required to change database server name in web.config of bsms.service to match your own server name
