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
        public ISerializer serializer;
        public string filePath;
        public FinishHandler finishHandler;
        public bool async;
    }

    public delegate void FinishHandler(IO_RESULT ret, ref DataInfo dataInfo);

    public sealed class StorageManager
    {
        private WaitCallback saveThreadHandler = null;
        private WaitCallback loadThreadHandler = null;

        public StorageManager()
        {
            this.saveThreadHandler = new WaitCallback(this.saveThreadHandler);
            this.loadThreadHandler = new WaitCallback(this.loadThreadHandler);
        }
        
        public void Save(ISerializer saveInterface, FinishHandler finishHandler, bool async = true)
        {
            DataInfo dataInfo = new DataInfo();
            dataInfo.serializer = saveInterface.Clone();

            dataInfo.filePath = Application.persistentDataPath + saveInterface.filePath;
            dataInfo.finishHandler = finishHandler;
            dataInfo.async = async;

            if (async)
                ThreadPool.QueueUserWorkItem(this.saveThreadHandler, dataInfo);
            else
                //this.SaveThreadMain(dataInfo);
                return;
        }

        public void Load(ISerializer loadInterface, FinishHandler finishHandler, bool async = true)
        {
            DataInfo dataInfo = new DataInfo();
            dataInfo.serializer = loadInterface;
            dataInfo.filePath = Application.persistentDataPath + loadInterface.filePath;
            dataInfo.finishHandler = finishHandler;
            dataInfo.async = async;

            if(!File.Exists(dataInfo.filePath))
            {
                //this.FinishAccessing(IO_RESULT.NONE, ref dataInfo);
                return;
            }

            if (async)
                ThreadPool.QueueUserWorkItem(this.loadThreadHandler, dataInfo);
            else
                //this.LoadThreadMain(dataInfo);
                return ;

        }
        


    }
}


