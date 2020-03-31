using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieAPI.Services
{
    public interface IFileStorageService
    {
        Task<string> EditFile(byte[] content, string extension, string containername, string fileroute);
        Task<string> DeleteFile(string containername, string fileroute);
        Task<string> SaveFile(byte[] content, string extension, string containername);
    }
}
