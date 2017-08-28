using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common;
using GameServer.Servers;

namespace GameServer.Controller
{
    abstract class BaseController
    {
        RequestCode requestCode = RequestCode.None;

        public RequestCode Requestcode
        {
            get { return requestCode; }
        }

        public virtual string DefaultHandle(string data,Client client,Server server) { return null; }

    }
}
