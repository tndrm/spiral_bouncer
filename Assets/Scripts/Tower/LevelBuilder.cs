using System.Collections.Generic;
using UnityEngine;

public class LevelBuilder : MonoBehaviour
{
	[SerializeField] private float additionalScale;
	[SerializeField] private GameObject beamPrefab;
	[SerializeField] private SpawnPlatform spawnPlatform;
	[SerializeField] private FinishPlatform finishPlatformPrefab;
	[SerializeField] Ball ball;


	private float startAndFinishAdditionalScale = 0.5f;
	public float BeamScaleY;
	private List<Platform> towerPlatforms;
	private GameObject beam;

	private void Start()
	{

		towerPlatforms = new List<Platform>();

	}

	public void Build(int platformCount, List<Platform> platforms)
	{
		BeamScaleY =platformCount / 2f + startAndFinishAdditionalScale + additionalScale / 2f;


		beam = Instantiate(beamPrefab, transform);
		beam.transform.localScale = new Vector3(1, BeamScaleY, 1);

		Vector3 spawnPosition = beam.transform.position;
		spawnPosition.y += beam.transform.localScale.y - additionalScale;

		Platform startPlatform = SpawnPlatform(spawnPlatform, ref spawnPosition, transform);

		Instantiate(ball, startPlatform.GetComponent<SpawnPlatform>().spawnPoint.position, Quaternion.identity);

		for (int i = 0; i < platformCount; i++)
		{
			SpawnPlatform(platforms[Random.Range(0, platforms.Count)], ref spawnPosition, transform);
		}

		SpawnPlatform(finishPlatformPrefab, ref spawnPosition, transform);
		
	}

	private Platform SpawnPlatform(Platform platform, ref Vector3 spawnPosition, Transform parent)
	{
		Platform pl = Instantiate(platform, spawnPosition, Quaternion.Euler(0, Random.Range(0, 360), 0), parent);

		pl.transform.localScale = Vector3.one;

		//towerPlatforms.Add(pl.GetComponent<Platform>());


		spawnPosition.y -= 1;
		return pl;
	}

	private void ClearScene()
	{
		foreach (Platform platform in towerPlatforms)
		{
			if (platform != null)
			{
				Destroy(platform);
			}
		}

		if (beam != null) Destroy(beam);
	}
}
