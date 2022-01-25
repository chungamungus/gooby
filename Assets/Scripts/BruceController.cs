using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruceController : MonoBehaviour {

    private Rigidbody2D rigidbody2d;
    private BoxCollider2D boxCollider2d;
    [SerializedField] private LayerMask layerMask;

    
    void Start() {
    }

    private void Awake() {
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        boxCollider2d = transform.GetComponent<BoxCollider2D>();
    }

    void Update() {

	Move();
	Jump();
	
	}

void Move() {

       float horizontal = Input.GetAxis("Horizontal");
       Vector2 position = transform.position;
       position.x = position.x + 1f * horizontal * Time.deltaTime;
       transform.position = position;
}
    
void Jump() {
if (IsGrounded() && Input.GetKeyDown(KeyCode.Space)) { 
	float jumpVelocity = 5f;
	rigidbody2d.velocity = Vector2.up*jumpVelocity;
	}
}

    private bool IsGrounded() {
        RaycastHit2D raycastHit2d = Physics2D.BoxCast(boxCollider2d.bounds.center, boxCollider2d.bounds.size, 0f, Vector2.down * 0.1f);
        return raycastHit2d.collider != null;
    }

	

} // end main class
