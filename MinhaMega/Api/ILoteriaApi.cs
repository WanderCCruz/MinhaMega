using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaMega.Api
{
    public interface ILoteriaApi
    {
        Task<string> Concurso(int? numeroConcurso);
    }
}
