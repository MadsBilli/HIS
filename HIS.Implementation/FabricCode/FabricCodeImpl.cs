using HIS.Common;
using HIS.Data.Mapper.FabricCode;
using HIS.DataAccess.FabricCode;
using HIS.UI.Mapper.FabricCode;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HIS.Implementation.FabricCode
{
    public class FabricCodeImpl
    {
        public List<FabricTypeUIMapper> GetFabricTypeList()
        {
            FabricCodeDA fabricCodeDA = new FabricCodeDA();
            var lsFabricTypeMapper = fabricCodeDA.GetFabricTypes();

            var res = (from fcType in lsFabricTypeMapper
                       select new FabricTypeUIMapper
                       {
                           fc_type = fcType.fc_type,
                           fc_desc = fcType.fc_desc,
                           fc_eff_date = fcType.fc_eff_date,
                           fc_footer = fcType.fc_desc,
                           fc_header = fcType.fc_header,
                           fc_minimum = fcType.fc_minimum,
                           fc_rmk = fcType.fc_rmk,
                       }).ToList();
            return res;

        }

        public FabricTypeUIMapper GetSelectedFabricType(int fcType)
        {
            FabricCodeDA fabricCodeDA = new FabricCodeDA();
            FabricTypeMapper fc = new FabricTypeMapper { fc_type = fcType };
            var lsFabricTypeMapper = fabricCodeDA.GetSelectedFabricType(fc);

            var res = new FabricTypeUIMapper
                       {
                           fc_type = lsFabricTypeMapper.fc_type,
                           fc_desc = lsFabricTypeMapper.fc_desc,
                           fc_eff_date = lsFabricTypeMapper.fc_eff_date,
                           fc_footer = lsFabricTypeMapper.fc_footer,
                           fc_header = lsFabricTypeMapper.fc_header,
                           fc_minimum = lsFabricTypeMapper.fc_minimum,
                           fc_rmk = lsFabricTypeMapper.fc_rmk,
                       };
            return res;

        }

        public List<FabricCodeUIMapper> GetFabricCodeList(int fcType)
        {
            FabricCodeDA fabricCodeDA = new FabricCodeDA();
            FabricCodeMapper fc = new FabricCodeMapper { fc_type = fcType };

            var lsFabricCodeMapper = fabricCodeDA.GetFabricCodeList(fc);

            var res = (from fcCode in lsFabricCodeMapper
                       select new FabricCodeUIMapper
                       {
                           fc_code = fcCode.fc_code,
                           fc_desc = fcCode.fc_desc,
                           fc_colour = fcCode.fc_colour,
                           fc_unitcost = CommonFunctions.FormatDecimal(fcCode.fc_unitcost),
                           fc_unitprice = CommonFunctions.FormatDecimal(fcCode.fc_unitprice),
                           fc_unitprice2 = CommonFunctions.FormatDecimal(fcCode.fc_unitprice2),
                           fc_unitprice3 = CommonFunctions.FormatDecimal(fcCode.fc_unitprice3),
                           fc_unitprice4 = CommonFunctions.FormatDecimal(fcCode.fc_unitprice4),
                           fc_instprice = CommonFunctions.FormatDecimal(fcCode.fc_instprice),
                           fc_instprice2 = CommonFunctions.FormatDecimal(fcCode.fc_instprice2),
                           fc_instprice3 = CommonFunctions.FormatDecimal(fcCode.fc_instprice3),
                           fc_instprice4 = CommonFunctions.FormatDecimal(fcCode.fc_instprice4),
                           fc_min_width = fcCode.fc_min_width,
                           fc_size = fcCode.fc_size,
                           fc_type = fcCode.fc_type,
                           fc_width = fcCode.fc_width,
                           fc_rmk = fcCode.fc_rmk,
                           primaryKey = fcCode.fc_code
                       }).ToList();

            res.Add(new FabricCodeUIMapper
            {
                fc_unitcost = 0.00M,
                fc_unitprice = 0.00M,
                fc_unitprice2 = 0.00M,
                fc_unitprice3 = 0.00M,
                fc_unitprice4 = 0.00M,
                fc_instprice = 0.00M,
                fc_instprice2 = 0.00M,
                fc_instprice3 = 0.00M,
                fc_instprice4 = 0.00M,
            });

            return res;

        }

        public void InsertFabricCodeDetails(FabricCodeUIMapper fabricCode)
        {
            FabricCodeMapper mapper = new FabricCodeMapper
            {
                fc_code = fabricCode.fc_code,
                fc_type = fabricCode.fc_type,
                fc_desc = fabricCode.fc_desc,
                fc_colour = fabricCode.fc_colour,
                fc_unitcost = fabricCode.fc_unitcost,
                fc_unitprice = fabricCode.fc_unitprice,
                fc_unitprice2 = fabricCode.fc_unitprice2,
                fc_unitprice3 = fabricCode.fc_unitprice3,
                fc_unitprice4 = fabricCode.fc_unitprice4,
                fc_instprice = fabricCode.fc_instprice,
                fc_instprice2 = fabricCode.fc_instprice2,
                fc_instprice3 = fabricCode.fc_instprice3,
                fc_instprice4 = fabricCode.fc_instprice4,
                fc_min_width = fabricCode.fc_min_width,
                fc_rmk = fabricCode.fc_rmk,
                fc_size = fabricCode.fc_size,
                fc_width = fabricCode.fc_width,
                primaryKey = fabricCode.primaryKey
            };

            FabricCodeDA fabricCodeDA = new FabricCodeDA();
            fabricCodeDA.InsertFabricCodeDetails(mapper);
        }

        public void DeleteFabricCode(string keyField)
        {
            FabricCodeDA fabricCodeDA = new FabricCodeDA();
            FabricCodeMapper fc = new FabricCodeMapper { fc_code = keyField };
            fabricCodeDA.DeleteFabricCode(fc);
        }

        public void UpdateFabricTypeDetails(FabricTypeUIMapper fabrictype)
        {
            FabricCodeDA fabricCodeDA = new FabricCodeDA();

            var mapper = new FabricTypeMapper
            {
                fc_type = fabrictype.fc_type,
                fc_desc = fabrictype.fc_desc,
                fc_eff_date = fabrictype.fc_eff_date,
                fc_footer = fabrictype.fc_footer,
                fc_header = fabrictype.fc_header,
                fc_minimum = fabrictype.fc_minimum,
                fc_rmk = fabrictype.fc_rmk,
            };
            fabricCodeDA.UpdateFabricTypeDetails(mapper);
        }
    }
}
