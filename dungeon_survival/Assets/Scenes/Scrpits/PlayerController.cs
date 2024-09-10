using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;
    bool isBorder; // 벽 충돌 플래그

    public VariableJoystick joy;

    Animator anim;

    void Awake()
    {
        anim=GetComponentInChildren<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //float xInput = Input.GetAxis("Horizontal");
        //float zInput = Input.GetAxis("Vertical");

        float xInput = joy.Horizontal;
        float zInput = joy.Vertical;

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;



        Vector3 newvel = new Vector3(xInput, 0f, zInput).normalized;

        if (!isBorder==true)
        {
            transform.position += newvel * speed * Time.deltaTime; 
        }

        anim.SetBool("isRunForward", newvel != Vector3.zero);

        transform.LookAt(transform.position + newvel);







        /*Vector3 newvel = new Vector3(xSpeed, 0f, zSpeed);
        playerRigidbody.velocity = newvel;

        /*if (xInput != 0 || zInput != 0)
        {
            transform.rotation = Quaternion.LookRotation(newvel);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }*/

        /*
        float xInput = joy.Horizontal;
        float zInput = joy.Vertical;

        float xSpeed = xInput * speed;
        float zSpeed = zInput * speed;

        Vector3 newVel = new Vector3(xSpeed, 0f, zSpeed);
        //playerRigidbody.velocity = newVel;

        if (xInput != 0f || zInput != 0f)
        {
            //playerRigidbody.velocity = newVel;
            playerRigidbody.transform.rotation = Quaternion.LookRotation(newVel);
            playerRigidbody.MovePosition(playerRigidbody.position + transform.forward * speed * Time.deltaTime);
        }*/

    }
    void StopToWall()
    {
        Debug.DrawRay(transform.position, transform.forward*1, Color.green);
        isBorder = Physics.Raycast(transform.position, transform.forward, 1, LayerMask.GetMask("Block"));
    }

    void FixedUpdate()
    {
        StopToWall();
    }

    public void Die()
    {
        gameObject.SetActive(false);

        GameManager gameManager = FindObjectOfType<GameManager>();
        gameManager.EndGame();
    }
}
