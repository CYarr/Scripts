using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Rigidbody2D myRigidBody;

    

    [SerializeField]
    private float movementSpeed;

    [SerializeField]
    private BoxCollider2D SwordCollider1;
    public BoxCollider2D Hitbox1;

    [SerializeField]
    AudioSource sSwing;

    [SerializeField]
    private BoxCollider2D ParryCol1;


    public bool p1Hit;
    public bool p1Parry;

    private bool neverDone = true;
    public bool action;

    private Animator myAnimator;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        HandleInput();

    }

   

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");

        float stanceX = Input.GetAxis("StanceX");
        float stanceY = Input.GetAxis("StanceY");

        HandleMovement(horizontal);

        HandleActions();

        HandleStance(stanceX, stanceY);

        HandleDeath();

        HandleParry();

        ResetValues();

    }

    private void HandleMovement(float horizontal)
    {
        if (horizontal >= 0.01 && horizontal <= 1)
        {
            horizontal = 1;
        }
        if (horizontal <= -0.01 && horizontal >= -1)
        {
            horizontal = -1;
        }

        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Action"))
        {
            myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
        }
        if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Hit"))
        {
            myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
        }



        myAnimator.SetFloat("speed", horizontal);
    }


    private void HandleActions()
    {
        if (action && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Action"))
        {
            myAnimator.SetTrigger("FAction");
            myRigidBody.velocity = Vector2.zero;
        }
       
    }

    private void HandleInput()
    {
        if(Input.GetButton("Action"))
        {
            action = true;
        }
        
    }

    private void ResetValues()
    {
        action = false;
    }

    private void HandleStance(float stanceX, float stanceY)
    {

        if (stanceX == 1)
        {
            myAnimator.SetBool("BStance", true);
            myAnimator.SetBool("FStance", false);
            myAnimator.SetBool("UStance", false);
        }

        if (stanceX == -1)
        {
            myAnimator.SetBool("BStance", false);
            myAnimator.SetBool("FStance", true);
            myAnimator.SetBool("UStance", false);
        }

        if (stanceY == -1)
        {
            myAnimator.SetBool("BStance", false);
            myAnimator.SetBool("FStance", false);
            myAnimator.SetBool("UStance", true);

        }

    }

    private void FAttack()
    {
            SwordCollider1.enabled = !SwordCollider1.enabled;
            sSwing.Play();
            sSwing.Play(44100);
    }


    private void UAttack()
    {
        SwordCollider1.enabled = !SwordCollider1.enabled;
        sSwing.Play();
        sSwing.Play(44100);
    }

    private void BAttack()
    {
        ParryCol1.enabled = !ParryCol1.enabled;
        Hitbox1.enabled = !Hitbox1.enabled;
        sSwing.Play();
        sSwing.Play(44100);
    }


    private void HandleDeath()
    {
        if (p1Hit == true)
        {
            myAnimator.SetTrigger("Hit");
            SwordCollider1.enabled = false;
            ParryCol1.enabled = false;
            Hitbox1.enabled = false;
            if (neverDone == true)
            {
                neverDone = false;
                GameObject.Find("GameObject").GetComponent<RoundController>().p2Win++;
                StartCoroutine(EndGame());
            }
            
            /*if (GameObject.Find("GameObject").GetComponent<RoundController>().p1Win != 3 && GameObject.Find("GameObject").GetComponent<RoundController>().p2Win != 3)
            {
                StartCoroutine(RestartScene());
            }


            if (GameObject.Find("GameObject").GetComponent<RoundController>().p1Win == 3 || GameObject.Find("GameObject").GetComponent<RoundController>().p2Win == 3)
            {
                GameObject.Find("GameObject").GetComponent<RoundController>().p1Win = 0;
                GameObject.Find("GameObject").GetComponent<RoundController>().p2Win = 0;

                StartCoroutine(EndGame());
            }*/
        }
          
    }

    private void HandleParry()
    {
        if(p1Parry == true)
        {
            myAnimator.SetTrigger("Parry");
        }
    }

    IEnumerator RestartScene()
    {
        print(Time.time);
        yield return new WaitForSecondsRealtime(3);
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
        print(Time.time);
    }

    IEnumerator EndGame()
    {
        if (GameObject.Find("GameObject").GetComponent<RoundController>().p1Win == 3 ||
        GameObject.Find("GameObject").GetComponent<RoundController>().p2Win == 3)
        {
            print(Time.time);
            yield return new WaitForSecondsRealtime(3);
            SceneManager.LoadSceneAsync("Main Menu", LoadSceneMode.Single);
            //Destroy Gameplay GameObject
            Destroy(GameObject.Find("GameObject"));
            print(Time.time);
        }
        else
        {
            print(Time.time);
            yield return new WaitForSecondsRealtime(3);
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex);
            print(Time.time);
        }
    }
}
