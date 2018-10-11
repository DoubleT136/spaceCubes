using UnityEngine;

public class moveObs : MonoBehaviour {
	public Rigidbody rb;
	public float forwardForce;

	private void FixedUpdate() {
		rb.AddForce(0f, 0f, -forwardForce * Time.deltaTime, ForceMode.VelocityChange);
	}
}
