using UnityEngine;
using System.Collections;

public class WaterScript : MonoBehaviour {

	public float waterSpeed;

	void Start () {
	
	}
	
	
	void Update () {
		
		transform.Translate(0,  -waterSpeed * Time.deltaTime, 0);
	}
}
