using UnityEngine;
using System.Collections;

public class WaterDestroyer : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		Destroy(collider.gameObject);
	}
}
