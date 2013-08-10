using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AssetManagerClient
{
    public class cbxItem
    {
        public string Text { get; set; }
        public string  Id { get; set; }

        public override string ToString()
        {
            return Text;
        }
        // you need this override, else your combobox items are gonna look like 
        // "Winforms.Form1 + cbxItem"
    }
}
