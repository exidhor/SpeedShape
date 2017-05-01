using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		if (other.CompareTag ("Player")) {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().isGameOver = true;
			return;
		}
		Destroy (other.gameObject);
	}
}
