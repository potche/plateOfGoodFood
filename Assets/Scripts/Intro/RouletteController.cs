using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RouletteController : MonoBehaviour {

	public float timer = 20;
	public float velocity = 10;
	public Text countdown;
	public GameObject cover;

	private Rigidbody2D rbRuleta;
	private Vector2 posRuleta;
	private Animator anim;
	private bool moveRuleta = false;
	private float myTimer;

	// Use this for initialization
	void Start () {
		myTimer = timer;
		//rbRuleta = gameObject.GetComponent<Rigidbody2D> ();
		//anim = gameObject.GetComponent<Animator> ();
		DrawTimer ();
		StartCoroutine (Timer ());
	}
	
	// Update is called once per frame
	void Update () {
		//posRuleta = rbRuleta.position + new Vector2 (0, velocity) * Time.fixedDeltaTime;
	}

	void FixedUpdate () {
		if (moveRuleta) {
			//rbRuleta.MovePosition (posRuleta);

			moveRuleta = false;
			//anim.SetTrigger ("Spin");
			StartCoroutine (StopRuleta ());

		}

		//if (rbRuleta.position.y >= 0) {
			//moveRuleta = false;
			//anim.SetTrigger ("Spin");
			//StartCoroutine (StopRuleta ());
		//}
	}

	IEnumerator Timer(){
		yield return new WaitForSeconds(1f);
		myTimer--;
		DrawTimer ();
		if (myTimer == 0) {
			moveRuleta = true;
			myTimer = 20f;
		}
		StartCoroutine (Timer ());
	}

	IEnumerator StopRuleta(){
		float tiempo = Random.Range (3f, 7f);
		yield return new WaitForSeconds (tiempo);
		//anim.Stop ();

		myTimer = timer;
		StartCoroutine (Timer ());
	}

	void DrawTimer(){
		string tiempoRestante = "";
		if (myTimer.ToString ().Length == 1) {
			tiempoRestante = "00:0" + myTimer;
		} else {
			tiempoRestante = "00:" + myTimer;
		}
		countdown.text = tiempoRestante;
	}
}
