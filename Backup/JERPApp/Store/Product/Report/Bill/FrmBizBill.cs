using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Store.Product.Report.Bill
{
    public class FrmBizBill:Form 
    {
       public virtual void DetailNote(long NoteID)
       {
       }        
     
       public static FrmBizBill Create(int NoteNameID)
       {
           switch (NoteNameID)
           {
             
               case JERPBiz.Finance.NoteNameParm.PrdStoreCheckNoteNameID: return new FrmStoreCheckNote();
               case JERPBiz.Finance.NoteNameParm.PrdSaleDeliverNoteNameID: return new FrmSaleDeliverNote();
               case JERPBiz.Finance.NoteNameParm.PrdSaleReturnNoteNameID: return new FrmSaleReturnNote();
               case JERPBiz.Finance.NoteNameParm.PrdIntoStoreNoteNameID: return new FrmIntoStoreNote();
               case JERPBiz.Finance.NoteNameParm.PrdOutStoreNoteNameID: return new FrmOutStoreNote();
               case JERPBiz.Finance.NoteNameParm.PrdBuyReceiveNoteNameID: return new FrmBuyReceiveNote();
               case JERPBiz.Finance.NoteNameParm.PrdBuyReturnNoteNameID: return new FrmBuyReturnNote();
               case JERPBiz.Finance.NoteNameParm.PrdBranchStoreMoveNoteNameID: return new FrmBranchStoreMoveNote();
               case JERPBiz.Finance.NoteNameParm.PrdReportLossNoteNameID: return new FrmReportLossNote(); 
               case JERPBiz.Finance.NoteNameParm.PrdSaleReplenishNoteNameID: return new FrmSaleReplenishNote(); 
               case JERPBiz.Finance.NoteNameParm.PrdBuyReplenishNoteNameID: return new FrmBuyReplenishNote();
             
               
               default: return null;                   
            }
       }

    }
}
