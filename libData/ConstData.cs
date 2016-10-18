using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace libData
{
    static public class ConstData
    {
        public const string DataPackageException = "This property can't be null";

        public const short OP_code_CreateRoom_Succeed = 0;
        public const short OP_code_CreateRoom_NameTaken = 1;
        public const short OP_code_CreateRoom_Failed = 2;

        public const short OP_code_JoinRoom_Succeed = 0;
        public const short OP_code_JoinRoom_NameTaken = 1;
        public const short OP_code_JoinRoom_Failed = 2;
        public const short OP_code_JoinRoom_RoomExistsFailed = 3;
        public const short OP_code_JoinRoom_RoomKeyError = 4;

        public const short OP_code_ExitRoom_Succeed = 0;
        public const short OP_code_ExitRoom_Failed = 1;
    }
}
