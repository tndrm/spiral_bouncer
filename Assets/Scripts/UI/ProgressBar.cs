using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	[SerializeField] private Image _imgFiller;
	[SerializeField] private Text _currentLevel;
	[SerializeField] private Text _nextLevel;

	public void SetCurrentValue(float valueNormalize)
	{
		this._imgFiller.fillAmount = valueNormalize;
	}

	public void SetLevel(float currentLevel)
	{
		this._currentLevel.text = $"{currentLevel}";
		this._nextLevel.text = $"{currentLevel++}";
	}
}
