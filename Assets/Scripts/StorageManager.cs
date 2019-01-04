using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBase
{
    public enum IO_RESULT
    {
        NONE = 0,
        SAVE_SUCCESS = 1,
        SAVE_FAILED = -1,
        LOAD_SUCCESS = 10,
        LOAD_FAILED = -10,
    }

    public enum FORMAT
    {
        BINARY,
        JSON,
    }

    public struct DataInfo
    {
        public ISerializer serialize;
        public string filePath;
        public FinishHandler finishHandler;
        public bool async;
    }

    public delegate void FinishHandler(IO_RESULT ret, ref DataInfo dataInfo);

    public class StorageManager : MonoBehaviour
    {

        

        


    }
}


