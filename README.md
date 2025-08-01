# Project Setup: .NET Application

Follow these steps to set up and build the .NET project on your local machine.

---

## Prerequisites

Ensure the following tools are installed on your system:

- [NuGet CLI](https://learn.microsoft.com/nuget/install-nuget-client-tools) (for package restore)
- [MSBuild](https://learn.microsoft.com/visualstudio/msbuild/msbuild) (comes with Visual Studio or [Build Tools for Visual Studio](https://visualstudio.microsoft.com/downloads/#build-tools-for-visual-studio))
- (Optional) [Visual Studio](https://visualstudio.microsoft.com/) or any IDE of your choice

---

## Installation

### 1. Clone the Repository

```bash
git clone https://github.com/krishan-07/SFTP-Uploader.git <your-directory-name>
```

### 2. Navigate to the Project Directory

```bash
cd your-directory-name/src/Uploader

```

### 3. Build the Project

```bash
msbuild SftpUploader.csproj /p:Configuration=Release
```

If msbuild is not recognized, ensure it's in your PATH. A typical path might be:

```bash
C:\Program Files\Microsoft Visual Studio\2022\BuildTools\MSBuild\Current\Bin\MSBuild.exe
```
