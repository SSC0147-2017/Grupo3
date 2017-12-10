using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject followTarget;

	//private Vector3 offset;
	public Vector3 minCameraPos;
	public Vector3 maxCameraPos;

	private Vector2 velocity;

	public float delayX, delayY;

	bool bounds;
    private bool controle = false;

    void pausa()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (controle == false)
            {
                Time.timeScale = 0;
                controle = true;
            }

            else
            {
                Time.timeScale = 1;
                controle = false;
            }
        }
    }


    // Use this for initialization

	
	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		float posX = Mathf.SmoothDamp(transform.position.x, followTarget.transform.position.x, ref velocity.x, delayX);
		float posY = Mathf.SmoothDamp(transform.position.y, followTarget.transform.position.y, ref velocity.y, delayY);

		transform.position = new Vector3(posX, posY, transform.position.z);

		if (followTarget.transform.position.x > 96 && followTarget.transform.position.y < -30) {
			minCameraPos = new Vector3(0f, -65.6f, transform.position.z);
			maxCameraPos = new Vector3(107f, 65.6f, transform.position.z);
		}

		else {
			minCameraPos = new Vector3(14f, -49f, transform.position.z);
			maxCameraPos = new Vector3(113f, -6.65f, transform.position.z);
		}

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, minCameraPos.x, maxCameraPos.x),
			Mathf.Clamp(transform.position.y, minCameraPos.y, maxCameraPos.y),
			transform.position.z
		);

        pausa();
    }

	void LateUpdate () {
		//transform.position = followTarget.transform.position + offset;
	}
}
