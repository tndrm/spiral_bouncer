using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class BallJumper : MonoBehaviour
{
	[SerializeField] private float jumpForce;

	private Rigidbody rb;


	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.TryGetComponent(out PlatformSegment platformSegment))
		{
			rb.velocity = Vector3.zero;
			rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
		};
	}
}
