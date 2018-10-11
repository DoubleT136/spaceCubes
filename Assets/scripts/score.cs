using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour {

	public Transform player;
	public Text scoreText;

	// Update is called once per frame
	void Update () {
		scoreText.text = Time.timeSinceLevelLoad.ToString("0");
	}
}
