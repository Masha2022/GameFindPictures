using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UIElements.Image;

public class ScriptableObject : MonoBehaviour
{
    [SerializeField] private List<Sprite> _lettersSprites;
    [SerializeField] private List<Sprite> _numbersSprites;
    [SerializeField] private List<Sprite> _animalsSprites;

    [SerializeField] private Button _buttonLetters;
    [SerializeField] private Button _buttonNumbers;
    [SerializeField] private Button _buttonAnimals;

    private int _indexForSet;
    private List<List<Sprite>> _allSetsSprites;

    private string _indexSet;

    public void OnClick()
    {
        
    }
}
