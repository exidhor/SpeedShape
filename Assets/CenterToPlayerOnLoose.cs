using UnityEngine;
using System.Collections;

public class CenterToPlayerOnLoose : MonoBehaviour {

	public float Speed;

	private GameObject player;
	private bool moveToPlayer = false;
	private Vector3 targetPosition;

	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	public void MoveToPlayer() {
		moveToPlayer = true;
	}

	void Update () {
		if (player == null) {
			moveToPlayer = false;
		}
		if (moveToPlayer && transform.position.x > player.transform.position.x) {
			transform.Translate (-Speed, 0, 0);
		}
	}
}
