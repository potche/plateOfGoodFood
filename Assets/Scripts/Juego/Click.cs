using UnityEngine;
using System.Collections;

public class Click : MonoBehaviour {
    private int scoreValue = 10;
    private GameController gameController;

    public GameObject explosion;
    float x = -110;

    bool down = false;
	// Use this for initialization
	void Start () {
        
        GameObject gameControllerObject = GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null) {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameController == null) {
            Debug.Log("Cannot find 'GameController' script");
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (down) {
            Down();
        }
    }

    void FixedUpdate() {
        
        
    }

    void OnMouseDown() {
        if (!down) {
            down = true;
            Instantiate(explosion, transform.position, transform.rotation);
            
            if (this.tag == gameController.tipoGrupo) {
                gameController.AddScore(scoreValue);
                GetComponent<AudioSource>().Play();
                gameController.AddCount(1);
            } else {
                gameController.GetComponent<AudioSource>().Play();
                gameController.AddCount(0);
            }
        }
    }

    void Down() {
        if (transform.eulerAngles.x == 0 || transform.eulerAngles.x <= 80) {
            transform.Rotate(-Vector3.right, x * Time.deltaTime);
        }
    }
}
