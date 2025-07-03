using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float baseSpeed = 20f;
    [SerializeField] int startingLives = 3;

    Rigidbody2D rb2d;
    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    int score = 0;
    int lives;

    float rotationTracker = 0f;
    float lastZRotation = 0f;
    bool isGrounded = false;
    UIManager uiManager;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
        uiManager = FindObjectOfType<UIManager>();
        lastZRotation = transform.eulerAngles.z;
    }

    void Update()
    {
        if (canMove)
        {
            Rotate();
            RespondToBoost();
            CheckFlipInAir();
        }
    }
    void CheckFlipInAir()
    {
        if (!isGrounded)
        {
            float currentZ = transform.eulerAngles.z;
            float delta = Mathf.DeltaAngle(lastZRotation, currentZ);
            rotationTracker += Mathf.Abs(delta);
            lastZRotation = currentZ;

            if (rotationTracker >= 360f)
            {
                rotationTracker = 0f;
                uiManager.UpdateScore(1);
                Debug.Log("+1 mark");
            }
        }
        else
        {
            rotationTracker = 0f;
            lastZRotation = transform.eulerAngles.z;
        }
    }


    void Rotate()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else
        {
            surfaceEffector2D.speed = baseSpeed;
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
