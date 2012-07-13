@ECHO OFF
ECHO Building Debug ...
ECHO MSBuild /P:Configuration=Debug
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild /P:Configuration=Debug
ECHO Building Release ...
ECHO MSBuild /P:Configuration=Release
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild /P:Configuration=Release
ECHO Complete
TIMEOUT 10