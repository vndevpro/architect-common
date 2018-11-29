using System;
using System.IO;

namespace GdNet.Common.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class SimpleFileService : IFileService
    {
        private readonly string _rootFolder;

        /// <summary>
        /// Create the service to work with a root folder
        /// </summary>
        /// <param name="rootFolder"></param>
        public SimpleFileService(string rootFolder)
        {
            _rootFolder = rootFolder;
        }

        /// <summary>
        /// Save string into a file
        /// </summary>
        public OperationResult SaveFile(string virtualFilePath, string body)
        {
            try
            {
                var filePath = Path.Combine(_rootFolder, virtualFilePath);

                File.WriteAllText(filePath, body);

                return new OperationResult(true);
            }
            catch (Exception ex)
            {
                return new OperationResult(false)
                {
                    Message = ex.Message
                };
            }
        }

        /// <summary>
        /// Read all text from given file
        /// </summary>
        public OperationResult GetFile(string virtualFilePath)
        {
            var filePath = Path.Combine(_rootFolder, virtualFilePath);

            if (File.Exists(filePath))
            {
                return new OperationResult(true)
                {
                    Data = File.ReadAllText(filePath),
                };
            }

            return new OperationResult(false)
            {
                Message = "File does not exist"
            };
        }
    }
}