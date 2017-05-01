using UnityEngine;
using System.Collections;

public class WaterWheelController : MonoBehaviour {

	public float rotateSpeed;
	
	void Start () {
	
	}
	
	void Update () {
		transform.Rotate(Vector3.right * -rotateSpeed * Time.deltaTime, Space.World);
	}
}
