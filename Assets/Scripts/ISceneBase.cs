using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameBase
{
    /// <summary>
    /// シーンインターフェース
    /// </summary>
    public interface ISceneBase
    {

        void Awake();

        void OnEnable();

        void Start();

        void Update();

        void LateUpdate();
    }
}

