using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desplazaDerecha : MonoBehaviour {

	private Rigidbody2D rb;
	[Header("Move")]
	public float speed = 2.0f;
	private float moveHorizontal = 1.5f;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		

		Vector2 movement = new Vector2(moveHorizontal, 0.0f);
		rb.velocity = movement * speed;

	

	}


}
