using Model.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Point.Handler
{
    public interface IPointCreatorHandler
    {
        Task<IServiceWrapper<IPoint>> SendPointToThirdParty(IPoint Point);
    }
}
