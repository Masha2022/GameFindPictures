using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetController : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI _target;
    private IReadOnlyList<Sprite> _sprites;
    [SerializeField]private Canvas _startMode;
    private List<Sprite> _spritesForTarget = new List<Sprite>();
    private int _randomIndex;

    [UsedImplicitly]
    private List<Sprite> ChangeIReadOnlyList()
    {
        _sprites = _startMode.GetComponent<ScriptableObject>().GetSetSprites();
        foreach (var sprite in _sprites)
        {
           _spritesForTarget.Add(sprite); 
        }

        return  _spritesForTarget;
    }

    public void SetGoal() //SetGoal-задать цель
    {
        ChangeIReadOnlyList();
        _target.text = $"Target: {_spritesForTarget[ReturnRandomIndex()].name.ToUpper()} ";
        _spritesForTarget.Remove(_spritesForTarget[ReturnRandomIndex()]);
        Debug.Log("_spritesForTarget.Count"+_spritesForTarget.Count);
    }
    
    private int ReturnRandomIndex()
    {
        return Random.Range(0, _sprites.Count);
    }
}
