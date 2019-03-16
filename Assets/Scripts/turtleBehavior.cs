using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class turtleBehavior : MonoBehaviour
{
    float Move;
    bool xMove;
    bool yMove;
    bool impulso;

    float yMax = 3.93f;
    float yMin = 4.62f;
    float xMax = 8.51f;

    public static float x;
    public static float y;
    public float speed;

    void Start()
    {
        transform.position = new Vector3(0, 0);
    }

    void Update()
    {
        x = transform.position.x;
        y = transform.position.y;

        Moviment();
        Limitation();
    }

    /// <summary>
    /// Teclas de movimento do player
    /// </summary>
    void Moviment()
    {
        xMove = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow);
        yMove = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow);

        //Impulso
        if (xMove || yMove)
        {
            Move += 0.07f;
            if (Move >= 1)
            {
                Move = 1;
            }
            
        }
        else
        {
            Move -= 0.07f;
            if (Move <= 0)
            {
                Move = 0;
            }
        }
        if (impulso)
        {
            transform.Translate(Vector3.up * Move * speed * Time.deltaTime);
        }
        
        //Um eixo por vez
        if (xMove && yMove)
        {
            impulso = false;
        }
        else
        {
            impulso = true;
        }

        //Rotação
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) && transform.rotation.z != -90)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, -90);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) && transform.rotation.z != 90)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 90);
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && transform.rotation.z != -90)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 0);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S) && transform.rotation.z != 90)
        {
            transform.eulerAngles = new Vector3(transform.rotation.x, transform.rotation.y, 180);
        }
    }
    /// <summary>
    /// Limitação de movimento na tela
    /// </summary>
    void Limitation()
    {
        if (transform.position.y > yMax)
        {
            transform.position = new Vector3(transform.position.x , yMax);
        }
        else if (transform.position.y < -yMin)
        {
            transform.position = new Vector3(transform.position.x, -yMin);
        }
        else if (transform.position.x > xMax)
        {
            transform.position = new Vector3(xMax, transform.position.y);
        }
        else if (transform.position.x < -xMax)
        {
            transform.position = new Vector3(-xMax, transform.position.y);
        }
    }
}
