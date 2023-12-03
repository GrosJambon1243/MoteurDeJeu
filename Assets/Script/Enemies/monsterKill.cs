using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class monsterKill : MonoBehaviour
{
    private int _monsterSlain;
    private int _coinCollected;
    [SerializeField] private TMP_Text _monsterText;

    public int MonsterSlain
    {
        get => _monsterSlain;
    }
    void Start()
    {
        _monsterSlain = 0;
        _coinCollected = 0;
    }

    public void NumberOfKill()
    {
        _monsterSlain++;
        Debug.Log(_monsterSlain);
    }

    public void NumberCoin()
    {
        _coinCollected++;
    }

    public void MonsterText()
    {
        _monsterText.text +=  _monsterSlain;
    }
}
