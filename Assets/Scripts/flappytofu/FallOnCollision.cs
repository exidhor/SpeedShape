using UnityEngine;
using System.Collections;

public class FallOnCollision : MonoBehaviour {

	public float FallForce;
	public float SpeedRotation;

	private Rigidbody rb;
	private bool falling = false;

	void Awake () {
		rb = GameObject.FindGameObjectWithTag ("Player").GetComponent<Rigidbody> ();
	}

	void OnCollisionEnter() {
		GetComponent<FlyUp> ().enabled = false;
		Vector3 force = rb.velocity;
		force.y = FallForce;
		rb.velocity = force;
		falling = true;
//		Camera.main.GetComponent<CenterToPlayerOnLoose> ().MoveToPlayer ();
	}

	void Update () {
		if (falling && transform.rotation != Quaternion.Euler(new Vector3(-90, 90,0))) {
			transform.Rotate (new Vector3 (-SpeedRotation, 0, 0));
		}
	}
}
