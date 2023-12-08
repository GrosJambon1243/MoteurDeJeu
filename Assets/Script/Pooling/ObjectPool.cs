using System;
using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private List<PoolObject> children;
    private int poolIndex;

    private void Awake()
    {
        children = GetComponentsInChildren<PoolObject>(true).ToList();
    }

    internal PoolObject GetObject()
    {
        poolIndex %= children.Count;
        var next = children[poolIndex++];
        next.Reset();
        return next;
    }
}
