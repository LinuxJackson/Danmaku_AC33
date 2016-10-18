using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Structs;
using System.Collections;

namespace Model
{
    public class Room
    {
        public Room_mod EoomInfo = new Room_mod();
        public Dictionary<string, UserData_mod> Users = new Dictionary<string, UserData_mod>();
    }
}
