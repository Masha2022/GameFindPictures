using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LevelsConstant : MonoBehaviour
{
    public const int EasyLevel = 3;
    public const int NormalLevel = 6;
    public const int HeavyLevel = 9;

    private List<int> _levels = new List<int>();
    private int _index;

    private void Start()
    {
        _index = 0;
        _levels.Add(EasyLevel);
        _levels.Add(NormalLevel);
        _levels.Add(HeavyLevel);
    }

    public int GetLevel()
    {
        _index++;
        if (_index > _levels.Count)
        {
            return 0;
        }
        return _levels[_index];
    }

}