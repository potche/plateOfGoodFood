using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class AbreCortinas : MonoBehaviour {
	public GameObject cortinaIzq;
    public GameObject cortinaDer;
    public GameObject presentador;
    public GameObject player;
	public GameObject letrero;
	public Camera myCamera;
    public float speed = 10f;
	public float velocity = 16f;

    private Vector3 positionDer;
    private Vector3 positionIzq;
    private Vector2 positionPlayer;
	private Vector2 positionLetrero;
    private bool openCurtains;
	private bool isZoomed = false;
	private bool closing = false;
    private Rigidbody2D rbDer;
    private Rigidbody2D rbIzq;
    private Rigidbody2D rbPlayer;
	private Rigidbody2D rbLetrero;
    private Animator anim;
	private float currentZoom = 12f;
	private float minZoom = 8f;

    // Use this for initialization
    void Start () {
        rbDer = cortinaDer.GetComponent<Rigidbody2D>();
        rbIzq = cortinaIzq.GetComponent<Rigidbody2D>();
        //rbPlayer = player.GetComponent<Rigidbody2D>();
        //anim = player.GetComponent<Animator>();
		rbLetrero = letrero.GetComponent<Rigidbody2D> ();
    }

    void Update()
    {
        positionDer = rbDer.position + new Vector2(velocity, 0) * Time.fixedDeltaTime;
        positionIzq = rbIzq.position + new Vector2(-velocity, 0) * Time.fixedDeltaTime;
        //positionPlayer = rbPlayer.position + new Vector2(velocity, 0) * Time.fixedDeltaTime;
		positionLetrero = rbLetrero.position + new Vector2 (0, velocity) * Time.fixedDeltaTime;
    }

    void FixedUpdate () {
        if (openCurtains)
        {
            rbDer.MovePosition(positionDer);
            rbIzq.MovePosition(positionIzq);
            //rbPlayer.MovePosition(positionPlayer);
			rbLetrero.MovePosition (positionLetrero);
			if (!closing) {
				StartCoroutine (StopCurtains ());
			}

        }

		if (isZoomed) {
			if (currentZoom >= minZoom) {
				myCamera.orthographicSize = currentZoom;
				currentZoom = currentZoom - 0.1f;
				if (currentZoom <= minZoom) {
					StartCoroutine(LoadLevel());
				}
			}
		}
	}

    void OnMouseDown() {
        AbrirCortinas();
    }

    public void AbrirCortinas()
    {
        openCurtains = true;
		isZoomed = true;
		//gameObject.GetComponent<Button> ().GetComponent<Image> ().enabled = false;
		//gameObject.GetComponent<Text> ().text = "";
    }

    IEnumerator StopCurtains()
    {
		closing = true;
        yield return new WaitForSeconds(speed);
        presentador.SetActive(false);
        
        openCurtains = false;
		isZoomed = true;
    }

	IEnumerator LoadLevel()
	{
		yield return new WaitForSeconds(1f);
		SceneManager.LoadSceneAsync("Juego", LoadSceneMode.Single);
	}

}
