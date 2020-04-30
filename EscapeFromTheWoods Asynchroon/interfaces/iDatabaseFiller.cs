using System;
using System.Collections.Generic;
using System.Text;

namespace EscapeFromTheWoods_Asynchroon.interfaces
{
    interface iDatabaseFiller
    {
        public void FillDataBase(iWood wood);
        public void UploadLogs(iWood wood);
        public void UploadWoodRecords(iWood wood);
        public void UploadMonkeyRecords(iWood wood);
    }
}
