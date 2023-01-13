using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    public static T Instance { get; private set; }

    protected virtual void Awake()
    {
        Debug.Assert(Instance == false, "Duplicate singleton instance");
        Instance = (T) this;
    }

    protected virtual void OnDestroy()
    {
        if (Instance == this) Instance = null;
    }
}
