using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace JERPApp.Store.MaterialOEM.Report.Bill
{
    public class FrmBizBill:Form 
    {
       public virtual void DetailNote(long NoteID)
       {
       }
       public const int CheckStoreNoteID = 1;
       public const string CheckStoreNoteName = "盘点单";
       public const int ReceiveNoteID = 2;
       public const string ReceiveNoteNoteName = "收货单";
       public const int ReturnNoteID = 3;
       public const string ReturnNoteNoteName = "退货单";
       public const int OutStoreNoteID =4;
       public const string OutStoreNoteName = "出库单";
       public const int IntoStoreNoteID = 5;
       public const string IntoStoreNoteName = "入库单"; 

       public const int OutSrcSupplyNoteID = 6;
       public const string OutSrcSupplyNoteName = "委外发料单";
       public const int OutSrcRecycleNoteID = 7;
       public const string OutSrcRecycleNoteName = "委外回料单";   
   
       public static FrmBizBill Create(int NoteNameID)
       {
           switch (NoteNameID)
           {
               case CheckStoreNoteID: return new FrmStoreCheckNote();
               case ReceiveNoteID: return new FrmReceiveNote();
               case ReturnNoteID: return new FrmReturnNote();
               case OutStoreNoteID: return new FrmOutStoreNote(); 
               case IntoStoreNoteID: return new FrmIntoStoreNote();
               case OutSrcSupplyNoteID: return new FrmOutSrcSupplyNote();
               case OutSrcRecycleNoteID: return new FrmOutSrcRecycleNote();
               default: return null;                   
            }
       }

    }
}
