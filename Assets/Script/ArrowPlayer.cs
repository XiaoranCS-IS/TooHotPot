using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPlayer : MonoBehaviour
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

        if (Input.GetKey(KeyCode.UpArrow))
        {
            movementZ = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            movementZ = -1;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            movementX = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            movementX = 1;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)||Input.GetKeyUp(KeyCode.DownArrow))
        {
            movementZ = 0;
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)||Input.GetKeyUp(KeyCode.RightArrow))
        {
            movementX = 0;
        }

        if (movementX == 0 && movementZ == 0){
            runEffect.Stop();
        }
        else{
            runEffect.Play();
        }

        if (moveDirection != Vector3.zero) {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
}
