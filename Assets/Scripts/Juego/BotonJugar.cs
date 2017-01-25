using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class BotonJugar : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown() {
        //Camera.main.GetComponent<AudioSource>().Stop();
        Debug.Log("Jugar");
        Time.timeScale = 1;
        GetComponent<AudioSource>().Play();
        Invoke("CargarNivel", GetComponent<AudioSource>().clip.length);
    }

    void CargarNivel() {
        SceneManager.LoadScene("Juego");
    }

}
