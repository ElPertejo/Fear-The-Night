using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arma : MonoBehaviour
{

    protected Joystick joystick;
    private Animator anim;
    private Rigidbody2D rb2d;
    Jugador jugador;
    public int nArma;

    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        jugador = this.transform.parent.gameObject.GetComponent<Jugador>();

    }

    // Update is called once per frame
    void Update()
    {

        nArma = jugador.arma;
        if(nArma == -1)
        {
            GetComponent<Renderer>().enabled = false;
        }
        else
        {
            GetComponent<Renderer>().enabled = true;
        }

        anim.SetInteger("direction", this.transform.parent.gameObject.GetComponent<Animator>().GetInteger("direction"));
        if (this.transform.parent.gameObject.GetComponent<Animator>().GetBool("shoot")) anim.SetInteger("direction", anim.GetInteger("direction") + 10);
        anim.SetBool("walk", this.transform.parent.gameObject.GetComponent<Animator>().GetBool("walk"));

    }
}