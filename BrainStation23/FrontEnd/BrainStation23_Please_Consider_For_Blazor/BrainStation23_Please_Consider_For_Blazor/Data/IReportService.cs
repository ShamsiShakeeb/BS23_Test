using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrainStation23_Please_Consider_For_Blazor.Data
{
    public interface IReportService
    {
        public Task<List<Posting>> GetInfo();
        public Task<List<Commenting>> GetInfo2();
    }
}
