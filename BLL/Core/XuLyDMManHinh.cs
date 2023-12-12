using BLL.DB;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Core
{
    public class XuLyDMManHinh : BaseXuLy
    {
        public List<DM_ManHinh> LayTatCa()
        {
            try
            {
                List<DM_ManHinh> result = ctx.DM_ManHinhs.ToList();
                return result;
            }
            catch { return null; }
        }
        public List<ManHinh> layDMManHinh(string maquyen)
        {
            try
            {
                var table = from quyenMMH in ctx.Quyen_ManHinhs
                            join dmMH in ctx.DM_ManHinhs on quyenMMH.MaDM equals dmMH.MaDM
                            where quyenMMH.MaQuyen.Trim().Equals(maquyen.Trim())
                            select new ManHinh { maDM = dmMH.MaDM, tenDM = dmMH.TenDM };
                string json = JsonConvert.SerializeObject(table);
                List<ManHinh> result = JsonConvert.DeserializeObject<List<ManHinh>>(json);
                return result;
            }
            catch { return null; }

        }
    }
}
