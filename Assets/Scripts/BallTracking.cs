using UnityEngine;

public class BallTracking : MonoBehaviour
{

	[SerializeField] private Vector3 directionOffset;
	[SerializeField] private float targetOffset;
	[SerializeField] private float lenght;
	private Ball ball;
	private Beam beam;
	private Vector3 cameraPosition;
	private Vector3 minimumBallPosition;

	private void Start()
	{
		ball = FindObjectOfType<Ball>();
		beam = FindObjectOfType<Beam>();

		cameraPosition = ball.transform.position;
		minimumBallPosition = ball.transform.position;

	}
	private void Update()
	{
		if (ball.transform.position.y < minimumBallPosition.y)
		{
			TrackBall();
			minimumBallPosition = ball.transform.position;
		};
	}
	private void TrackBall()
	{
		Vector3 beamPosition = beam.transform.position;
		beamPosition.y = ball.transform.position.y;
		cameraPosition = ball.transform.position;
		Vector3 direction = (beamPosition - ball.transform.position).normalized + directionOffset;
		cameraPosition -= direction * lenght;
		transform.position = cameraPosition;
		transform.LookAt(ball.transform);
		transform.position = new Vector3(transform.position.x, (transform.position.y - targetOffset), transform.position.z);
	}
}
