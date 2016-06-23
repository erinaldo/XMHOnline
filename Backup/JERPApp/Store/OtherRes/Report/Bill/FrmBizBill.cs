using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Store.OtherRes.Report.Bill
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
             
               case JERPBiz.Finance.NoteNameParm.OtherResStoreCheckNoteNameID: return new FrmStoreCheckNote();
               case JERPBiz.Finance.NoteNameParm.OtherResIntoStoreNoteNameID: return new FrmIntoStoreNote();
               case JERPBiz.Finance.NoteNameParm.OtherResOutStoreNoteNameID: return new FrmOutStoreNote();
               case JERPBiz.Finance.NoteNameParm.OtherResBuyReceiveNoteNameID: return new FrmBuyReceiveNote();
               case JERPBiz.Finance.NoteNameParm.OtherResBuyReturnNoteNameID: return new FrmBuyReturnNote();
               case JERPBiz.Finance.NoteNameParm.OtherResBranchStoreMoveNoteNameID: return new FrmBranchStoreMoveNote();
               case JERPBiz.Finance.NoteNameParm.OtherResReportLossNoteNameID: return new FrmReportLossNote();
               case JERPBiz.Finance.NoteNameParm.OtherResBuyReplenishNoteNameID: return new FrmBuyReplenishNote();
               default: return null;                   
            }
       }

    }
}
