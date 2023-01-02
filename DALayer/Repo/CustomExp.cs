using System;
using System.Collections.Generic;
using System.Text;

namespace DALayer.Repo
{
    public class CustomExp:Exception
    {
        public string msg;
        public CustomExp()
        {

        }
        public CustomExp(string msg) : base(msg)
        {
            msg = base.Message;
        }
    }
}
