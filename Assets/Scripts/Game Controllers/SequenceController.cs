using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SequenceController : MonoBehaviour {

	public List<GameObject> Sequences = new List<GameObject> ();
	[Range(0, 0)]
	public int DefaultSequenceIndex;

	[HideInInspector]
	public GameObject CurrentSequence;

	private int sequenceIndex;

	void Awake () {
		sequenceIndex = DefaultSequenceIndex;
		CurrentSequence = Sequences [sequenceIndex];
	}

	void Start () {
		//Instantiate (CurrentSequence, Vector3.zero, Quaternion.identity);
	}
}
