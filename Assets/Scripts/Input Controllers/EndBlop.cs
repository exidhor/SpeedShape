using UnityEngine;
using System.Collections;

public class EndBlop : MonoBehaviour {

    private Transform tr;
    private Rigidbody rb;

    void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
	
	}

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "fence")
        {
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().isGameOver = true;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
	}
}
