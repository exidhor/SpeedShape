using UnityEngine;
using System.Collections;

public class FlyUp : MonoBehaviour {

	public int FlyStrengh;

	private Rigidbody rb;
	private Animator anim;
	private AudioSource flap;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		flap = GetComponent<AudioSource> ();
	}

	void Update () {
		if (Input.GetButtonDown ("Jump")) {
			Up ();
			anim.SetTrigger ("FlyUp");
			flap.Play ();
		}
	}

	void Up () {
		Vector3 force = new Vector3 (0, FlyStrengh, 0);
		rb.AddForce (force, ForceMode.VelocityChange);
	}
}
