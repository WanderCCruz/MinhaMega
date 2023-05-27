using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinhaMega.Api
{
    public interface ILoteriaApi<T> where T : class
    {
        Task<T> Concurso(string jogo,int? numeroConcurso);
    }
}
