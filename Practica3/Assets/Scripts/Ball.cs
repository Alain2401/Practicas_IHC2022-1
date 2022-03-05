using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Ball : MonoBehaviour
{
    public float ballSpeed = 5000;
    public float moveSpeed = 5000;
    


    void OnMouseDown() {
    GetComponent<Rigidbody>().AddForce(ballSpeed * transform.forward);
        gameObject.GetComponent<AudioSource>().Play();

    }

    void Update() {
        Vector3 move = Vector3.zero;
    move.x=Input.GetAxis("Horizontal");
        transform.position += move* moveSpeed * Time.deltaTime;
    }
}
