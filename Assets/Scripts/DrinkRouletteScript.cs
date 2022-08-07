using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[System.Serializable]
public struct Action
{
    public string actionName;
    public Color backgroundColor;
}
    public class DrinkRouletteScript : MonoBehaviour
{
	public TextMeshProUGUI nameText,actionText,numberText;
	public Image background;
	public List<Action> actionPossibilities = new List<Action>();
	public float animTime=2;
	List<string> actionNames = new List<string>();
	List<string> possibleNumber = new List<string>();

	Coroutine nameAnim, actionAnim, numberAnim;
	private void Start()
	{
		for (int i = 0; i < actionPossibilities.Count; i++)
		{
			actionNames.Add(actionPossibilities[i].actionName);

		}
		for (int i = 0; i < GameManager.Instance.level; i++)
		{
			possibleNumber.Add((i + 1).ToString());
		}
		nameAnim = StartCoroutine(TextAnimScrolling(nameText,GameManager.Instance.playersName,animTime*1));
		numberAnim = StartCoroutine(TextAnimScrolling(numberText,possibleNumber,animTime*2));
		actionAnim = StartCoroutine(TextAnimScrolling(actionText,actionNames,animTime*3,true));
	}

	IEnumerator TextAnimScrolling(TextMeshProUGUI _displayTM, List<string> _possibilities, float _animTime = 2, bool _changeBackground = false)
	{
		float _startingTime = 0, _currentTime=_startingTime;
		float _startingSpeed = 10, _currentSpeed=_startingSpeed;
		float _previousChangeTime=0;
		while(_currentTime<_animTime)
		{

			if (Input.GetMouseButtonDown(0)&&_currentTime>1)
			{
				_currentTime += animTime;

			}
			_currentTime += Time.deltaTime;
			if(_currentTime!=0)
			{
				_currentSpeed = _startingSpeed * (_animTime / _currentTime);
			}
			if(_currentTime>_previousChangeTime+(1/_currentSpeed))
			{
				_displayTM.text = _possibilities[Random.Range(0, _possibilities.Count)];
				_previousChangeTime = _currentTime;
			}
			
			yield return null;
		}

		int _chosenNumber = Random.Range(0, _possibilities.Count);
		_displayTM.text = _possibilities[_chosenNumber];
		if(_changeBackground)
		{
			ChangeBackground();
		}
	}

	void ChangeBackground()
	{
		for (int i = 0; i < actionPossibilities.Count; i++)
		{
			if(actionPossibilities[i].actionName==actionText.text)
			{
				background.color = actionPossibilities[i].backgroundColor;
				GameManager.Instance.StartDelock();
				return;
			}

		}
	}
}
