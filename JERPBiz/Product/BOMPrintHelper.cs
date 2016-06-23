using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
namespace JERPBiz.Product
{
    public class BOMPrintHelper
    {
        public BOMPrintHelper()
        {
            this.TmpFileName = JERPData.ServerParameter.TempletFolder + "BOM.xlt";
            this.PrdEntity = new ProductEntity();
            this.accPackingType = new JERPData.Product.PackingType();
            this.accPackingTypeBom = new JERPData.Product.PackingBOM();
            this.accBOM = new JERPData.Product.BOM();
            this.accManufProcess = new JERPData.Manufacture.ManufProcess();
            this.accParms = new JERPData.Product.ParmValues();
            this.PackingTypeEntity = new PackingTypeEntity();
        }
        private string TmpFileName = string.Empty;
        private ProductEntity PrdEntity;
        private JERPData.Product.ParmValues accParms;
        private JERPData.Manufacture.ManufProcess accManufProcess;
        private JERPData.Product.PackingType accPackingType;
        private JERPData.Product.PackingBOM accPackingTypeBom;
        private JERPBiz.Product.PackingTypeEntity PackingTypeEntity;
        private JERPData.Product.BOM accBOM;
        private void BasicToExcel(Office2003Helper.Excel2003 excel,int SheetIndex)
        {
            excel.SetCurSheet(SheetIndex);
            excel.SetCellVal("A1", this.PrdEntity.PrdCode + "  " + this.PrdEntity.PrdName);
            excel.SetCellVal("B2", this.PrdEntity.PrdCode );
            excel.SetCellVal("D2", this.PrdEntity.PrdName );
            excel.SetCellVal("G2", this.PrdEntity.PrdSpec );

            excel.SetCellVal("B3", this.PrdEntity.PrdTypeName );
            excel.SetCellVal("D3", this.PrdEntity.UnitName );
            string SaleInfor=(this.PrdEntity .SaleFlag )?"是":"否";
            if (this.PrdEntity.SaleFlag)
            {
                excel.SetCellVal("F3", SaleInfor);
            }
         
            excel.SetCellVal("B4", this.PrdEntity.Model );
            if (this.PrdEntity.PrdWeight > 0)
            {
                excel.SetCellVal("D4", this.PrdEntity.PrdWeight);
            }
          
            excel.SetCellVal("B7", this.PrdEntity.VersionRecord);
            excel.SetCellVal("F7", this.PrdEntity.DateRegister.ToShortDateString());
            excel.SetCellVal("H8", this.PrdEntity.FileCode);
            excel.SetCellVal("G10", this.PrdEntity.RegisterPsn);
            excel.SetCellVal("H11", this.PrdEntity.VersionCode);
            
            //开始玩技术参数
            int rowIndex = 6;
            DataTable dtblParms = this.accParms.GetDataParmValuesByPrdID(this.PrdEntity.PrdID).Tables[0];
            if (dtblParms.Rows.Count > 1)
            {
                excel.InsertRows(rowIndex, rowIndex, dtblParms.Rows.Count - 1);
            }
            foreach (DataRow drow in dtblParms.Rows)
            {
                excel.SetCellVal("A" + rowIndex.ToString(), drow["ParmTypeName"].ToString());
                excel.SetCellVal("B" + rowIndex.ToString(), drow["ParmValue"].ToString());
                rowIndex++;
            }
           
            

        }
        private void BomToExcel(Office2003Helper.Excel2003 excel,int SheetIndex)
        {
            excel.SetCurSheet(SheetIndex);
            excel.SetCellVal("A1", this.PrdEntity.PrdCode + "  " + this.PrdEntity.PrdName);
            DataTable dtblBOM = this.accBOM.GetDataBOMTreeByPrdID(this.PrdEntity.PrdID, "   ", "").Tables[0];
            int rowIndex =4;
            if (dtblBOM.Rows.Count > 1)
            {
                excel.InsertRows(rowIndex, rowIndex, dtblBOM.Rows.Count - 1);
            }           
            foreach(DataRow drow in dtblBOM .Rows )
            {               
                excel.SetCellVal("A" + rowIndex.ToString(), drow["PrdStatus"]);
                excel.SetCellVal("B" + rowIndex.ToString(), drow["Prefix"]);
                excel.SetCellVal("C" + rowIndex.ToString(), drow["PrdName"]);
                excel.SetCellVal("D" + rowIndex.ToString(), drow["PrdSpec"]);
                excel.SetCellVal("E" + rowIndex.ToString(), drow["Model"]);
                excel.SetCellVal("F" + rowIndex.ToString(), drow["Manufacturer"]);
                excel.SetCellVal("G" + rowIndex.ToString(), drow["AssemblyQty"]);
                excel.SetCellVal("H" + rowIndex.ToString(), drow["LossRate"]);
                excel.SetCellVal("I" + rowIndex.ToString(), drow["UnitName"]);
                excel.SetCellVal("J" + rowIndex.ToString(), drow["SourceTypeName"]);
                excel.SetCellVal("K" + rowIndex.ToString(), drow["Element"]);
                excel.SetCellVal("L" + rowIndex.ToString(), drow["Substitute"]); 
                excel.SetCellVal("M" + rowIndex.ToString(), drow["PostProcessing"]);
                excel.SetCellVal("N" + rowIndex.ToString(), drow["Memo"]);
                rowIndex++;
            }
        }
        private void ProcessToExcel(Office2003Helper.Excel2003 excel,int SheetIndex)
        {

            excel.SetCurSheet(SheetIndex);
            excel.SetCellVal("A1", this.PrdEntity.PrdCode + "  " + this.PrdEntity.PrdName);
            DataTable dtblProcess = this.accManufProcess.GetDataManufProcessByPrdID(this.PrdEntity.PrdID).Tables[0];
            int rowIndex = 4;
            if (dtblProcess.Rows.Count > 1)
            {
                excel.InsertRows(rowIndex, rowIndex, dtblProcess.Rows.Count - 1);
            }
            foreach (DataRow drow in dtblProcess.Rows)
            {
                excel.SetCellVal("A" + rowIndex.ToString(), drow["PrdStatus"]);
                excel.SetCellVal("B" + rowIndex.ToString(), drow["Memo"]);
                excel.SetCellVal("C" + rowIndex.ToString(), drow["OutSrcSupplier"]);             
                rowIndex++;
            }
        
        }
        private void PackingToExcel(Office2003Helper.Excel2003 excel, int SheetIndex,int PackingTypeID)
        {
            excel.SetCurSheet(SheetIndex);
            excel.SetCellVal("A1", this.PrdEntity.PrdCode + "  " + this.PrdEntity.PrdName);
            this.PackingTypeEntity.LoadData(PackingTypeID);
            excel.SetCurSheetName(this.PackingTypeEntity.PackingTypeName);
            excel.SetCellVal("B2", this.PackingTypeEntity.PackingTypeName);
            excel.SetCellVal("A7", this.PackingTypeEntity.Description);
            DataTable dtblBOM = this.accPackingTypeBom.GetDataPackingBOMByPackingTypeID (PackingTypeID).Tables[0];
            int rowIndex = 5;
            if (dtblBOM.Rows.Count > 1)
            {
                excel.InsertRows(rowIndex, rowIndex, dtblBOM.Rows.Count - 1);
            }
            string RecycleInfor = "是";
            foreach (DataRow drow in dtblBOM.Rows)
            {
                excel.SetCellVal("A" + rowIndex.ToString(), drow["PrdCode"]);
                excel.SetCellVal("B" + rowIndex.ToString(), drow["PrdName"]);
                excel.SetCellVal("C" + rowIndex.ToString(), drow["PrdSpec"]);
                excel.SetCellVal("D" + rowIndex.ToString(), drow["Model"]);
                excel.SetCellVal("E" + rowIndex.ToString(), drow["PrdAssembly"]);
                excel.SetCellVal("F" + rowIndex.ToString(), drow["PackageAssembly"]);
                excel.SetCellVal("G" + rowIndex.ToString(), drow["UnitName"]);
                excel.SetCellVal("H" + rowIndex.ToString(), drow["SourceTypeName"]);
                RecycleInfor =((bool)drow["RecycleFlag"])?"是":"否";
                excel.SetCellVal("I" + rowIndex.ToString(), RecycleInfor);
                excel.SetCellVal("J" + rowIndex.ToString(), drow["Position"]);
                excel.SetCellVal("K" + rowIndex.ToString(), drow["Memo"]);
                rowIndex++;
            }
        }
        public void ExportToExcel(int PrdID)
        {
         
            Office2003Helper.Excel2003 excel = new Office2003Helper.Excel2003();
            excel.NewFromTemp(this.TmpFileName);
            this.PrdEntity.LoadData(PrdID);
            this.BasicToExcel(excel,1);
            this.BomToExcel (excel, 2);
            this.ProcessToExcel(excel,3);
            DataTable dtblPackingTypes = this.accPackingType.GetDataPackingTypeByPrdID(PrdID).Tables[0];
            if (dtblPackingTypes.Rows.Count > 1)
            {
                excel.NewSheetByCopy(4, dtblPackingTypes.Rows.Count - 1);
            }
            for (int i = 0; i < dtblPackingTypes.Rows.Count; i++)
            {
                this.PackingToExcel(excel, 4 + i, (int)dtblPackingTypes.Rows[i]["PackingTypeID"]);

            }
            excel.SetCurSheet(1);
            excel.Show();           
            
        }

    }
}
