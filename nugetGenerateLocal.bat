echo off
echo ^<?xml version="1.0" encoding="utf-8"?^> > %2
echo ^<configuration^> >> %2
echo   ^<packageSources^> >> %2
echo     ^<add key="nuget.org" value="https://www.nuget.org/api/v2/" /^> >> %2
echo     ^<add key="localFeed" value="%1" /^> >> %2
echo   ^</packageSources^> >> %2
echo ^</configuration^> >> %2