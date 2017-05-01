using UnityEngine;
using System.Collections;

public class CameraScroller : MonoBehaviour {

	public float Speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.right * Speed * Time.deltaTime;
	}
}
