using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float speedMultiplier;
	private Animator animator;
	private Rigidbody2D body;

    private float verMove, horMove;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        verMove = Input.GetAxisRaw("Vertical");
        horMove = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(verMove) == Mathf.Abs(horMove)) {
            horMove = 0f;
            verMove = 0f;
        }

        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			speedMultiplier = 1.5f;
		else speedMultiplier = 1f;

        body.velocity = new Vector2(horMove * moveSpeed * speedMultiplier, verMove * moveSpeed * speedMultiplier);
        /*
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
			body.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * moveSpeed * speedMultiplier, body.velocity.y);


        if (Input.GetAxisRaw("Horizontal") < 0.5f && Input.GetAxisRaw("Horizontal") > -0.5f)
            body.velocity = new Vector2(0f, body.velocity.y);

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
			body.velocity = new Vector2(body.velocity.x, Input.GetAxisRaw("Vertical") * moveSpeed * speedMultiplier);
			

		if(Input.GetAxisRaw("Vertical") < 0.5f && Input.GetAxisRaw("Vertical") > -0.5f)
			body.velocity = new Vector2(body.velocity.x, 0f);
            */
		animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));

        // Abre a cena de customizacao se estiver dentro do laboratorio
        if (Input.GetKeyDown(KeyCode.C)) {
            if (transform.position.x > 19 &&
                transform.position.x < 23 &&
                transform.position.y > -49.4 &&
                transform.position.y < -39)
            SceneManager.LoadScene("Customization");
        }
    }
}
