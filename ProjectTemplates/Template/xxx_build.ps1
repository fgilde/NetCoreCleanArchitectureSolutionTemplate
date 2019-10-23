$currentDir = Get-Location
$file = Join-Path -Path $currentDir -ChildPath "..\CCA-Template.zip"
if (Test-Path $file) {
  Remove-Item $file
}

Add-Type -Assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($currentDir, $file)