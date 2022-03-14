using UnityEngine;

public class UIWIdgetProgressBar : MonoBehaviour
{
	[SerializeField] private ProgressBar _progressBar;
	private Ball _ball;

	private void OnEnable()
	{		
		_ball = FindObjectOfType<Ball>();
		_progressBar.SetCurrentValue(_ball.levelProgressNormalized);
		_ball.OnLevelProgressChangedEvent += OnLevelProgressChanged;
	}

	private void OnLevelProgressChanged(float progress)
	{
		this._progressBar.SetCurrentValue(progress);
	}

	private void OnDisable()
	{
		_ball.OnLevelProgressChangedEvent -= OnLevelProgressChanged;
	}
}
