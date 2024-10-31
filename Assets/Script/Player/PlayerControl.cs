using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControl : MonoBehaviour {

    public static PlayerControl PlayerCtrl;

	private Animator anim;
    private int Hit;
    private float DebugTime = 0;
    private float Atk1DebugTime = 0;
    private float Atk2DebugTime = 0;
    private float DebugTimetotal = 1.2f;
    private float Atk1Time = 0.35f;
    private float Atk2Time = 1;
    private bool IsInvincible = false;
    private bool IsGround = false;
    private bool IsJump2 = false;
    private bool Atk1 = false;
    private bool Atk2 = false;
    private Renderer renderer2;
    private AudioSource PlaySound;
    private BoxCollider2D BCollider;

    public AudioClip Jump;
    public AudioClip Atk1Sound;
    public GameObject atk1_col;
    public GameObject atk2_col;
    public GameObject atk2_anim;
    public Slider Atk1_CDTime;
    public Slider Atk2_CDTime;
    public float force_move = 50.0f;
	public float JumpVel = 40;
    public float InvincibleTimer = 0;
    public float InvincibleTimeLong = 0.7f;
    bool facingRight = true;
    
    
	// Use this for initialization
	void Start () {
        Atk1_CDTime.value = Atk1_CDTime.maxValue = Atk1Time;
        Atk2_CDTime.value = Atk2_CDTime.maxValue = Atk2Time;
        anim = GetComponent<Animator>();
        renderer2 = GetComponent<Renderer>();
        BCollider = GetComponent<BoxCollider2D>();
        atk1_col.SetActive(false);
        atk2_col.SetActive(false);
        atk2_anim.SetActive(false);
        PlaySound = GetComponent<AudioSource>();
        InvincibleTimeLong = 0.7f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        DebugTime += Time.deltaTime;

        float Move = Input.GetAxis("Horizontal");
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack1") && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack2"))
            this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Move * force_move, this.gameObject.GetComponent<Rigidbody2D>().velocity.y);
        Vector2 vel = GetComponent<Rigidbody2D>().velocity;

        if (Move > 0.05f)
        {
        //	GetComponent<Transform> ().localScale = new Vector3 (0.1f, 0.1f, 1);
        //	GetComponent<Rigidbody2D> ().AddForce (Vector2.right * force_move);
            anim.SetBool("Run", true);
        }
        else if(Move < -0.05f)
        {
        //	GetComponent<Transform> ().localScale = new Vector3 (-0.1f, 0.1f, 1);
        //	GetComponent<Rigidbody2D> ().AddForce (-Vector2.right * force_move);
            anim.SetBool("Run", true);
        }
        else
            anim.SetBool("Run", false);
        if (IsGround == true && Input.GetKeyDown(KeyCode.UpArrow)) //一段跳
        {
            DebugTime = 0;
            PlaySound.PlayOneShot(Jump, 0.5f);
            vel.y = JumpVel;
            GetComponent<Rigidbody2D>().velocity = vel;
        }
        else if (IsGround == false && IsJump2 == false && Input.GetKeyDown(KeyCode.UpArrow)) //二段跳
        {
            PlaySound.PlayOneShot(Jump, 0.5f);
            vel.y = JumpVel;
            GetComponent<Rigidbody2D>().velocity = vel;
            IsJump2 = true;
        }
        anim.SetFloat("vertical", GetComponent<Rigidbody2D>().velocity.y);

        if (Input.GetKeyDown(KeyCode.Z) && Atk1DebugTime == 0 && Atk2 == false)
        {
            PlaySound.PlayOneShot(Atk1Sound, 1);
            anim.SetTrigger("Attack1");
        }
        if (Input.GetKeyDown(KeyCode.X) && Atk2DebugTime == 0 && Atk1 == false)
        {
            atk2_anim.SetActive(true);
            anim.SetTrigger("Attack2");
        }

        

        if (Atk1 == true)
        {
            Atk1DebugTime += Time.deltaTime;
            Atk1_CDTime.value = Atk1DebugTime;
        }
        else if (Atk1 == false && Atk1DebugTime < Atk1Time && Atk1DebugTime > 0)
        {
            Atk1DebugTime += Time.deltaTime;
            Atk1_CDTime.value = Atk1DebugTime;
        }
        else
        {
            BCollider.enabled = false;
            BCollider.enabled = true;
            Atk1_CDTime.value = Atk1Time;
            Atk1DebugTime = 0;
        }


        if (Atk2 == true)
        {
            Atk2DebugTime += Time.deltaTime;
            Atk2_CDTime.value = Atk2DebugTime;
        }
        else if (Atk2 == false && Atk2DebugTime < Atk2Time && Atk2DebugTime > 0)
        {
            Atk2DebugTime += Time.deltaTime;
            Atk2_CDTime.value = Atk2DebugTime;
        }
        else
        {
            BCollider.enabled = false;
            BCollider.enabled = true;
            Atk2_CDTime.value = Atk2Time;
            Atk2DebugTime = 0;
        }


        if (Move > 0 && !facingRight)
            Flip();
        else if (Move < 0 && facingRight)
            Flip();

        if (DebugTime > DebugTimetotal)
        {
            DebugTime = 0;
            atk2_col.SetActive(false);
            atk1_col.SetActive(false);
            Atk1 = false;
            Atk2 = false;
            if (IsGround == true)
                IsGround = false;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScal = transform.localScale;
        theScal.x *= -1;
        transform.localScale = theScal;
    }

    void Attack1()
    {
        if (Atk1 == false && Atk1DebugTime == 0 && Atk2 == false)
        {
            DebugTime = 0;
            Atk1 = true;
            atk1_col.SetActive(true);
        }
    }

    void Attack1Finish()
    {
        if (Atk1 == true)
        {
            Atk1 = false;
            atk1_col.SetActive(false);
        }
    }

    void Attack2Start()
    {
        if (Atk2 == false && Atk2DebugTime == 0 && Atk1 == false)
        {
            DebugTime = 0;
            Atk2 = true;
        }
    }

    void Attack2()
    {
        atk2_col.SetActive(true);
    }

    void Attack2HitFinish()
    {

        atk2_col.SetActive(false);
    }

    void Attack2Finish()
    {
        if (Atk2 == true)
        {
            atk2_anim.SetActive(false);
            Atk2 = false;
        }
    }

    IEnumerator Damage()
    {
        while (InvincibleTimer < InvincibleTimeLong)
        {
            //變灰人
            renderer2.material.color = new Color(0.5f, 0.5f, 0.5f, 1);
            //等待0.05秒
            yield return new WaitForSeconds(0.05f);
            //恢復原狀
            renderer2.material.color = new Color(1, 1, 1, 1);
            //等待0.05秒
            yield return new WaitForSeconds(0.05f);
            InvincibleTimer += 0.1f;
        }
        IsInvincible = false;
        InvincibleTimer = 0;

        BCollider.enabled = false;
        BCollider.enabled = true;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsInvincible == false && Atk1 == false && Atk2 == false)
        {
            if (collision.gameObject.tag == "Monster")
            {
                IsInvincible = true;
                StartCoroutine("Damage");
                int Hit = Random.Range(0, 20);
                GameControl_Game.GameCtrl.OnHit(90 + Hit); 
            }

            if (collision.gameObject.tag == "Glass")
            {
                IsInvincible = true;
                StartCoroutine("Damage");
                int Hit = Random.Range(0, 20);
                GameControl_Game.GameCtrl.OnHit(230 + Hit);
            }

            if (collision.gameObject.tag == "Sk1_Can")
            {
                IsInvincible = true;
                StartCoroutine("Damage");
                GameControl_Game.GameCtrl.OnHit(300);
            }
            if (collision.gameObject.tag == "WaterGun")
            {
                IsInvincible = true;
                StartCoroutine("Damage");
                GameControl_Game.GameCtrl.OnHit(500);
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.tag == "Floor" || col.collider.tag == "Floor2")
        {
           IsGround = true;
           IsJump2 = false;
        }

        if (col.collider.tag == "Boss" && IsInvincible == false)
        {
            IsInvincible = true;
            StartCoroutine("Damage");
            int Hit = Random.Range(0, 20);
            GameControl_Game.GameCtrl.OnHit(290 + Hit);
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        if (col.collider.tag == "Floor" || col.collider.tag == "Floor2")
        {
            IsGround = false;
        }
    }


    public void OnHit(int damege)
    {
        GameControl_Game.GameCtrl.OnHit(damege);
    }

    public void GameOver()
    {
        Destroy(gameObject);
    }
}
