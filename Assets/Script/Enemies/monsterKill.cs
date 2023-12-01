using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monsterKill : MonoBehaviour
{
    private int monsterSlain;

    public int MonsterSlain
    {
        get => monsterSlain;
    }
    void Start()
    {
        monsterSlain = 0;
    }

    public void NumberOfKill()
    {
        monsterSlain++;
        Debug.Log(monsterSlain);
    }
}
