using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    public class ModelBase
    {
        private int uid;

        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }

        public byte[] ToBytes(short Op_code, int uid)
        {
            byte[] bResult = new byte[8];
            BitConverter.GetBytes((short)2);
            BitConverter.GetBytes(uid);
            BitConverter.GetBytes(Op_code);
            return bResult;
        }
    }
}
