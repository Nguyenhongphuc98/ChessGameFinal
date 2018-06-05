using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectGame
{
    public enum TypeData
    {
        GUI_TIN,
        UNDO,
        RESET,
        MOVE,
        START,
        REDO
    }


    [Serializable]
    public class SocketData
    {
        public int flag;
        public string message;
        public Point move; 

        public SocketData(int f,string mess, Point move)
        {
            this.flag = f;
            this.message = mess;
            this.move = move;
        }
       
    }
}
