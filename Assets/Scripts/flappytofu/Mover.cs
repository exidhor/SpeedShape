using UnityEngine;
using System.Collections;

public class Mover : MonoBehaviour {

	public float Speed;

	private Rigidbody rb;

	void Start () {
		rb = GetComponent<Rigidbody> ();
	}

	void Update () {
		rb.velocity = Vector3.left * Speed;	
	}
}
