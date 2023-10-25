using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public event Action<int> OnLevelProgressChangedEvent;
	public event Action OnLevelPassedEvent;
	public int levelProgress = 0;

	private void Awake()
	{
		OnLevelProgressChangedEvent?.Invoke(levelProgress);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.TryGetComponent(out PlatformSegment platformSegment))
		{		
			other.GetComponentInParent<Platform>().Break();
			levelProgress += 1;
			OnLevelProgressChangedEvent?.Invoke(levelProgress);
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
