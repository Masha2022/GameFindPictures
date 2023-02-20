using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScripteableObject : MonoBehaviour
{
    private const int MAX_NUMBER_VALUE = 58;
    private const int MIN_NUMBER_VALUE = 48;
    private const int MAX_WORD_VALUE = 91;
    private const int MIN_WORD_VALUE = 65;
    private const int MAX_SIGN_VALUE = 32;
    private const int MIN_SIGN_VALUE = 1;
    
    public enum SetName
    {
        Signs = 0,
        Words = 1,
        Numbers = 2
    }
    
    [SerializeField] 
    private GameObject _letterPrefab;
    
    private SetName _setName;
    private GameObject _letterIcon;

    private Dictionary<int, GameObject> _playableLetters;
    
    public void Initialize(SetName name)
    {
        _setName = name;
        GetBorders(out var minElement,out var maxElement);
        //_letterIcon = Instantiate(Random.Range(minElement, maxElement)); мб что-то ещё
        RandomizeSymbols();
    }

    private void RandomizeSymbols()
    {
        GetBorders(out var minElement,out var maxElement);
        for (int i = 0; i < 9; i++)
        {
            int number;
            do
            {
                number = Random.Range(minElement, maxElement);
            } while (_playableLetters.ContainsKey(number));
            //_playableLetters.Add(int,Инициализация игрового обьекта); Все наши игровые кубики
        }
    }

    private void GetBorders(out int minValue, out int maxValue)
    {
        
        minValue = 0;
        maxValue = 0;
        switch (_setName)
        {
            case SetName.Signs:
            {
                maxValue = MAX_SIGN_VALUE;
                minValue = MIN_SIGN_VALUE;
                break;
            }
            case SetName.Numbers:
            {
                maxValue = MAX_NUMBER_VALUE;
                minValue = MIN_NUMBER_VALUE;
                break;
            }
            case SetName.Words:
            {
                maxValue = MAX_WORD_VALUE;
                minValue = MIN_WORD_VALUE;
                break;
            }
        }
    }
}