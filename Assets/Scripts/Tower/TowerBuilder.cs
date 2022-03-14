using UnityEngine;

public class TowerBuilder : MonoBehaviour
{
	[SerializeField] private int levelCount;
	[SerializeField] private float additionalScale;
	[SerializeField] private GameObject beamPrefab;
	[SerializeField] private SpawnPlatform spawnPlatform;
	[SerializeField] private FinishPlatform finishPlatform;
	[SerializeField] private Platform[] platform;


	private float startAndFinishAdditionalScale = 0.5f;
	public float BeamScaleY => levelCount / 2f + startAndFinishAdditionalScale + additionalScale / 2f;
	public int platformAmound => levelCount;

	private void Awake()
	{
		Build();
	}

	private void Build()
	{
		GameObject beam = Instantiate(beamPrefab, transform);
		beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

		Vector3 spawnPosition = beam.transform.position;
		spawnPosition.y += beam.transform.localScale.y - additionalScale;

		SpawnPlatform(spawnPlatform, ref spawnPosition, transform);

		for (int i = 0; i < levelCount; i++)
		{
			SpawnPlatform(platform[Random.Range(0, platform.Length)], ref spawnPosition, transform);
		}

		SpawnPlatform(finishPlatform, ref spawnPosition, transform);

	}

	private void SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
	{
		Platform pl = Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);
		pl.transform.localScale = Vector3.one;

		spawnPosition.y -= 1;
	}
}
