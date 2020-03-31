using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public class AzureStorageService : IFileStorageService
    {
        private readonly string connectionstring;

        public AzureStorageService(IConfiguration config)
        {
            connectionstring = config.GetConnectionString("AzureStorageConnection");
        }
        public Task<string> DeleteFile(string containername, string fileroute)
        {
            throw new NotImplementedException();
        }

        public Task<string> EditFile(byte[] content, string extension, string containername, string fileroute)
        {
            throw new NotImplementedException();
        }

        public Task<string> SaveFile(byte[] content, string extension, string containername)
        {
            throw new NotImplementedException();
        }               
    }
}
