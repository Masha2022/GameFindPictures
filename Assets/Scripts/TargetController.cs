using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class TargetController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _target;
    private IReadOnlyList<Sprite> _sprites;
    [SerializeField]private Canvas _startMode;
    private List<Sprite> _spritesForTarget = new List<Sprite>();
    private int _randomIndex;
    public Sprite SpriteForTarget;

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
        var index = ReturnRandomIndex();
        _target.text = $"Target: {_spritesForTarget[index].name.ToUpper()} ";
        SpriteForTarget =_spritesForTarget[index];
        
        _spritesForTarget.Remove(_spritesForTarget[index]);
    }
    
    private int ReturnRandomIndex()
    {
        return Random.Range(0, _sprites.Count);
    }
}
