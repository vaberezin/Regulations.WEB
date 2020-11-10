using System;
using System.Collections.Generic;
using System.Text;
using Regulations.BLL.DTO;


namespace Regulations.BLL.Interfaces
{
    public interface IRegulationService
    {
        IEnumerable<RegulationDTO> GetRegulations();
        RegulationDTO GetRegulation(int? id);
        void Dispose();
    }
}
