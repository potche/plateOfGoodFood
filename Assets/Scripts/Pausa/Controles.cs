using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Controles : MonoBehaviour {

    public bool silence = false;

    private Pausado MyPause;

    void Start() {

    }

    public void Resume() {
        SceneManager.UnloadScene("Pausa");
        GameObject[] go = SceneManager.GetSceneByName("Juego").GetRootGameObjects();
        for (int i = 0; i < go.Length; i++) {
            if (go[i].name == "PausedListener") {
                MyPause = go[i].GetComponent<Pausado>();
                MyPause.QuitarPausa();
            }
        }
        Time.timeScale = 1;
    }

    public void Restart() {
        print("REINICIANDO");
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Juego");
    }

    public void MainMenu() {
        print("MENU PRINCIPAL");
        Time.timeScale = 1;
        SceneManager.LoadSceneAsync("Intro", LoadSceneMode.Single);
    }

    public void Mute() {
        if (!silence) {
            silence = true;
            AudioListener.volume = 1 - AudioListener.volume;
            GameObject.Find("Settings").GetComponent<Text>().text = "encender sonido";
        } else {
            silence = false;
            AudioListener.volume = 1;
            GameObject.Find("Settings").GetComponent<Text>().text = "silenciar";
        }
    }
}