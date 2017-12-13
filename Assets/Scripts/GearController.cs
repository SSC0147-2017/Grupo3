using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GearController : MonoBehaviour
{

    private int index = 1;
    private int index_max = 2;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            index++;
            if (index > index_max)
            {
                index = 1;
                Vector2 position = transform.position;
                position.y += 80;
                transform.position = position;
            }
            else
            {
                Vector2 position = transform.position;
                position.y -= 80;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            index--;
            if (index == 0)
            {
                index = 2;
                Vector2 position = transform.position;
                position.y -= 80;
                transform.position = position;
            }
            else
            {
                Vector2 position = transform.position;
                position.y += 80;
                transform.position = position;
            }
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (index == 2)
            {
                Application.Quit();
                print("Bye!");
            }
            if (index == 1)
            {
                Application.LoadLevel("ICMC");
                print("Play!");
            }
        }

    }

}

