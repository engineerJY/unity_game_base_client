using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBase
{
    /// <summary>
    /// セーブデータインターフェース
    /// </summary>
    public interface ISerializer
    {

        string magic { get; }
        int version { get; }
        string fileName { get; }
        FORMAT format { get; }
        System.Type type { get; }
        bool encrypt { get; }
        bool backup { get; }

        /// <summary>
        /// データバージョンのアップデート時に呼ばれる
        /// </summary>
        /// <param name="oldVersion"></param>
        /// <returns></returns>
        bool UpdateVersion(int oldVersion);
        ISerializer Clone();
    }
}
