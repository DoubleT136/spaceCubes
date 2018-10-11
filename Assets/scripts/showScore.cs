using UnityEngine;
using UnityEngine.UI;

public class showScore : MonoBehaviour {

	public Text myText;
	// Use this for initialization
	void Start () {
		myText.text = "You Died.\nFinal Score:\n" + Time.timeSinceLevelLoad.ToString("0");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
