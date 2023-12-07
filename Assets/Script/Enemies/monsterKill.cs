using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class monsterKill : MonoBehaviour
{
    private int _monsterSlain;
    private int _coinCollected;
    private int _expCollected;
    [SerializeField] private TMP_Text _monsterText;
    [SerializeField] private TMP_Text _coinText;
    [SerializeField] private TMP_Text _expText;

   
    void Start()
    {
        _monsterSlain = 0;
        _coinCollected = 0;
        _expCollected = 0;
    }

    public void NumberOfKill()
    {
        _monsterSlain++;
        
    }

    public void NumberCoin()
    {
        _coinCollected++;
    }

    public void NumberExp()
    {
        _expCollected++;
    }
    public void MonsterText()
    {
        _monsterText.text +=  _monsterSlain;
        _coinText.text += _coinCollected;
        _expText.text += _expCollected;
    }
}
