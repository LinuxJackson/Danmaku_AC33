using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace Model.Structs
{
    public class UserData_mod : ModelBase
    {
        private string user_id = "";
        private string room_id = "";
        private System.Net.Sockets.TcpClient client;

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

        public TcpClient Client
        {
            get
            {
                return client;
            }

            set
            {
                client = value;
            }
        }

        public string Room_id
        {
            get
            {
                return room_id;
            }

            set
            {
                room_id = value;
            }
        }

        public void FromBytes(byte[] data)
        {
            base.Uid = BitConverter.ToInt32(data, 2);
            this.user_id = Encoding.Default.GetString(data, 6, 16);
            this.room_id = Encoding.Default.GetString(data, 22, 20);
        }
    }
}
