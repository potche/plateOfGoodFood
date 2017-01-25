using UnityEngine;
using System.Collections;

public class ConveyorBelt : MonoBehaviour {
    [Header("Move")]
    public float speed = 1.0f;
    private float moveHorizontal = 1.5f;
    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D collision) {
        /*
        if (collision.gameObject.tag != "Player")
            return;
        */
        // Assign velocity based upon direction of conveyor belt
        // Ensure that conveyor mesh is facing towards its local Z-axis
        Rigidbody2D rigidbody = collision.gameObject.GetComponent<Rigidbody2D>();

        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rigidbody.velocity = movement * speed;
    }
}
