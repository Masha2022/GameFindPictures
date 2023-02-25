using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class LevelSettings : MonoBehaviour
{
    [SerializeField] private GridLayoutGroup _gridLayout;
    [SerializeField] private Button _prefab;
    [SerializeField] private Canvas _startMode;
    [SerializeField] private Canvas _playMode;
    [SerializeField] private Canvas _endMode;
    [SerializeField]private TargetUIController _targetText;
    
    [SerializeField] private float _scaleDuration;
    [SerializeField] private float _scaleFactor;

    private IReadOnlyList<Sprite> _sprites;
    private List<Button> _buttonsOnScene = new List<Button>();
    private List<Sprite> _spritesForGame = new List<Sprite>();
    private Sprite _target;
    private int _level;
    private LevelsConstant _levelChange;
    

    private void Start()
    {
        _level = LevelsConstant.EasyLevel;
    }

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
        for (int i = 0; i < _level; i++)
        {
            var index = ReturnRandomIndex();

            var child = Instantiate(_prefab, _gridLayout.transform);
            child.image.sprite = _spritesForGame[index];
            child.onClick.AddListener(() => PlayMode(child.image.sprite));
            _buttonsOnScene.Add(child);

            _spritesForGame.Remove(_spritesForGame[index]);
        }

        _targetText.OnChangeText.Invoke();
    }

    private void PlayMode(Sprite sprite)
    {
        if (_target.name == sprite.name)
        {
            foreach (var button in _buttonsOnScene)
            {
                Destroy(button.gameObject);
            }
            
            _level = GetComponent<LevelsConstant>().GetLevel();
            
            if (_level == -1)
            {
                _playMode.enabled = false;
                _endMode.enabled = true;
            }
            else
            {
                _buttonsOnScene.Clear();
                _spritesForGame.Clear();
            }
            ChangeMode();
        }

        foreach (var button in _buttonsOnScene)
        {
            button.transform.DOPunchScale(Vector3.one * _scaleFactor, _scaleDuration, 2);
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