using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public static class ServicesAuditoria
    {
        public static TRACKAuditoria.reg reg_;
        public static TRACKAuditoria.reg audit()
        {
            if (reg_ == null)
            {
                reg_ = new TRACKAuditoria.reg();
            }
            return reg_;
        }
    }
}
