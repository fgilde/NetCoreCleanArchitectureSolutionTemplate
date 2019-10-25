$currentDir = Get-Location


# ----------------  Copy Template Images
$fileNamesToCopy = @("__TemplateIcon.png","__PreviewImage.png")
$toDelete = New-Object System.Collections.ArrayList
$targetImagePath = Join-Path -Path $currentDir -ChildPath "..\..\"

foreach ($file in $fileNamesToCopy){            
    Copy-Item $targetImagePath$file $currentDir    
    $fullFile = Join-Path -Path $currentDir -ChildPath $file
    $toDelete.Add($fullFile)
}    

Get-ChildItem -Path $currentDir -Directory -Force -ErrorAction SilentlyContinue | ForEach-Object {
        foreach ($file in $fileNamesToCopy){            
            Copy-Item $targetImagePath$file $($_.FullName)
            $toDelete.Add($($_.FullName) + '\' + $file)
        }        
}
# ---------------- End copy template images

$file = Join-Path -Path $currentDir -ChildPath "..\CCA-Template.zip"
if (Test-Path $file) {
  Remove-Item $file
}

#Create Template zip
Add-Type -Assembly "system.io.compression.filesystem"
[io.compression.zipfile]::CreateFromDirectory($currentDir, $file)


#Delete copied files
foreach ($fileToDelete in $toDelete){            
    Remove-Item $fileToDelete      
}      