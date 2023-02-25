using System.Collections.Generic;
using UnityEngine;

public class LevelsConstant
{
    public const int EasyLevel = 3;
    public const int NormalLevel = 6;
    public const int HeavyLevel = 9;

    private readonly List<int> _levels = new List<int>();
    private int _index = 0;

    private void Start()
    {
        _levels.Add(EasyLevel);
        _levels.Add(NormalLevel);
        _levels.Add(HeavyLevel);
    }

    public int GetLevel()
    {
        if (_index < _levels.Count)
        {
            _index++;
        }

        return _levels[_index];
    }
}