using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public event Action<float> OnLevelProgressChangedEvent;
	public event Action OnLevelPassedEvent;

	private int platformAmound;
	private int defaultLevelProgress = 0;

	public int levelProgress { get; private set; }
	public float levelProgressNormalized => (float)levelProgress / platformAmound;

	private void Awake()
	{
		platformAmound = FindObjectOfType<TowerBuilder>().platformAmound;

		levelProgress = defaultLevelProgress;
		OnLevelProgressChangedEvent?.Invoke(levelProgressNormalized);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out PlatformSegment platformSegment))
		{		
			other.GetComponentInParent<Platform>().Break();
			levelProgress += 1;
			OnLevelProgressChangedEvent?.Invoke(levelProgressNormalized);
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out FinishPlatform platform))
		{
			OnLevelPassedEvent?.Invoke();
		}
	}
}
