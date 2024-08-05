using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery.Shared.Services
{
    public interface IFileService
    {
        string ReadFile(string path);
    }
}
