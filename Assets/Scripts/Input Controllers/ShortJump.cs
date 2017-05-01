using UnityEngine;
using System.Collections;

public class ShortJump : MonoBehaviour {

	public float speedJumpY;
    public Dash dash;

    public const float TIME_JUMP = 0.2f;
    private float currentTimeJumping;
    private Vector3 speedJump;

    private bool isJumping;
    private bool lastFrameWasJumping;

    private Transform tr;
    private Rigidbody rb;
    private Animator anim;

	void Awake () {
		tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();

        isJumping = false;
        lastFrameWasJumping = false;

        speedJump = new Vector3(0, speedJumpY, 0);
	}

	void Update () {
		if (Input.GetButtonDown ("Jump") && !IsJumping() && !dash.IsDashing) {
            Debug.Log("jump");
			StartJump();
		}

        if(lastFrameWasJumping && !IsJumping())
        {
            Debug.Log("run");
            lastFrameWasJumping = false;
            anim.SetTrigger("run");
        }

        actualizeTime(Time.deltaTime);
	}

	void StartJump() {

        currentTimeJumping = 0;
        isJumping = true;
        rb.useGravity = false;
        lastFrameWasJumping = true;

        anim.SetTrigger("jump");
	}

    void EndJump()
    {
        isJumping = false;
        rb.useGravity = true;

        //lastFrameWasJumping = true;
    }

	public bool IsJumping () {
        return isJumping || tr.position.y > 0.001;
	}

    private void actualizeTime(float deltaTime)
    {
        if (isJumping)
        {
            currentTimeJumping += deltaTime;

            if (currentTimeJumping >= TIME_JUMP)
            {
                EndJump(); 
            }
            else
            {
                tr.Translate(speedJump * deltaTime);
            }

        }
    }
}
