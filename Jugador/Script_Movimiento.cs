using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento : MonoBehaviour
{

    protected Joystick[] joystick;
    private Animator anim;
    private Rigidbody2D rb2d;

    public float speedX;
    public float speedY;
    private int direction;
    public AnimationClip animacion;
    Jugador jugador;
    public int arma;
    
    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jugador = GetComponent<Jugador>();
        joystick = FindObjectsOfType<Joystick>();
        
        speedX = 0;
        speedY = 0;
    }

    // Update is called once per frame
    void Update()
    {

        arma = jugador.arma;

        if (Mathf.Abs(joystick[1].Horizontal) < 0.01 && Mathf.Abs(joystick[1].Vertical) < 0.01) anim.SetBool("walk", false);
        else anim.SetBool("walk", true);

        if (Mathf.Abs(joystick[0].Horizontal) < 0.05 && Mathf.Abs(joystick[0].Vertical) < 0.05)
        {
            speedY = joystick[1].Vertical;
            speedX = joystick[1].Horizontal;
        }
        else
        {

            speedY = joystick[0].Vertical;
            speedX = joystick[0].Horizontal;
        }

        //Debug.Log(GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name);
        
        rb2d.velocity = new Vector2(joystick[1].Horizontal, joystick[1].Vertical);


        if (speedY > 0 && speedX > 0)
        {
            if (speedY > speedX * 2) direction = 0;
            else if (speedX > speedY * 2) direction = 2;
            else direction = 1;

        } else if (speedY < 0 && speedX > 0)
        {
            if (-speedY > speedX * 2) direction = 4;
            else if (speedX > -speedY * 2) direction = 2;
            else direction = 3;

        } else if (speedY < 0 && speedX < 0)
        {
            if (-speedY > -speedX * 2) direction = 4;
            else if (-speedX > -speedY * 2) direction = 6;
            else direction = 5;

        } else if (speedY > 0 && speedX < 0)
        {
            if (speedY > -speedX * 2) direction = 0;
            else if (-speedX > speedY * 2) direction = 6;
            else direction = 7;
        }

        
        if ((Mathf.Abs(joystick[0].Horizontal) > 0.05 || Mathf.Abs(joystick[0].Vertical) > 0.05) && arma != -1)
        {
            anim.SetBool("shoot", true);
        } else
        {
            anim.SetBool("shoot", false);
        }
        anim.SetInteger("direction", direction);
    }
}
