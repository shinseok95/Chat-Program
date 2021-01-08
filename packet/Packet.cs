using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace packet
{

    public enum PacketType
    {
        로그인 = 0,
        목록요청,
        연결신청,
        연결거부,
        연결성공,
        연결실패,
        수신,
        발신,
        데이터,
        가입신청,
        가입성공,
        가입실패,
        중복확인,
        연결해제,
        이미지발신,
        이미지수신
    }

    public enum PacketSendERROR
    {
        정상 =0,
        에러
    }

    [Serializable]
    public class Packet
    {
        public int Length;
        public int Type;

        public Packet()
        {
            this.Length = 0;
            this.Type = 0;
        }

        public static byte[] Serialize(Object o)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(ms, o);
            return ms.ToArray();
        }

        public static Object Desserialize(byte[] bt)
        {
            MemoryStream ms = new MemoryStream(1024 * 4);

            foreach (byte b in bt)
                ms.WriteByte(b);

            ms.Position = 0;
            BinaryFormatter bf = new BinaryFormatter();
            Object obj = bf.Deserialize(ms);
            ms.Close();

            return obj;
        }
        
    }


    [Serializable]
    public class Msg : Packet
    {
        public string message;
        public string time;
        public string DBName;

        public Msg()
        {
            this.message = null;
            this.time = null;
            DBName = null;
        }
        
        public void clear()
        {
            this.message = null;
            this.time = null;
            this.DBName = null;
        }
    }

    [Serializable]
    public class LoginInfo : Packet
    {
        public string ID;
        public string PW;
        public bool isValid;
        public bool isLoginOK;

        public LoginInfo()
        {
            this.ID = null;
            this.PW = null;
            this.isValid = true;
            this.isLoginOK = true;
        }

        public void clear()
        {
            this.ID = null;
            this.PW = null;
            this.isValid = true;
            this.isLoginOK = true;
        }
    }


    [Serializable]
    public class PartnerList : Packet
    {

        public List<string> partners;

        public PartnerList()
        {
            partners = new List<string>();
        }
        
        public void clear()
        {
            this.partners.Clear();
        }
    }

    [Serializable]
    public class Partner : Packet
    {
        public string ID;
        public string Key;
        public bool isAlreadyConnected;

        public Partner()
        {
            ID = null;
            Key= null;
            isAlreadyConnected = false;
    }

    public void clear()
        {
            this.ID = null;
            this.Key = null;
            isAlreadyConnected = false;
        }
    }

    [Serializable]
    public class SignUpQuery : Packet
    {
        public string ID;
        public string PW;
        public string name;
        public string phone;

        public SignUpQuery()
        {
            ID = null;
            PW = null;
            name = null;
            phone = null;
        }

        public void clear()
        {
            ID = null;
            PW = null;
            name = null;
            phone = null;
        }
    }

    [Serializable]
    public class SignUpAnswer : Packet
    {
        public string ID;
        public bool isValid;

        public SignUpAnswer()
        {
            ID = null;
            isValid = true;
        }

        public void clear()
        {
            this.ID = null;
            isValid = true;
        }
    }

    [Serializable]
    public class DisConnect : Packet
    {

        public string ID;

        public DisConnect()
        {
            ID = null;
        }

        public void clear()
        {
            this.ID = null;
        }
    }

    [Serializable]
    public class ImageData : Packet
    {
      public  int size;
        public string time;

        public ImageData()
        {
            size = 0;
            time = null;
        }
        
        public void clear()
        {
            size = 0;
            time = null;
        }
        
    }
}
