using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Linq;

public class TruthOrDare : MonoBehaviour
{
	//Real Data
	public TextMeshProUGUI gameText;
	public Image background;
	public Color hotBgColor, sexyBgColor, knowledgeBgColor, funBgColor, lifeBgColor;
	public string namePattern, xPattern, yPattern, factorPattern;


	// SO Data
	public TruthOrDareSO myTodSO;
	public string CardName;
	public Sprite backgroundImage;
	public Color backgroundColor;
	public int minLevel, maxLevel;
	public Theme theme;
	public string structuredText;
    public float factor;
    public int x1, x2, y1, y2;

	private void Start()
	{
		GameManager.Instance.StartDelock();
		AssociateSO(GameManager.Instance.truthOrDareSOs[Random.Range(0, GameManager.Instance.truthOrDareSOs.Count)]);
	}

	public void AssociateSO(TruthOrDareSO _futureTodSO)
	{
		myTodSO = _futureTodSO;
		CardName = myTodSO.CardName;
		backgroundImage = myTodSO.backgroundImage;
		//backgroundColor = myTodSO.backgroundColor;
		minLevel = myTodSO.minLevel;
		maxLevel = myTodSO.maxLevel;
		theme = myTodSO.theme;
		structuredText = myTodSO.structuredText;
		factor = myTodSO.factor;
		x1 = myTodSO.x1;
		x2 = myTodSO.x2;
		y1 = myTodSO.y1;
		y2 = myTodSO.y2;
		UpdateCard();
	}

	public void UpdateCard()
	{
		ChangeBGColor();
		ParseText();
		gameText.text = structuredText;
	}
	public void ChangeBGColor()
	{
		switch (theme)
		{
			case Theme.Hot:
				background.color = hotBgColor;
				break;
			case Theme.Sexy:
				background.color = sexyBgColor;
				break;
			case Theme.Knowledge:
				background.color = knowledgeBgColor;
				break;
			case Theme.Fun:
				background.color = funBgColor;
				break;
			case Theme.Life:
				background.color = lifeBgColor;
				break;
			default:
				background.color = Color.black;
				break;
		}
	}
	public void ParseText()
	{
		// Plus tard, faire une sécurité si le nombre de balise name > au nombre de joueur, remove les cartes !
		List<string> _tempNames = GameManager.Instance.playersName.ToList();
		while (structuredText.Contains(namePattern))
		{
			int _generatedNbr = Random.Range(0, _tempNames.Count);
			Debug.Log(_generatedNbr);
			string _chosenName = _tempNames[_generatedNbr];
			_tempNames.RemoveAt(_generatedNbr);
			structuredText = ReplaceFirst(structuredText, namePattern, _chosenName);
			Debug.Log(structuredText);
		}

		structuredText = ReplaceNumberInStructure(structuredText,xPattern, x1, x2);
		structuredText = ReplaceNumberInStructure(structuredText, yPattern, y1, y2);
		if (factor!=0)
		{
			while(structuredText.Contains(factorPattern))
			{
			structuredText = ReplaceFirst(structuredText, factorPattern,Mathf.Round(factor*GameManager.Instance.level).ToString());
			}
		}
	}

	public string ReplaceFirst(string _text, string _search, string _replace)
	{
		int pos = _text.IndexOf(_search);
		if (pos < 0)
		{
			return _text;
		}
		return _text.Substring(0, pos) + _replace + _text.Substring(pos + _search.Length);
	}
	public string ReplaceNumberInStructure(string _structuredText,string _pattern,int _min, int _max)
	{
		while (_structuredText.Contains(_pattern))
		{
			_structuredText = ReplaceFirst(structuredText, _pattern, GenerateIfInterval(_min, _max).ToString());
		}
		return _structuredText;
	}
	public int GenerateIfInterval(int _nbr1,int _nbr2)
	{
		int _final = _nbr1;
		if (_nbr1 != _nbr2)
		{
			_final = Random.Range(_nbr1, _nbr2 + 1);
		}
		return _final;
	}
}
