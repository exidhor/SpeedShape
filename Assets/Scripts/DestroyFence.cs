using UnityEngine;
using System.Collections;

public class DestroyFence : MonoBehaviour {

    public Dash dash;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.x < -0.5)
			GameObject.FindGameObjectWithTag ("GameController").GetComponent<GameController> ().isGameOver = true;
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "fence" && dash.IsReallyDashing)
        {
            collision.gameObject.GetComponent<BoxCollider>().enabled = false;
            //GameObject.Destroy(collision.gameObject);
            GameObject barreau0 = collision.gameObject.transform.GetChild(2).gameObject;
            barreau0.AddComponent<BoxCollider>();
            barreau0.AddComponent<Rigidbody>();
            GameObject barreau1 = collision.gameObject.transform.GetChild(3).gameObject;
            barreau1.AddComponent<Rigidbody>();
            barreau1.AddComponent<BoxCollider>();
        }

        if (collision.gameObject.tag == "rock")
            print("lose !!!!");
    }
}
