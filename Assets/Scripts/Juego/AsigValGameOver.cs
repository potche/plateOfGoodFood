using UnityEngine;
using System.Collections;

public class AsigValGameOver : MonoBehaviour {

    public TextMesh total;
    public TextMesh record;

    public GameController gameController;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnEnable() {
        //Debug.Log("puntuacionMaxima: " + gameController.puntuacionMaxima);
        total.text = gameController.score.ToString();
        StartCoroutine(stopGame());
        /*
        if (EstadoJuego.estadoJuego != null) {
            record.text = EstadoJuego.estadoJuego.puntuacionMaxima.ToString();
        }
        */
    }

    IEnumerator stopGame() {
        yield return new WaitForSeconds(2f);
        Time.timeScale = 0;
    }
}
