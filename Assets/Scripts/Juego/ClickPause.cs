using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ClickPause : MonoBehaviour {

	private Pausado MyPause;

	// Use this for initialization
	void Start () {
		MyPause = GameObject.Find ("PausedListener").GetComponent<Pausado> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PausarJuego()
	{
		if (!MyPause.paused) {
			MyPause.PonerPausa ();
			StartCoroutine (LoadLevel ());
		}
	}

	IEnumerator LoadLevel()
	{
		yield return new WaitForSeconds(0.3f);
		Time.timeScale = 0;
		SceneManager.LoadSceneAsync("Pausa", LoadSceneMode.Additive);
		//gameObject.SetActive (false);
		//GameObject.Find ("Jugador").SetActive (false);
	}

}
