using UnityEngine;
using System.Collections;

public class BlopJump : MonoBehaviour {

    public float distancePerFrame;
    public float maxCounterY;
    public float distanceRightJump;
    public float minCounter;
    public JumpDetector jumpDetector;
    public float incertitude;

    private float counterJumpPressed;
    private Rigidbody rb;
    private Animator anim;
    private bool lastFrameWasJumping;
    private bool lastFrameWasNotJumping;

	// Use this for initialization
	void Start () {
        counterJumpPressed = 0;
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        anim = anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        lastFrameWasJumping = false;
        lastFrameWasNotJumping = true;
	}
	
	// Update is called once per frame
	void Update () {

        if(Input.GetButton ("Jump") && !IsJumping())
        {
            if (lastFrameWasNotJumping)
                anim.SetTrigger("prepareJump");
            counterJumpPressed += Time.deltaTime;
            lastFrameWasJumping = true;
            lastFrameWasNotJumping = false;
        }
        else if(counterJumpPressed > 0 && lastFrameWasJumping)
        {
            Jump();
            lastFrameWasJumping = false;
        }
        else
        {
            anim.SetTrigger("run");
            lastFrameWasNotJumping = true;
        }
	}

    private void Jump()
    {
        jumpDetector.prepareJump = true;
        anim.SetTrigger("Jump");
        if (counterJumpPressed > maxCounterY)
        {
            counterJumpPressed = maxCounterY;
        }

        if(counterJumpPressed < minCounter)
        {
            counterJumpPressed = minCounter;
        }

        //rb.AddForce(0, distancePerFrame * counterJumpPressed, 0);
        rb.velocity = new Vector3(distanceRightJump, distancePerFrame * counterJumpPressed, 0);
        counterJumpPressed = 0;
    }

    private bool IsJumping()
    {
        Vector3 velocity = rb.velocity;

        return velocity.y < -0.5;
    }
}
