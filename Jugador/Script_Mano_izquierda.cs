using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano_izquierda : MonoBehaviour
{

    protected Joystick joystick;
    private Animator anim;
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("direction", this.transform.parent.gameObject.GetComponent<Animator>().GetInteger("direction"));
        if (this.transform.parent.gameObject.GetComponent<Animator>().GetBool("shoot")) anim.SetInteger("direction", anim.GetInteger("direction") + 10);
        anim.SetBool("walk", this.transform.parent.gameObject.GetComponent<Animator>().GetBool("walk"));
     
    }
}
