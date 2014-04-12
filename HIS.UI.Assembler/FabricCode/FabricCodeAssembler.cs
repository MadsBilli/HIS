using HIS.Implementation.FabricCode;
using HIS.UI.Mapper.FabricCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.UI.Assembler
{
    public class FabricCodeAssembler
    {
        public List<FabricTypeUIMapper> GetFabricTypeList()
        {
            FabricCodeImpl fabricCodeImpl = new FabricCodeImpl();
            return fabricCodeImpl.GetFabricTypeList();
        }

        public FabricTypeUIMapper GetSelectedFabricType(int fcType)
        {
            FabricCodeImpl fabricCodeImpl = new FabricCodeImpl();
            return fabricCodeImpl.GetSelectedFabricType(fcType);
        }

        public List<FabricCodeUIMapper> GetFabricCodesList(int fcType)
        {
            FabricCodeImpl fabricCodeImpl = new FabricCodeImpl();
            return fabricCodeImpl.GetFabricCodeList(fcType);
        }

        public void InsertFabricCodeDetails(FabricCodeUIMapper fabricCode)
        {
            FabricCodeImpl fabricCodeImpl = new FabricCodeImpl();
            fabricCodeImpl.InsertFabricCodeDetails(fabricCode);
        }

        public void DeleteFabricCode(string keyField)
        {
            FabricCodeImpl fabricCodeImpl = new FabricCodeImpl();
            fabricCodeImpl.DeleteFabricCode(keyField);
        }

        public void UpdateFabricTypeDetails(FabricTypeUIMapper fabrictype)
        {
            FabricCodeImpl fabricCodeImpl = new FabricCodeImpl();
            fabricCodeImpl.UpdateFabricTypeDetails(fabrictype);
        }
    }
}
