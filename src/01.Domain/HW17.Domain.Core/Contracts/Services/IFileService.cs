using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW17.Domain.Core.Contracts.Services
{
    public interface IFileService
    {
        public string Upload(IFormFile file, string folder);
        public void Delete(string fileName);
    }
}
