using UnityEngine;
using System.Collections;

public class PositionedNearPlayer : MonoBehaviour {

	public GameObject textLocation;

	void Update() {
		if (textLocation != null) {
			Vector3 viewPortPos = Camera.main.WorldToViewportPoint (textLocation.transform.position);
			gameObject.GetComponent<RectTransform> ().anchorMin = viewPortPos;
			gameObject.GetComponent<RectTransform> ().anchorMax = viewPortPos;
		} else {
			textLocation = GameObject.Find ("PositionText");
		}
	}
}
