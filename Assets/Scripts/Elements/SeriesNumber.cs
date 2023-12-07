using Elements;
using TMPro;
using UnityEngine;
using Debug = Sisus.Debugging.Debug;
using Random = UnityEngine.Random;

public class SeriesNumber : Element
{
    [SerializeField] private TextMeshPro _text;
    private const string Vowels = "EYUIOA";

    public bool HasVowels { get; private set; }

    private void Start()
    {
        _text.text = "";
        for (int i = 0; i < 7; i++)
        {
            var symbol = (char)(i >= 2 && i <= 4 ? Random.Range('0', '9' + 1) : Random.Range('A', 'Z' + 1));
            _text.text += symbol;

            if (Vowels.IndexOf(symbol) > -1) HasVowels = true;
        }
    }
}
