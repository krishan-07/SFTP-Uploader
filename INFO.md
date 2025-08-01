## Project Overview

This project uses the `Renci.SshNet` library to connect to a remote SFTP server and upload files. It's a .NET Framework 4.7.2 class library written in C#.

---

## Use Case

- Securely upload files to a remote server over SFTP
- Archive or back up uploaded files
- Integrate with batch/automated systems via PowerShell or scheduled tasks

---

## How to Use

1. Make sure your project is built (see README.md for build instructions).
2. Reference the compiled `.dll` from your automation script or application.
3. Use PowerShell to invoke it or automate uploads (see below).

---

## Testing Using PowerShell

Here’s a sample PowerShell script to test the `SftpUploader` class after you build it.

### Example PowerShell Script:

```powershell
# Define paths
$projectDir = "C:\Path\To\SftpUploader"
$assemblyPath = "$projectDir\bin\Release\SftpUploader.dll"

# Load the assembly
Add-Type -Path $assemblyPath

# Create an instance of the uploader class
$uploader = New-Object SftpUploader.Uploader

# Define parameters
$host = "your.sftpserver.com"
$port = 22
$username = "your-username"
$password = "your-password"
$localDir = "C:\Local\Files"
$remoteDir = "/upload"
$archiveDir = "C:\Archived\Files"

# Run the upload method
$result = $uploader.UploadAllFilesInDirectory($host, $port, $username, $password, $localDir, $remoteDir, $archiveDir)

# Output result
Write-Host "Upload Result: $result"
