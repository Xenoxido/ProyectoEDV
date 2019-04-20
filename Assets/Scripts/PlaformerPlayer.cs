using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaformerPlayer : MonoBehaviour
{
    [SerializeField] private RestartPopup restartPopup;
    [SerializeField] private AudioClip dieSong;
    private int Health = 150;
    public float speed = 4.5f;
    public float jumpForce = 12.0f;
    private Rigidbody2D _body;
    private Animator _anim;
    private BoxCollider2D _box;
    private AudioSource _audioJump;
    private AudioSource _audioHurt;
    private AudioSource _music;
    private float knockback = 0;
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _box = GetComponent<BoxCollider2D>();
        var aSources = GetComponents<AudioSource>();
        _audioJump = aSources[0];
        _audioHurt = aSources[1];

    }
    void Update()
    {

        if (_anim.GetBool("Dead")||Time.timeScale==0) {
            _body.velocity = Vector2.zero;
            return; }
        //Hurt(150);
        if(knockback > 0)
        {
            knockback -= Time.deltaTime;
            return;
        }
        float deltaX = 0.0f;
         deltaX = Input.GetAxis("Horizontal") * speed;
        _anim.SetFloat("speed", Mathf.Abs(deltaX));
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale = new Vector3(Mathf.Sign(deltaX), 1, 1);
        }
        Vector2 movement = new Vector2(deltaX, _body.velocity.y);
        _body.velocity = movement;
        //Salto
        Vector3 max = _box.bounds.max;
        Vector3 min = _box.bounds.min;
        Vector2 corner1 = new Vector2(max.x, min.y - .1f);
        Vector2 corner2 = new Vector2(min.x, min.y - .2f);
        Collider2D hit = Physics2D.OverlapArea(corner1, corner2);
        bool grounded = (hit != null);
        _anim.SetBool("grounded", grounded);
        if (grounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W)))
        {
            _audioJump.Play();
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
        
       if(Health > 0)
        {
            Health -= damage;
            _audioHurt.Play();
        }
       if (Health <= 0)
        {
            Dead();
        }
        else
        {
            
        }
    }

    private void Knockback(Vector2 dir)
    {
        if (_anim.GetBool("Dead") == true)
            return;
        knockback = 0.3f;
        
        _body.velocity = Vector2.zero;
        _body.AddForce(new Vector2(dir.x*3, 10 ), ForceMode2D.Impulse);
       
    }

    private void Dead()
    {
        if (!_anim.GetBool("Dead"))
        {
            _anim.SetBool("Dead", true);
            AudioSource _music = GameObject.FindGameObjectWithTag("music").GetComponent<AudioSource>();
            _audioHurt.PlayOneShot(dieSong);
            _music.Pause();
            _body.velocity = Vector2.zero;
            restartPopup.showDiedPanel();
        }
    }
}
