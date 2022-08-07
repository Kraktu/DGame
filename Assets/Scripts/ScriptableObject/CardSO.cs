using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Theme
{
	Hot,
	Sexy,
	Knowledge,
	Fun,
	Life,
}

[CreateAssetMenu(fileName = "CardData", menuName = "ScriptableObjects/CardSO")]
public class CardSO : ScriptableObject
{
	public string CardName = "DefaultSentenceName";
	public string CardText;
	public Sprite backgroundImage;
	public Color backgroundColor;
	public int minLevel = 0, maxLevel = 10;
	//public float factor;
	public Theme theme;

}