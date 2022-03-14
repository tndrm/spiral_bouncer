using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
	[SerializeField] private float rotateSpeed;
	private Rigidbody rb;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Moved)
			{
				float torque = touch.deltaPosition.x * rotateSpeed * Time.deltaTime;
				rb.AddTorque(Vector3.down * torque);
			}

			if (touch.phase == TouchPhase.Stationary)
			{
				rb.angularVelocity = Vector3.zero;
			}
		}
	}
}
