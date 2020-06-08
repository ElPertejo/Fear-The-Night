using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mano_derecha : MonoBehaviour
{

    protected Joystick[] joystick;
    private Animator anim;
    private Rigidbody2D rb2d;


    // Start is called before the first frame update
    void Start()
    {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        joystick = FindObjectsOfType<Joystick>();


    }

    // Update is called once per frame
    void Update()
    {

        anim.SetInteger("direction", this.transform.parent.gameObject.GetComponent<Animator>().GetInteger("direction"));
        if (this.transform.parent.gameObject.GetComponent<Animator>().GetBool("shoot")) anim.SetInteger("direction", anim.GetInteger("direction") + 10);
        anim.SetBool("walk", this.transform.parent.gameObject.GetComponent<Animator>().GetBool("walk"));



        /*
        if (Mathf.Abs(joystick[0].Horizontal) >= 0.05 || Mathf.Abs(joystick[0].Vertical) >= 0.05)
        {
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 50f * Time.deltaTime);

            //transform.position = new Vector3(this.transform.parent.gameObject.transform.position.x + 0.5f, this.transform.parent.gameObject.transform.position.y, 0);



        } else
        {
            transform.SetPositionAndRotation(this.transform.parent.gameObject.transform.position, this.transform.parent.gameObject.transform.rotation);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        }*/

    }
}