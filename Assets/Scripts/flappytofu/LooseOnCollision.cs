using UnityEngine;
using System.Collections;

public class LooseOnCollision : MonoBehaviour {

	void OnCollisionEnter() {
		GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().isGameOver = true;
	}
}
