using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public float TimeBeforeFirstWave;
	public float TimeBetweenWaves;
	[Range(1, 5)]
	public int HeightOfPassage; // number of mobs
	public List<GameObject> Mobs;

	void Start () {
		StartCoroutine (SpawnWaves());
	}

	void Update () {
	
	}

	IEnumerator SpawnWaves () {
		float merge = 5;
		float halfSize = transform.lossyScale.y / 2;
		float mobYSize = Mobs [0].transform.lossyScale.y;
		mobYSize = 1;
		float minY = transform.position.y - halfSize + mobYSize / 2;
		float maxY = transform.position.y + halfSize - mobYSize / 2;
		int nbMaxBirds = Mathf.RoundToInt((maxY - minY) / mobYSize);
		yield return new WaitForSeconds (TimeBeforeFirstWave);
		while (true) {
			int yPosOfPassage = Random.Range(0, nbMaxBirds - HeightOfPassage);
			for (int i = 0; i < nbMaxBirds; i++) {
				// HeightOfPassage -1 because the passage is minimum 1 height
				if (i >= yPosOfPassage && i <= yPosOfPassage + HeightOfPassage - 1) {
					continue;
				}
				float x = Random.Range (transform.position.x - transform.lossyScale.x, transform.position.x + transform.lossyScale.x);
				Vector3 position = new Vector3 (x, maxY - i * (mobYSize + 0.3f), transform.position.z);
				GameObject mob = Instantiate (Mobs [0], position, Quaternion.Euler(new Vector3(0, -90, 0))) as GameObject;
				mob.GetComponent<Animator> ().SetFloat("Speed", Random.Range(1, 3));
			}
			yield return new WaitForSeconds (TimeBetweenWaves);
		}
	}
}
