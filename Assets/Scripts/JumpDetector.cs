using UnityEngine;
using System.Collections;

public class JumpDetector : MonoBehaviour {

    public bool IsJumping;
    public bool prepareJump;
    public float incertitude;


    private float distToTheGround;
    private bool isOnCollision;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 velocity = rb.velocity;

        if (-incertitude < velocity.x && velocity.x < incertitude
            && -incertitude < velocity.y && velocity.y < incertitude
            && -incertitude < velocity.z && velocity.z < incertitude)
            IsJumping = false;
	}
}
