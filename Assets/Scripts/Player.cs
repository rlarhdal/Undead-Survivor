using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Vector2 inputVec;
    public FloatingJoystick joystick;
    public float speed;

    Rigidbody2D rigid;
    SpriteRenderer spriter;
    Animator anim;
    
    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriter = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputVec.x = joystick.Horizontal;
        inputVec.y = joystick.Vertical;

    }

    //�������� �������� FixedUpdate
    void FixedUpdate()
    {
        /*rigid.AddForce(inputVec);

        rigid.velocity = inputVec;*/

        Vector2 moveVec = inputVec.normalized * speed * Time.fixedDeltaTime; //fixedDeltaTime => fixedUpdate, deltaTime => Update
        rigid.MovePosition(rigid.position + moveVec);
    }

    void LateUpdate()
    {
        anim.SetFloat("Speed", inputVec.magnitude);

        if (inputVec.x != 0)
        {
            spriter.flipX = inputVec.x < 0;
        }
    }
}
