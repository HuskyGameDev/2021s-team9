using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zom : MonoBehaviour
{
    //Variables
    [SerializeField]
    Transform[] waypt;

    [SerializeField]
    public float speed = 2f;

    //[SerializeField]
    public SpriteRenderer zomWalk;

    //[SerializeField]
    public Sprite zomWalkDown;

    //[SerializeField]
    public Sprite zomWalkRight;

    //[SerializeField]
    public Sprite zomWalkLeft;

    public Animator anim;

    public int count = 0;


    void Start()
    {
        transform.position = waypt[count].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("counter", count);

        transform.position = Vector2.MoveTowards(transform.position, waypt[count].transform.position, speed * Time.deltaTime);

        if (transform.position == waypt[count].transform.position) {
            count++;
        }

        if (count == waypt.Length) {
            count = 0;
            transform.position = new Vector3(0.97f, 6f, 0f);
        }
    }
}
