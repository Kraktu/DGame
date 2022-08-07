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
	public Sprite backgroundImage;
	public Color backgroundColor;
	public int minLevel = 0, maxLevel = 10;
	public Theme theme;

}