using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelSetting : MonoBehaviour
{
    [SerializeField] private Transform _gridLayout;
    [SerializeField] private Button _prefab;
    [SerializeField] private Canvas _startMode;
    [SerializeField] private Canvas _playMode;

    public Action OnWin; //Должен вызываться в стейт машине, чтобы включить экран победы

    private IReadOnlyList<Sprite> _sprites;
    private List<Button> _buttonsOnScene = new List<Button>();
    [SerializeField] private Canvas _restartMode;
    private List<Sprite> _spritesForTarget = new List<Sprite>();


    public void ChangeMode()
    {
        _sprites = _startMode.GetComponent<ScriptableObject>().GetSetSprites();

        foreach (var sprite in _sprites)
        {
            _spritesForTarget.Add(sprite); 
        }
        
        _startMode.enabled = false; //за это должна отвечать стейт машина
        _playMode.enabled = true; //за это должна отвечать стейт машина

        gameObject.GetComponent<TargetController>().SetGoal();
        CreateLevel();
        Debug.Log(_sprites.Count);
    }

    private void CreateLevel()
    {
        //LevelsController.Level надо получать и контролировать из стейт машины

        var level = LevelsController.Level;
        for (int i = 0; i < level; i++)
        {
            var index = ReturnRandomIndex();

            var child = Instantiate(_prefab, _gridLayout);
            
            child.image.sprite = _spritesForTarget[index];

            child.onClick.AddListener(() => PlayMode(child.image.sprite));
            _buttonsOnScene.Add(child);
            _spritesForTarget.Remove(_spritesForTarget[index]);
        }
    }

    private void PlayMode(Sprite sprite)
    {
        var spriteForTarget = GetComponent<TargetController>().SpriteForTarget;

        if (spriteForTarget.name == sprite.name)
        {
            _playMode.enabled = false;//задача для стейт машины
            _restartMode.enabled = true;//задача для стейт машины
        }
    }

    private int ReturnRandomIndex()
    {
        return Random.Range(0, _spritesForTarget.Count);
    }
}