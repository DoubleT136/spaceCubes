using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public Rigidbody rb;
	public float forwardForce;
	public float sidewaysForce;
	public Material[] redMats;
	public Material[] blueMats;
	Renderer r;

	bool moveLeft = false;
	bool moveRight = true;
	bool isAlive = true;
	public bool isRed = true;

	// Use this for initialization
	void Start () {
		r = GetComponent<Renderer>();
	}
	
	void Update() {
		if (Input.GetKey("d")) {
			moveLeft = true;
		} else {
			moveLeft = false;
		}
		
		if (Input.GetKey("a")) {
			moveRight = true;
		} else {
			moveRight = false;
		}

		if (Input.GetKeyDown("e")) {
			if (isRed) {
				r.materials = blueMats;
				isRed = false;
			} else {
				r.materials = redMats;
				isRed = true;
			}
		}
	}

	void FixedUpdate () {
		if (isAlive) {
			if (moveLeft) {
				rb.AddForce(sidewaysForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
			} else if (moveRight) {
				rb.AddForce(-sidewaysForce * Time.deltaTime, 0f, 0f, ForceMode.VelocityChange);
			}
			if (rb.position.y < 0f) {
				FindObjectOfType<gameManager>().EndGame();
			}
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if ((other.tag == "redObs" && !isRed) || (other.tag == "blueObs" && isRed)) {
			isAlive = false;
			FindObjectOfType<gameManager>().EndGame();
		}
	}
}
