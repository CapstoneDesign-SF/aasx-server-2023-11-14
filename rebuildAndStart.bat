@echo off
powershell.exe ". '.\src\BuildForRelease.ps1' "
TIMEOUT /T 5
cd artefacts\build\Release\AasxServerBlazor
.\startForDemo.bat