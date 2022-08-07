using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BottomsUpScript : MonoBehaviour
{
	public TextMeshProUGUI nameText, gameText;
	[HideInInspector]
	public string nameString;
	public string gameString;
	private void Start()
	{
		GameManager.Instance.StartDelock();
	}
	public void WriteInfo()
	{
		nameText.text = nameString;
		gameText.text = gameString;
	}
}
