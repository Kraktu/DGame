using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Player : MonoBehaviour
{
	public string playerName;
	[HideInInspector]
	public int stock=0;
	public TextMeshProUGUI playerNameText,playerStockText;

	private void Start()
	{
		playerNameText.text = playerName;
	}

	public void ChangeStock(int _nbrToAdd)
	{
		stock += _nbrToAdd;
		if (stock <= 0)
		{
			stock = 0;
		}
		UpdateStock();
	}
	public void UpdateStock()
	{
		playerStockText.text = stock.ToString();
	}
}
