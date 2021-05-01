using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public bool isEquipped;
    public ParticleSystem runEffect;

    private float movementX;
    private float movementZ;

    
    // Start is called before the first frame update
    void Start()
    {
        movementX = 0;
        movementZ = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // float xDirection = Input.GetAxis("Horizontal");
        // float zDirection = Input.GetAxis("Vertical");

        Vector3 moveDirection = new Vector3(movementX, 0.0f, movementZ);
        // Vector3 moveDirection = new Vector3(xDirection, 0.0f, zDirection);
        // moveDirection.Normalize();

        transform.Translate(moveDirection * speed * Time.deltaTime, Space.World);

        if (Input.GetKey(KeyCode.W))
        {
            movementZ = 1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            movementZ = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            movementX = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            movementX = 1;
        }

        if (Input.GetKeyUp(KeyCode.W)||Input.GetKeyUp(KeyCode.S))
        {
            movementZ = 0;
        }

        if (Input.GetKeyUp(KeyCode.A)||Input.GetKeyUp(KeyCode.D))
        {
            movementX = 0;
        }

        if (movementX == 0 && movementZ == 0){
            runEffect.Stop();
        }
        else{
            runEffect.Clear();
            runEffect.Play();
        }

        if (moveDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
