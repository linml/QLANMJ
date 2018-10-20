
@echo off

del /f /s /q *.rar

 "C:\Program Files\WinRAR\Rar.exe" a -r S-服务器EXE.rar *.dll

 "C:\Program Files\WinRAR\Rar.exe" a -r S-服务器EXE.rar *.exe

 "C:\Program Files\WinRAR\Rar.exe" a -r S-服务器EXE.rar *.pdb

 ::"C:\Program Files\WinRAR\Rar.exe" a -r S-服务器EXE.rar *.bat


 ::"C:\Program Files\WinRAR\Rar.exe" a -r S-服务器EXE.rar *.xml


 ::"C:\Program Files\WinRAR\Rar.exe" d -r S-服务器EXE.rar Server\plugin
 


