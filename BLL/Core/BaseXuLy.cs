using BLL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
  public  class BaseXuLy
    {
        public QLCapheDataContext ctx;

        public BaseXuLy()
        {
            ctx = new QLCapheDataContext();
        }
    }
}
