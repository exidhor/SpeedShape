using UnityEngine;
using System.Collections;

public class DisplayFixedBackground : MonoBehaviour {

	public Material BackgroundMaterial;

	private GameObject Background;

	void Awake () {
		Background = GameObject.FindGameObjectWithTag ("Background");
	}

	void Start() {
		Background.GetComponent<MeshRenderer> ().material = BackgroundMaterial;
	}

	void Update() {
		Vector3 newPosition = new Vector3 (Camera.main.transform.position.x, Background.transform.position.y, Background.transform.position.z);
		Background.transform.position = newPosition;
	}
}
