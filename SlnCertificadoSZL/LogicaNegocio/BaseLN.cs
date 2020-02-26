using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructura.Log;



namespace LogicaNegocio
{
    public abstract class BaseLN
    {

        private ILogger _log;
        public ILogger Log
        {
            get
            {
                if (_log == null)
                {
                    _log = LogHelper.GetLogger(this.GetType());
                }
                return _log;
            }
        }
    }
}
