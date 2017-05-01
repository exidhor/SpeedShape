using UnityEngine;
using System.Collections;

public class Dash : MonoBehaviour
{
    public float DeltaSpeedDash = 5;
    public float DeltaSpeedCD = 100;
    public ShortJump shortJump;

    private Vector3 classicVelocity;
    private Vector3 startingPosition;
    private Transform tr;
    private Animator anim;

    private bool isDashing;
    private bool isOnCD;

    public bool IsDashing
    {
        get { return isDashing || isOnCD; }
    }

    public bool IsReallyDashing
    {
        get { return isDashing; }
    }

    private Vector3 speedDash;
    private Vector3 speedCD;

    private const float TIME_DASH = 0.5f; // in second
    private float currentTimeDashing;

    private const ForceMode mode = ForceMode.Impulse;

    void Awake()
    {
        tr = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        isDashing = false;
        isOnCD = false;

        currentTimeDashing = 0;

        speedDash = new Vector3(0, 0, DeltaSpeedDash);
        speedCD = new Vector3(0, 0, -DeltaSpeedCD);
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && !isDashing && !isOnCD)
        {
            StartDash();
        }
        
        actualizeTime(Time.deltaTime);
    }

    private void StartDash()
    {
		GetComponent<AudioSource> ().Play ();
        isDashing = true;
        
        startingPosition = tr.position;

        anim.SetTrigger("Dash");
    }

    private void EndDash()
    {
        isDashing = false;
        isOnCD = true;

        anim.SetTrigger("run");
        anim.speed = 0.5f;
    }

    private void EndCD()
    {
        isOnCD = false;
        tr.position = new Vector3(startingPosition.x, tr.position.y, tr.position.z);
        anim.speed = 1;
    }

    private bool isFinish()
    {
        return tr.position.x <= startingPosition.x;
    }

    private void actualizeTime(float deltaTime)
    {
        if(isDashing)
        {
            currentTimeDashing += deltaTime;
            if (currentTimeDashing >= TIME_DASH)
            {
                EndDash();
                currentTimeDashing = 0;
            }
            else
            {
                tr.Translate(speedDash * deltaTime);
            }
                
        }
        else if(isOnCD)
        {
            if (isFinish())
            {
                EndCD();
            }
            else
            {
                tr.Translate(speedCD * deltaTime);
            }
        }
    }
}
