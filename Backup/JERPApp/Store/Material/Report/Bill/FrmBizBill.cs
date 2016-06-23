using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Store.Material.Report.Bill
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
             
               case JERPBiz.Finance.NoteNameParm.MtrStoreCheckNoteNameID: return new FrmStoreCheckNote();
               case JERPBiz.Finance.NoteNameParm.MtrIntoStoreNoteNameID: return new FrmIntoStoreNote();
               case JERPBiz.Finance.NoteNameParm.MtrOutStoreNoteNameID: return new FrmOutStoreNote();
               case JERPBiz.Finance.NoteNameParm.MtrOtherOutStoreNoteNameID: return new FrmOtherOutStoreNote();
               case JERPBiz.Finance.NoteNameParm.MtrBuyReceiveNoteNameID: return new FrmBuyReceiveNote();
               case JERPBiz.Finance.NoteNameParm.MtrBuyReturnNoteNameID: return new FrmBuyReturnNote();
               case JERPBiz.Finance.NoteNameParm.MtrBranchStoreMoveNoteNameID: return new FrmBranchStoreMoveNote();
               case JERPBiz.Finance.NoteNameParm.MtrReportLossNoteNameID: return new FrmReportLossNote();
               case JERPBiz.Finance.NoteNameParm.MtrBuyReplenishNoteNameID: return new FrmBuyReplenishNote();
               case JERPBiz.Finance.NoteNameParm.MtrOutSrcRecycleNoteNameID: return new FrmOutSrcRecycleNote();
               case JERPBiz.Finance.NoteNameParm.MtrOutSrcSupplyNoteNameID: return new FrmOutSrcSupplyNote();
               case JERPBiz.Finance.NoteNameParm.MtrOutSrcLossSupplyNoteNameID : return new FrmOutSrcLossSupplyNote(); 
               default: return null;                   
            }
       }

    }
}
