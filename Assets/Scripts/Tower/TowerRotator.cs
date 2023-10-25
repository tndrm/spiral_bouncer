using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]
public class TowerRotator : MonoBehaviour
{
	[SerializeField] private float rotateSpeed;
	private Rigidbody rb;
	private bool isRotate = false;
	private float mausePosX;

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
		if(Input.GetMouseButtonDown(0)) isRotate = true;

		if(Input.GetMouseButtonUp(0))
		{
			isRotate = false;
			rb.angularVelocity = Vector3.zero;
		}

		if(isRotate && mausePosX != Input.GetAxis("Mouse X"))
		{
			float torque = Input.GetAxis("Mouse X") * rotateSpeed;
			rb.AddTorque(Vector3.down * torque);
			mausePosX = Input.GetAxis("Mouse X");
		}
		if (isRotate && mausePosX == Input.GetAxis("Mouse X"))
		{
			rb.angularVelocity = Vector3.zero;
		}
	}
}
