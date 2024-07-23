Set-Location $PSScriptRoot
Set-Location ..
dotnet publish -c Release -r win-x64 --self-contained
# create zip file PartialScreensharerApp.zip for folder \PartialScreensharerApp\bin\Release\net8.0-windows\win-x64
Compress-Archive -Path .\PartialScreensharerApp\bin\Release\net8.0-windows\win-x64\* -DestinationPath .\PartialScreensharerApp\bin\Release\net8.0-windows\win-x64\PartialScreensharerApp.zip