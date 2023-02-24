using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;
using Random = UnityEngine.Random;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private Transform _gridLayout;
    [SerializeField] private Button _prefab;
    [SerializeField] private Canvas _startMode;
    [SerializeField] private Canvas _playMode;
    [SerializeField] private Canvas _endMode;

    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _scaleFactor;

    private IReadOnlyList<Sprite> _sprites;
    private List<Button> _buttonsOnScene = new List<Button>();
    private List<Sprite> _spritesForGame = new List<Sprite>();
    private Sprite _target;
    private int _level;

    public void ChangeMode()
    {
        _sprites = _startMode.GetComponent<StartGame>().GetSetSprites();

        foreach (var sprite in _sprites)
        {
            _spritesForGame.Add(sprite);
        }

        _startMode.enabled = false; //за это должна отвечать стейт машина
        _playMode.enabled = true; //за это должна отвечать стейт машина

        CreateLevel();
    }

    private void CreateLevel()
    {
        _level = LevelsController.EasyLevel;

        for (int i = 0; i < _level; i++)
        {
            var index = ReturnRandomIndex();

            var child = Instantiate(_prefab, _gridLayout);
            child.image.sprite = _spritesForGame[index];
            child.onClick.AddListener(() => PlayMode(child.image.sprite));
            _buttonsOnScene.Add(child);

            _spritesForGame.Remove(_spritesForGame[index]);
        }

        GetComponent<TargetUIController>().SetGoalUI();
    }

    private void PlayMode(Sprite sprite)
    {
        if (_target.name == sprite.name)
        {
            _level = LevelsController.NormalLevel;
            CreateLevel();
            if (_target.name == sprite.name)
            {
                _level = LevelsController.HeavyLevel;
                CreateLevel();
                
                if (_target.name == sprite.name && _level == LevelsController.HeavyLevel)
                {
                    _playMode.enabled = false; //задача для стейт машины
                    _endMode.enabled = true; //задача для стейт машины
                }
                else
                {
                    foreach (var button in _buttonsOnScene)
                    {
                        button.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration, 2);
                    }
                }
            }
            else
            {
                foreach (var button in _buttonsOnScene)
                {
                    button.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration, 2);
                }
            }
        }
        else
        {
            foreach (var button in _buttonsOnScene)
            {
                button.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration, 2);
            }
        }
    }

    private int ReturnRandomIndex()
        {
            return Random.Range(0, _spritesForGame.Count);
        }

        public Sprite AddTargetForGame()
        {
            var index = Random.Range(0, _buttonsOnScene.Count);
            _target = _buttonsOnScene[index].GetComponent<Button>().image.sprite;

            return _target;
        }
    }