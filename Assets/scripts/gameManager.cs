using UnityEngine;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour {

	bool gameEnded = false;
	public GameObject completeLevelUI;
	public GameObject redObs;
	public GameObject blueObs;
	float timeToSpawn = 0f;
	public Vector3[] spawnPoints;

	public void CompleteLevel() {
		completeLevelUI.SetActive(true);
	}

	public void EndGame () {
		if (!gameEnded) {
			gameEnded = true;
			completeLevelUI.SetActive(true);
			Invoke("Restart", 1.5f);
		}
	}

	private void Update() {
		if (Time.timeSinceLevelLoad >= timeToSpawn)
		{
			SpawnBlocks();
			timeToSpawn = Time.timeSinceLevelLoad + Random.Range(0.25f, 2f);
		}
	}

	void Restart() {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	void SpawnBlocks() {
		for (int i = 0; i < spawnPoints.Length; i++)
				{
					int rand = Random.Range(0, 3);
					if (rand == 1)
					{
						Instantiate(redObs, spawnPoints[i], Quaternion.identity);
					} else if (rand == 2) {
						Instantiate(blueObs, spawnPoints[i], Quaternion.identity);
					}
				}
		}
}