using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBase
{
    [System.Serializable]
    public sealed class UserSettings : ISerializer
    {

        //ISerializerインターフェースの実装
        //--------------------------------------------------
        public string magic { get { return "UserSettings_180101"; } }
        public int version { get { return 1; } }
        public string fileName { get { return "/UserSettings"; } }
        public string filePath { get { return "/UserSettings"; } }
        public System.Type type { get { return typeof(UserSettings); } }
        public FORMAT format { get { return this.format_; } set { this.format_ = value; } }
        public bool encrypt { get { return this.encrypt_; } set { this.encrypt_ = value; } }
        public bool backup { get { return this.backup_; } set { this.backup_ = value; } }

        /// <summary>
        /// バージョンアップ処理
        /// </summary>
        /// <param name="oldVersion">読み込まれたバージョン</param>
        /// <returns>破棄する場合はfalse</returns>
        public bool UpdateVersion(int oldVersion)
        {

            return true;
        }

        /// <summary>
        /// 複製
        /// </summary>
        /// <returns></returns>
        public ISerializer Clone()
        {
            return this.MemberwiseClone() as ISerializer;
        }
        //--------------------------------------------------

        [System.NonSerialized]
        private FORMAT format_ = FORMAT.BINARY;
        [System.NonSerialized]
        private bool encrypt_ = false;
        [System.NonSerialized]
        private bool backup_ = false;

        public long date = 0L;
        public int count = 0;

        public void Clear()
        {
            this.format_ = FORMAT.BINARY;
            this.encrypt_ = false;
            this.backup_ = false;

            this.date = System.DateTime.MinValue.ToBinary();
            this.count = 0;
        }
    }
}
