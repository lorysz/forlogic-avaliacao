using Service.Dto.Home;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Interfaces
{
    public interface IHomeService
    {
        HomeDto GetInformacoes();
    }
}
