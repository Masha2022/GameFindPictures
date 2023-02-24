using System;
using TMPro;
using UnityEngine;


public class TargetUIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _target;
    private Sprite _targetSprite;
    
    public void SetGoalUI() 
    {
        _targetSprite = GetComponent<LevelSettings>().AddTargetForGame();
        _target.text = $"Target: {_targetSprite.name.ToUpper()} ";
    }
}