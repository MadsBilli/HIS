using DataAccess.SQL2008;
using HIS.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIS.Data.Mapper.FabricCode
{
    public class FabricCodeMapper
    {
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_code", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DELETE, ParameterName = "@FC_CODE", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_code { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.GET_FABRICCODE_DETAILS, ParameterName = "@FC_Type", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_type", ParameterType = SqlDbType.Int, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public int fc_type { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_desc", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_desc { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_colour", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_colour { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_unitcost", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_unitcost { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_unitprice", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_unitprice { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_unitprice2", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_unitprice2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_unitprice3", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_unitprice3 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_unitprice4", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_unitprice4 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_instprice", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_instprice { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_instprice2", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_instprice2 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_instprice3", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_instprice3 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_instprice4", ParameterType = SqlDbType.Money, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public decimal fc_instprice4 { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_width", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_width { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_min_width", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_min_width { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_rmk", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_rmk { get; set; }
        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@fc_size", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string fc_size { get; set; }

        [StoredProcedureParameter(StoredProcedureName = StoredProcedureName.FABRIC_CODE_DETAILS_INSERT, ParameterName = "@PK", ParameterType = SqlDbType.VarChar, ParameterDirection = StoredProcedureEnums.StoredProcedureParameterDirection.In)]
        public string primaryKey { get; set; }

        //public string ft_desc { get; set; }
        //public string ft_header { get; set; }
        //public string ft_footer { get; set; }
        //public DateTime ft_eff_date { get; set; }
        //public string ft_rmk { get; set; }
        //public string ft_minimum { get; set; }

    }
}
