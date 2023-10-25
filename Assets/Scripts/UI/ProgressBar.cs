using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
	[SerializeField] private Image _imgFiller;
	[SerializeField] private Text _currentLevel;
	[SerializeField] private Text _nextLevel;

	public void UpdateCurrentValue(float valueNormalize)
	{
		this._imgFiller.fillAmount = valueNormalize;
	}

	public void SetCurrentLevel(float currentLevel)
	{
		this._currentLevel.text = $"{currentLevel}";
		this._nextLevel.text = $"{currentLevel+1}";
	}
}
