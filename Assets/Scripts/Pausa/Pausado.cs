using UnityEngine;
using System.Collections;

public class Pausado : MonoBehaviour {

	public bool paused = false;
	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void PonerPausa(){
		paused = true;
		player.SetActive (false);

		GameObject[] animales = GameObject.FindGameObjectsWithTag ("Animal");
		GameObject[] cereales = GameObject.FindGameObjectsWithTag ("Cereales");
		GameObject[] verduras = GameObject.FindGameObjectsWithTag ("Verduras");
		GameObject[] legumino = GameObject.FindGameObjectsWithTag ("Leguminosas");
		GameObject[] frutas = GameObject.FindGameObjectsWithTag ("Frutas");

		foreach (GameObject animal in animales) {
			//animal.SetActive (false);
		}
		foreach (GameObject cereal in cereales) {
			//cereal.SetActive (false);
		}
		foreach (GameObject verdura in verduras) {
			//verdura.SetActive (false);
		}
		foreach (GameObject legumbre in legumino) {
			//legumbre.SetActive (false);
		}
		foreach (GameObject fruta in frutas) {
			//fruta.SetActive (false);
		}
	}

	public void QuitarPausa(){
		paused = false;
		player.SetActive (true);

		GameObject[] animales = GameObject.FindGameObjectsWithTag ("Animal");
		GameObject[] cereales = GameObject.FindGameObjectsWithTag ("Cereales");
		GameObject[] verduras = GameObject.FindGameObjectsWithTag ("Verduras");
		GameObject[] legumino = GameObject.FindGameObjectsWithTag ("Leguminosas");
		GameObject[] frutas = GameObject.FindGameObjectsWithTag ("Frutas");

		foreach (GameObject animal in animales) {
			//animal.SetActive (true);
		}
		foreach (GameObject cereal in cereales) {
			//cereal.SetActive (true);
		}
		foreach (GameObject verdura in verduras) {
			//verdura.SetActive (true);
		}
		foreach (GameObject legumbre in legumino) {
			//legumbre.SetActive (true);
		}
		foreach (GameObject fruta in frutas) {
			//fruta.SetActive (true);
		}
	}
}
