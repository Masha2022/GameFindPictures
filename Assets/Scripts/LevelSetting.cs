using System;
using System.Collections;
using System.Collections.Generic;
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
    [SerializeField] private Camera _camera;
    private IReadOnlyList<Sprite> _sprites;
    private List<Sprite> _spritesForGame= new List<Sprite>();

    public void ChangeMode()
    {
        _sprites = _startMode.GetComponent<ScriptableObject>().GetSetSprites();
      
        foreach (var sprite in _sprites)
        {
            _spritesForGame.Add(sprite); 
        }
        
        _startMode.enabled = false; //за это должна отвечать стейт машина
        _playMode.enabled = true; //за это должна отвечать стейт машина
        
        _camera.GetComponent<TargetController>().SetGoal();
        CreateLevel();
        Debug.Log(_sprites.Count);
    }

    private void CreateLevel()
    {
        for (int i = 0; i < LevelsController.Level; i++)
        {
            var index = Random.Range(0, _sprites.Count);
            var child = Instantiate(_prefab, _gridLayout);
            child.image.sprite = _spritesForGame[index];
            //_spritesForGame.Remove(_spritesForGame[index]);
        }
    }
}