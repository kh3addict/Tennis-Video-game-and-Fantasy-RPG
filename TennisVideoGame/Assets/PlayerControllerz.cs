using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class PlayerControllerz : MonoBehaviour
{
    // Start is called before the first frame update

    CharacterController cc;
    int characterSpeed = 5;
    public Camera camera;
    public Animator animator;
    public static AnimatorStateInfo asi;
    public Animation animation;
    float differenceBetweenXes;
    float amountToIncreaseOrDecreaseXBy;
    public static bool playedForehand;
    public static bool playedBackhand;
    public GameObject ball;
    public Rigidbody rbBall;
    public static bool targetMovementEnabled = false;
   public static GameObject target;
    public SphereCollider sc;
    public static float baseForce = 1f;
    public int lerpCounter = 0;
    bool reachedEndOfAnimation = false;
    bool ballIsToLeftOfTarget;
    bool ballIsToRightOfTarget;
    public CharacterController ballCharacterController;

    public GameObject targetParent;
    List<GameObject> gol;



    public  GameObject GetTarget()
    {
        return target;
    }
    


    public static float time = 0;
    private GameObject me;


   

 
    bool StopMoving = false;
    void Start()
    {
        cc = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        rbBall = ball.GetComponent<Rigidbody>();
        sc = ball.GetComponent<SphereCollider>();
        ballCharacterController = ball.GetComponent<CharacterController>();
 
        amountToIncreaseOrDecreaseXBy = differenceBetweenXes / 10;
        targetParent = GameObject.Find("TargetParent");
        target = GameObject.Find("Target");
        differenceBetweenXes = Mathf.Abs(Mathf.Abs(ball.transform.position.x) - Mathf.Abs(target.transform.position.x));




    }

    // Update is called once per frame

 


    void OnTriggerStay(Collider col)



         




    {

         

        if (col.gameObject.name == "Tennis Court")
        {
             
        }


         
        if(col.gameObject.name == "TennisBallinga")
        {

            


            if (asi.IsName("Backhand") && asi.normalizedTime >= .2 && asi.normalizedTime <= .3)
            {

                rbBall.AddForce(new Vector3(ball.transform.position.x, 3, ball.transform.position.z) * 3, ForceMode.Impulse);
                playedBackhand = true;
                sc.isTrigger = false;

            }

            else if (asi.IsName("Forehand") && asi.normalizedTime >= .2 && asi.normalizedTime <= .3)
            {








                playedForehand = true;
                sc.isTrigger = false;
                
            }


            

        }
    }
    void Update()
    {




          if(playedForehand || playedBackhand)
        {


            NewBehaviourScript.numberOfTimesCollidedWithGround = 0;
            
            AIController.t = 0;
            AIController.t1 = 0;
            AIController.t2 = 0;

             
            if(time < .06)
            {
                ball.transform.position = Vector3.Lerp(ball.transform.position, new Vector3(target.transform.position.x, 20, target.transform.position.z), time);
                time += .0005f;
            }


            else if (time >= .06)
            {

                if(playedForehand == true)
                {
                    playedForehand = false;
                }

                if(playedBackhand == true)
                {
                    playedBackhand = false;
                }
                rbBall.useGravity = true;

                sc.isTrigger = false;
                ballCharacterController.enabled = false;
            }
        }
 

      

         if (Input.GetAxis("Horizontal") > 0 &&StopMoving == false )
        {
            animator.Play("RightStep");
            animator.SetBool("RunForward", false);
            animator.SetBool("RunBackward", false);
            animator.SetBool("RightStep", true);
            animator.SetBool("LeftStep", false);
        }

        else if (Input.GetAxis("Horizontal") < 0  && StopMoving == false && baseForce <= 5 )
        {
            animator.Play("LeftStep");
            animator.SetBool("RunForward", false);
            animator.SetBool("RunBackward", false);
            animator.SetBool("RightStep", false);
            animator.SetBool("LeftStep", true);
            baseForce += .1f;
        }



       else if (Input.GetKeyDown(KeyCode.Space))
        {



            animator.Play("Service");
        }

        else if(Input.GetAxis("Vertical") > 0  && StopMoving == false && baseForce >= 1 )
        {

            animator.Play("RunForward");
            
            animator.SetBool("RunForward", true);
            animator.SetBool("RunBackward", false);
            animator.SetBool("RightStep", false);
            animator.SetBool("LeftStep", false);
            baseForce -= .1f;

        }


        else if (Input.GetAxis("Vertical") < 0  && StopMoving == false)
        {

            animator.Play("RunBackward");

            animator.SetBool("RunForward", false);
            animator.SetBool("RunBackward", true);
            animator.SetBool("RightStep", false);
            animator.SetBool("LeftStep", false);


        }


        asi = animator.GetCurrentAnimatorStateInfo(0);


        if (Input.GetKeyDown("joystick button 0") || Input.GetKeyDown(KeyCode.J))
        {

           
            targetMovementEnabled = true;
            
            
            animator.Play("Forehand");
           
            StopMoving = true;

            reachedEndOfAnimation = false;

            







        }


        

        else if (Input.GetKeyDown("joystick button 2") || Input.GetKeyDown(KeyCode.K)   )
        {



            targetMovementEnabled = true;
            
             
             
            animator.Play("Backhand");
            
            StopMoving = true;


            reachedEndOfAnimation = false;

            











             


  


        }


        if(Input.GetKeyUp("joystick button 0"))
        {
             
        }


        if (Input.GetKeyUp("joystick button 2"))
        {
             
        }




        if (asi.IsName("Backhand") && asi.normalizedTime >= .8601639f)
        {
            targetMovementEnabled = false;
            StopMoving = false;
             
            
        }

        else if(asi.IsName("Forehand") && asi.normalizedTime >= .8601639f)
            {
            targetMovementEnabled = false;
                StopMoving = false;
             
                
               
            }


         


         



        if (StopMoving == false)
        {

            Vector3 Direction = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            cc.Move(Direction);

        }




    }
}
