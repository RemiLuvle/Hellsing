

using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;

namespace HellsingPc.Misc
{
    internal class PhotonEX
    {

        public static void OpRaiseEvent(byte code, object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
        {
            Il2CppSystem.Object customObject2 = SerializationUtils.FromManagedToIL2CPP<Il2CppSystem.Object>(customObject);
            OpRaiseEvent(code, customObject2, RaiseEventOptions, sendOptions);
        }
        public static void OpRaiseEvent(byte code, Il2CppSystem.Object customObject, RaiseEventOptions RaiseEventOptions, SendOptions sendOptions)
        {
            PhotonNetwork.Method_Private_Static_Boolean_Byte_Object_RaiseEventOptions_SendOptions_0(code, customObject, RaiseEventOptions, sendOptions);
        }
    }
    internal static class SerializationUtils
    {
        internal static byte[] ToByteArray(Il2CppSystem.Object obj)
        {
            if (obj == null) return null;
            var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new Il2CppSystem.IO.MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        internal static byte[] ToByteArray(object obj)
        {
            if (obj == null) return null;
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new System.IO.MemoryStream();
            bf.Serialize(ms, obj);
            return ms.ToArray();
        }

        internal static T FromByteArray<T>(byte[] data)
        {
            if (data == null) return default(T);
            var bf = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new System.IO.MemoryStream(data);
            var obj = bf.Deserialize(ms);
            return (T)obj;
        }

        internal static T IL2CPPFromByteArray<T>(byte[] data)
        {
            if (data == null) return default(T);
            var bf = new Il2CppSystem.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            var ms = new Il2CppSystem.IO.MemoryStream(data);
            object obj = bf.Deserialize(ms);
            return (T)obj;
        }

        internal static T FromIL2CPPToManaged<T>(Il2CppSystem.Object obj)
        {
            return FromByteArray<T>(ToByteArray(obj));
        }

        internal static T FromManagedToIL2CPP<T>(object obj)
        {
            return IL2CPPFromByteArray<T>(ToByteArray(obj));
        }

        internal static object[] FromIL2CPPArrayToManagedArray(Il2CppSystem.Object[] obj)
        {
            var Parameters = new object[obj.Length];
            for (var i = 0; i < obj.Length; i++)
                if (obj[i].GetIl2CppType().Attributes == Il2CppSystem.Reflection.TypeAttributes.Serializable)
                    Parameters[i] = FromIL2CPPToManaged<object>(obj[i]);
                else
                    Parameters[i] = obj[i];
            return Parameters;
        }

        internal static Il2CppSystem.Object[] FromManagedArrayToIL2CPPArray(object[] obj)
        {
            Il2CppSystem.Object[] Parameters = new Il2CppSystem.Object[obj.Length];
            for (var i = 0; i < obj.Length; i++)
            {
                if (obj[i].GetType().Attributes == System.Reflection.TypeAttributes.Serializable)
                    Parameters[i] = FromManagedToIL2CPP<Il2CppSystem.Object>(obj[i]);
                else
                    Parameters[i] = (Il2CppSystem.Object)obj[i];
            }
            return Parameters;
        }

    }
}
