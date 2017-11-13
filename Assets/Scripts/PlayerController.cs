using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float speedMultiplier;
	private Animator animator;
	private Rigidbody2D body;
	private float horMove;
	private float verMove;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator>();
		body = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			speedMultiplier = 1.5f;
		else speedMultiplier = 1f;

		verMove = Input.GetAxisRaw("Vertical");
		horMove = Input.GetAxisRaw("Horizontal");
		if (Mathf.Abs(verMove) == Mathf.Abs(horMove)) {
			horMove = 0f;
			verMove = 0f;
		}

		transform.Translate (horMove * moveSpeed * Time.deltaTime, verMove * moveSpeed * Time.deltaTime, 0);

		animator.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
		animator.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
	}
}
