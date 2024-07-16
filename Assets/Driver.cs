using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    /*
        -SerializeField to make variable available in the inspector, 
        if you change the value in inspector, then will be coverd. but the initial value will be
        the value that you set in there.
    */
    [SerializeField] float steerSpeed = 1f;
    [SerializeField] float moveSpeed = 20f;
    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;


    /*
        -transform is class
        -Rotate is object rotate
        -translate is move object to xyz
        -float should add 'f' in the end

        -Input.GetAxis() 为obj按上键鼠上下左右
        -Time.deltaTime Unity can tell us how long each frame took to execute.
    */
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0,0,-steerAmount);
        transform.Translate(0,moveAmount,0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "speedUp"){
            moveSpeed = boostSpeed;
        }
    }

    void OnCollisionEnter2D(Collision2D other) {
        moveSpeed = slowSpeed;
    }
}
