using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotater : MonoBehaviour
{

    private CharacterController characterController;

    public float rotateSpeed = 200.0f;
    public float moveSpeed = 5.0f;
    void Start()
    {
       

    }

    // Update is called once per frame
    void Update()
    {
        //Rotates the Mouse left and Right 
        if (Input.GetKey(KeyCode.A))
            transform.Rotate(-Vector3.up * rotateSpeed * Time.deltaTime);

        if (Input.GetKey(KeyCode.D))
            transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime);
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        
        
    }
}
