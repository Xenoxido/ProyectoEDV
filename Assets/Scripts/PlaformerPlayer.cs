using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaformerPlayer : MonoBehaviour
{
    private int Health = 150;
    public float speed = 4.5f;
    public float jumpForce = 12.0f;
    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
    private float knockbacktime;
    private bool knockback;
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        knockback = false;
        knockbacktime = 0f;
    }
    void Update()
    {

        if (_anim.GetBool("Dead")) { _body.velocity = new Vector2(0, _body.velocity.y); 
            return;
        }
        //Hurt(150);
        knockbacktime -= Time.deltaTime;
        if (!knockback)
        {
            

                float deltaX = 0.0f;
            deltaX = Input.GetAxis("Horizontal") * speed;
            _anim.SetFloat("speed", Mathf.Abs(deltaX));
            if (!Mathf.Approximately(deltaX, 0))
            {
                transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
            }
            Vector2 movement = new Vector2(deltaX, _body.velocity.y);
            _body.velocity = movement;
        }
        //Salto
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
        bool grounded = (hit != null);
        if (knockbacktime<=0)
        {
            knockback = false;
        }
        _anim.SetBool("grounded", grounded);
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            _body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

    }

    private void OnDrawGizmos()
    {
        if (_box != null)
        {
            Gizmos.color = Color.red;
            Vector3 max = _box.bounds.max;
            Vector3 min = _box.bounds.min;
            Vector3 corner1 = new Vector3(max.x, min.y - .1f, 0);
            Vector3 corner2 = new Vector3(min.x, min.y - .2f, 0);
            Gizmos.DrawCube((corner1 + corner2) * 0.5f, corner2 - corner1);
        }
    }

    private void Hurt(int damage)
    {
        knockbacktime = 0.3f;
        knockback = true;
        Debug.Log("HURT");
       if(Health > 0)
        {
            Health -= damage;
        }
       if (Health <= 0)
        {
            Dead();
        }
    }

    private void Dead()
    {
        _anim.SetBool("Dead", true);
    }
}
