using Renci.SshNet;
using System;
using System.IO;

public class SftpUploader
{
    public string UploadAllFilesInDirectory(string host, int port, string username, string password, string localDirectoryPath, string remoteDirectoryPath, string archiveDirectoryPath)
    {
        string result = "";

        if (!Directory.Exists(localDirectoryPath))
        {
            return "Local directory does not exist.";
        }

        if (!Directory.Exists(archiveDirectoryPath))
        {
            Directory.CreateDirectory(archiveDirectoryPath);
        }

        using (var sftp = new SftpClient(host, port, username, password))
        {
            try
            {
                sftp.Connect();

                if (!sftp.Exists(remoteDirectoryPath))
                {
                    sftp.CreateDirectory(remoteDirectoryPath);
                }

                var files = Directory.GetFiles(localDirectoryPath);
                foreach (var filePath in files)
                {
                    string fileName = Path.GetFileName(filePath);
                    string remoteFilePath = remoteDirectoryPath.TrimEnd('/') + "/" + fileName;
                    string archiveFilePath = Path.Combine(archiveDirectoryPath, fileName);

                    using (var fileStream = File.OpenRead(filePath))
                    {
                        sftp.UploadFile(fileStream, remoteFilePath);
                    }

                    // Move to archive
                    File.Copy(filePath, archiveFilePath, true);
                    File.Delete(filePath);

                    result += $"Uploaded and moved to archive: {fileName}\n";
                }

                sftp.Disconnect();
                return result;
            }
            catch (Exception ex)
            {
                return "Error: " + ex.Message;
            }
        }
    }
}
