using UnityEngine;
using System.Collections;

public class GeneratorController : MonoBehaviour {
    public GameObject[] obj;
    public float timeGenetator = 1.5f;
    
    private bool pause = false;
	// Use this for initialization
	void Start () {
        //llama a la case NotificationCenter el cual debuelve la alerta invocando la funcion
        Encendido();
        //NotificationCenter.DefaultCenter().AddObserver(this, "Apagado");
    }
	
	// Update is called once per frame
	void Update () {
	
	}

    void Encendido() {
        Generate();
    }

    void Generate() {
        if (!pause) {
            Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
            Invoke("Generate", timeGenetator);
        }
    }

    void Apagado() {
        pause = true;
    }
}
