using System;
using System.Collections;
using UnityEngine;

public class Platform : MonoBehaviour
{
	[SerializeField] private float bounceForce;
	[SerializeField] private float bounceRadius;

	public void Break()
	{
		PlatformSegment[] platformSegments = GetComponentsInChildren<PlatformSegment>();

		foreach (var segment in platformSegments)
		{
			segment.Bounce(bounceForce, transform.position, bounceRadius);
		}
		StartCoroutine(Destroy());
	}

	public IEnumerator Destroy()
	{
		yield return new WaitForSeconds(2f);
		Destroy(gameObject);
	}
}
