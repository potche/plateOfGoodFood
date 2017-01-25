using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {
    public Text TextScore;
    public Text TextGrupo;
    public Text TextCombo;
	public Text TextTimer;
    public GameObject Pause;
    public GameObject ImagenTipoGrupo;
    public Sprite[] arraySprites;
    public GameObject Jugador;
    public Sprite[] arraySpritesJugador;

    public int score;
    private int combo;
    private int count;
    public int puntuacionMaxima;

    public GameObject camaraGameOver;
    private AudioSource[] sounds;
    private AudioSource ouch;
    private AudioSource ambler;
    private AudioSource alarma;
    private AudioSource ticktack;
    private Animator ComboAnimator;
    private Animator CambioTipoAnimator;
    private Animator CambioJugadorAnimator;
    private int indexTipoGrupo;
    private int indexTipoGrupoJugador;

    public AudioClip gameOverClip;

    private ArrayList grupos = new ArrayList{ "Animal","Cereales","Verduras","Leguminosas","Frutas"};
    public string tipoGrupo;
    public int timer = 10;
    private int myTimer;

    private bool gameOver;
    private bool restart;

    // Use this for initialization
    void Start () {
        gameOver = false;
        restart = false;

        myTimer = timer;
        StartCoroutine(Timer());

        GrupoAlimenticio();
        UpdateTipoGrupo();
        IndexTipoGrupo();
        score = 0;
        combo = 1;
        count = 0;
        UpdateScore();
        UpdateCombo();
        DrawTimer ();

        Sounds();

        ComboAnimator = TextCombo.GetComponent<Animator>();
        CambioTipoAnimator = TextGrupo.GetComponent<Animator>();
        CambioJugadorAnimator = Jugador.GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {
	}

    public void AddScore(int newScoreValue) {
        score += newScoreValue * combo;
        UpdateScore();
    }

    public void AddCount(int newCount) {
        count = (count+1) * newCount;

        switch (count) {
            case 0:
                combo = 1;
                break;
            case 1:
                combo = 1;
                break;
            case 2:
                combo = 1;
                break;
            case 3:
                combo = 2;
                ComboAnimator.SetTrigger("combo");
                break;
            case 6:
                combo = 3;
                ComboAnimator.SetTrigger("combo");
                break;
            case 9:
                combo = 4;
                ComboAnimator.SetTrigger("combo");
                break;
        }

        UpdateCombo();
    }

    void UpdateScore() {
        TextScore.text = "Puntos: " + score;
    }

    void UpdateCombo() {
        TextCombo.text = "x" + combo;
    }

    void UpdateTipoGrupo() {
        TextGrupo.text = tipoGrupo;
        ImagenTipoGrupo.GetComponent<Image>().sprite = arraySprites[indexTipoGrupo];
        Jugador.GetComponent<SpriteRenderer>().sprite = arraySpritesJugador[indexTipoGrupoJugador];
    }

    void GrupoAlimenticio() {
        if (grupos.Count > 0) {
            int index = Random.Range(0, grupos.Count);
            string grupo = (string)grupos[index];
            grupos.RemoveAt(index);
            
            tipoGrupo = grupo;
            IndexTipoGrupo();
        } else {
            tipoGrupo = "";
            EndGame();

        }
        
    }

    void IndexTipoGrupo() {
        indexTipoGrupo = System.Array.FindIndex(arraySprites, s => s.name == tipoGrupo);
        indexTipoGrupoJugador = System.Array.FindIndex(arraySpritesJugador, s => s.name == tipoGrupo);
    }

    IEnumerator Timer() {
        yield return new WaitForSeconds(1f);
        myTimer--;
        if (!gameOver) {
            switch (myTimer) {
                case 0:
                    myTimer = timer;
                    GrupoAlimenticio();
                    UpdateTipoGrupo();
                    TextTimer.color = new Color(255f, 255f, 255f);
                    alarma.Stop();
                    break;
                case 1:
                    CambioJugadorAnimator.SetTrigger("Cambio");
                    CambioTipoAnimator.SetTrigger("Cambio");
                    TextTimer.color = new Color(255f, 0f, 0f);
                    ticktack.Stop();
                    alarma.Play();
                    break;
                case 2:
                    TextTimer.color = new Color(255f, 255f, 255f);
                    break;
                case 3:
                    TextTimer.color = new Color(255f, 0f, 0f);
                    break;
                case 4:
                    TextTimer.color = new Color(255f, 255f, 255f);
                    break;
                case 5:
                    TextTimer.color = new Color(255f, 0f, 0f);
                    ticktack.Play();
                    break;
            }
          
            StartCoroutine(Timer());
            DrawTimer();
        } else {
            TextTimer.text = "";
        }
		
    }

	void DrawTimer(){
		string tiempoRestante = "";
		if (myTimer.ToString ().Length == 1) {
			tiempoRestante = "00:0" + myTimer;
		} else {
			tiempoRestante = "00:" + myTimer;
		}
		TextTimer.text = tiempoRestante;
	}

    void Sounds() {
        sounds = GetComponents<AudioSource>();
        ouch = sounds[0];
        ambler = sounds[1];
        alarma = sounds[2];
        ticktack = sounds[3];
    }

    void EndGame() {
        
        gameOver = true;

        TextScore.text = "";
        TextCombo.text = "";
        TextTimer.text = "";
        ImagenTipoGrupo.SetActive(false);
        Pause.SetActive(false);

        ouch.Stop();
        ambler.Stop();
        ambler.clip = gameOverClip;
        ambler.volume = 0.5f;
        ambler.loop = false;
        ambler.Play();
        camaraGameOver.SetActive(true);
        
    }
}
