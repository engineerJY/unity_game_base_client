using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBase : MonoBehaviour
{
    public virtual void Awake()
    {
        Debug.Log("ScreenBase:Awake");
    }

    public virtual void OnEnable()
    {
        Debug.Log("ScreenBase:OnEnable");
    }

    public virtual void Start()
    {
        Debug.Log("ScreenBase:Start");
    }

    public virtual void OnDesable()
    {
        Debug.Log("ScreenBase:OnDesable");
    }

    public virtual void OnDestroy()
    {
        Debug.Log("ScreenBase:OnDestroy");
    }

    void Update()
    {
        
    }
}
