using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text TimeText;

	[HideInInspector]
	public float TimeElapsed = 0;

	private float startTime;
	private bool counting;

	void Start () {
		SetText ();
		StartCount ();
	}

	void Update () {
		if (counting) {
			TimeElapsed += Time.deltaTime;
		}
		SetText ();
	}

	void StartCount () {
		counting = true;
	}

	void StopCount() {
		counting = false;
	}

	void SetText () {
		TimeText.text = "Time : " + (int)(TimeElapsed) + " seconds";
	}
}
