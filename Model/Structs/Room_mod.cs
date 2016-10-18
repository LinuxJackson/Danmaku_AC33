using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Structs;

namespace Model.Structs
{
    public class Room_mod : ModelBase
    {
        private string room_name = "";
        private string user_id = "";
        private string room_key = "";

        public string Room_key
        {
            get
            {
                return room_key;
            }

            set
            {
                room_key = value;
            }
        }

        public string Room_name
        {
            get
            {
                return room_name;
            }

            set
            {
                room_name = value;
            }
        }

        public string User_id
        {
            get
            {
                return user_id;
            }

            set
            {
                user_id = value;
            }
        }

        public void FromBytes(byte[] data)
        {
            base.Uid = BitConverter.ToInt32(data, 2);

            string temp = Encoding.Default.GetString(data, 6, 16);
            foreach (char c in temp)
            {
                if (c == '\0')
                    break;
                this.room_name += c;
            }

            temp = Encoding.Default.GetString(data, 22, 16);
            foreach (char c in temp)
            {
                if (c == '\0')
                    break;
                this.user_id += c;
            }

            temp = Encoding.Default.GetString(data, 38, 36);
            foreach (char c in temp)
            {
                if (c == '\0')
                    break;
                this.room_key += c;
            }
        }

        //}

        //public byte[] ToBytes()
        //{
        //    byte[] bResult = new byte[58];
        //    Encoding.Default.GetBytes(this.)
        //    Encoding.Default.GetBytes(this.room_name).CopyTo(bResult, 2);
        //}
    }
}
