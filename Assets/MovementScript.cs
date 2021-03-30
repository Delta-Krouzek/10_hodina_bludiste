using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovementScript : MonoBehaviour
{

    public CharacterController controller;
    public float speed = 12f;

    public float jumpHeight = 3f;
    public Transform groundCheck;
    public float gravity = -9.18f * 2;
    public LayerMask mask;

    Vector3 velocity;
    bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        grounded = Physics.CheckSphere(groundCheck.position, 0.4f, mask);
        if (grounded && velocity.y < 2)
        {
            velocity.y = -2;
        }
        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        if (Input.GetButtonDown("Cancel"))
        {
            Application.Quit();
        }
    }
}
