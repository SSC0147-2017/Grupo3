using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Utilities
{

	public float moveSpeed;
	private float speedMultiplier;
	private Animator animator;
	private Rigidbody2D body;
    public AudioSource BGM;
    private bool pausado = false;
    private bool controle = false;
    public float altura;
    public string CenaACarregar;

    public GameObject screen;

    void Start()
    {
        StartCoroutine(FadeOut(screen));
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody2D>();
        BGM = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        pausa();
        mudo();

        verMove = Input.GetAxisRaw("Vertical");
        horMove = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(verMove) == Mathf.Abs(horMove))
        {
            horMove = 0f;
            verMove = 0f;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            speedMultiplier = 1.5f;
        else speedMultiplier = 1f;

        body.velocity = new Vector2(horMove * moveSpeed * speedMultiplier, verMove * moveSpeed * speedMultiplier);

        if (controle == false)
        {
            animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        }

        // Abre a cena de customizacao se estiver dentro do laboratorio
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (transform.position.x > 19 &&
                transform.position.x < 23 &&
                transform.position.y > -49.4 &&
                transform.position.y < -39)
            {
                GetComponent<SalvaPosicaoPlayer>().SalvarLocalizacao();
                SceneManager.LoadScene(CenaACarregar);
                StartCoroutine(FadeIn(screen, "Customization"));
            }
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            GetComponent<SalvaPosicaoPlayer>().SalvarLocalizacao();
            SceneManager.LoadScene(CenaACarregar);
            StartCoroutine(FadeIn(screen, "BattleScene"));
        }

    }

    void pausa()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (controle == false)
            {
                animator.SetFloat("MoveX", 0);
                animator.SetFloat("MoveY", 0);
                BGM.Pause();
                Time.timeScale = 0;
                controle = true;
            }

            else
            {

                BGM.UnPause();
                Time.timeScale = 1;
                controle = false;
            }
        }
    }

    public void mudo()
    {
        if (Input.GetKeyDown("m"))
        {
            BGM.mute = !BGM.mute;
        }
    }

    private float verMove, horMove;



    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("engrenagem"))
        {
            if (Input.GetKeyDown("z"))
            {
                other.gameObject.SetActive(false);
            }
        }
    }

    void OnGUI()
    {
        //Create a horizontal Slider that controls volume levels. Its highest value is 1 and lowest is 0
        altura = GUI.HorizontalSlider(new Rect(25, 25, 200, 60), altura, 0.0F, 1.0F);
        //Makes the volume of the Audio match the Slider value
        BGM.volume = altura;
    }

}
