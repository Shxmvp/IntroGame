using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour {

    public Vector2 moveValue;
    public float speed;
    private int count;

    void OnMove(InputValue value) { //method captures input
        moveValue = value.Get<Vector2>(); 
    }

    void FixedUpdate() { //FixedUpdate() for when there are physics operations
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y); //form a vector with the direction the ball should move, according to input received

        GetComponent<Rigidbody>().AddForce(speed * Time.fixedDeltaTime * movement);
    }

    private void Start() {
        count = 0;

    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "PickUp") {
            other.gameObject.SetActive(false);
            count++;
        }
    }

    
}
