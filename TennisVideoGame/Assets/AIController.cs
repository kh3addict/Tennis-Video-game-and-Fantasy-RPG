using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 startPosition;
    Animator anim;
    CharacterController cc;
    PlayerControllerz pc;
    GameObject ball;
    SphereCollider scBall;
    public GameObject AITarget;
    Rigidbody rbBall;
    public GameObject target;
    public static bool timeToPlayShot = false;
    bool keepRunning = false;
    float speed = 1.0f;
    public GameObject newAITarget;
    public GameObject tennisGround;
    public BoxCollider tbc;
    bool recoverToMiddle;
    public GameObject checkPoint1;
    public GameObject checkPoint2;
    public  GameObject checkPoint3;
    public Quaternion rotation1;
    bool finishedReaching1rstCheckPoint = false;
    bool finishedReaching2ndCheckPoint = false;
    bool finishedReaching3rdCheckPoint = false;
    int onlyRotateOnce = 0;
    int onlyRotateOnce1 = 0;
    int onlyRotateOnce2 = 0;
    public float t4 = 0;
    public float t5 = 0;
    public float t6 = 0;
    public Camera cameraInGym;
    public Vector3 cameraPosition;
    public int zoomOutOnce = 0;

 

    public static float t = 0;
    public static float t1 = 0;
    public static float t2 = 0;
    public static float t3 = 0;

    void Start()
    {

         
        pc = new PlayerControllerz();
        startPosition = new Vector3(-35.66f, 4.1407f, 84.45f);
        anim = GetComponent<Animator>();
        cc = GetComponent<CharacterController>();
        ball = GameObject.Find("TennisBallinga");
        scBall = ball.GetComponent<SphereCollider>();
        rbBall = ball.GetComponent<Rigidbody>();
        target = GameObject.Find("Target");
        AITarget = GameObject.Find("AITarget");
        tennisGround = GameObject.Find("Tennis_court");
        tbc = tennisGround.GetComponent<BoxCollider>();
        checkPoint1 = GameObject.Find("Checkpoint1");
        checkPoint2 = GameObject.Find("Checkpoint2");
        checkPoint3 = GameObject.Find("Checkpoint3");



        transform.Rotate(new Vector3(0, -120, 0));





        cameraPosition = cameraInGym.transform.position;


        











    }

    // Update is called once per frame
    void Update()
    {


        if(changeSpeedOfWiehgtLift.AiIsEnabled == true)
        {
             

            if (t4 < .020f && finishedReaching1rstCheckPoint == false)
            {



                anim.Play("Walking");

                transform.position = Vector3.Lerp(transform.position, checkPoint1.transform.position, t4);


                t4 += .0001f;


            }


            if(t4 >= .020f)
            {

               

                if (onlyRotateOnce == 0)
                {

                    transform.Rotate((new Vector3(0, -90, 0)));
                    anim.SetBool("IsWalking", false);
                    onlyRotateOnce++;
                    finishedReaching1rstCheckPoint = true;
                }
                    

                
            }


            if(t5 < .020f && finishedReaching1rstCheckPoint == true)
            {
                anim.SetBool("IsWalking", true);
                transform.position = Vector3.Lerp(transform.position, checkPoint2.transform.position, t5);
                t5 += .0001f;
            }


            if(t5 >= .020f)
            {
                 


                if(onlyRotateOnce1 == 0)
                {
                    transform.Rotate(new Vector3(0, -65, 0));
                    anim.SetBool("IsWalking", false);
                    onlyRotateOnce1++;
                    finishedReaching2ndCheckPoint = true;
                     
                }

            }


            if(t6 < .030f && finishedReaching2ndCheckPoint == true)
            {
                anim.SetBool("IsWalking", true);
                transform.position = Vector3.Lerp(transform.position, checkPoint3.transform.position, t6);
                t6 += .0001f;
                

            }

            if (t6 >= .030f)
            {



                if (onlyRotateOnce2 == 0)
                {
                     
                    anim.SetBool("IsWalking", false);
                   
                    finishedReaching3rdCheckPoint = true;

                }

            }


            if(finishedReaching3rdCheckPoint == true)
            {


                if (zoomOutOnce == 0)
                {

                    
                    
                   
                    anim.Play("PushButton");
                    anim.SetBool("IsRunningInPlace", true);
                    zoomOutOnce++;
                }

            }



        }





         




        if(NewBehaviourScript.numberOfTimesCollidedWithGround == 1)
        {




            PlayerControllerz.time = 0;

            if (t1 < .06f)
            {

                keepRunning = true;
                transform.position = Vector3.Lerp(transform.position, target.transform.position, t1);
                t1 += .0005f;
                scBall.isTrigger = true;




            }


            Debug.Log("The value of t1 is" + t1);

           
            if ( t1 >= .06 && t1 <= .07 && keepRunning == true)
            {



                Debug.Log("In Hashitmoto");


                timeToPlayShot = true;
                keepRunning = false;
                 

            }



            if(recoverToMiddle && t3 < .06)
            {
                t3 += .0005f;
                transform.position =Vector3.Lerp(transform.position, new Vector3(-41.8f, 4.28f, 84.1f), t3);


            }


            if(t3 >= .06)
            {
                recoverToMiddle = false;
            }


            if (timeToPlayShot == true)
            {


                Debug.Log("When time 0 is equal to .06");
                anim.Play("Forehand");
                t3 = 0;
                recoverToMiddle = true;
                int randomX = Random.Range(-54, 80);
                int randomZ = Random.Range(-61, -182);
                AITarget.SetActive(false);
                newAITarget = Instantiate(AITarget, new Vector3(randomX, 10.6f, randomZ), AITarget.transform.rotation) as GameObject;
                newAITarget.SetActive(true);


                rbBall.useGravity = false;
                timeToPlayShot = false;

            }

                if(t2 < .06 && newAITarget != null && t1 >= .06 && timeToPlayShot == false)
                {
                    ball.transform.position = Vector3.Lerp(ball.transform.position, new  Vector3(newAITarget.transform.position.x , 14.0f ,  newAITarget.transform.position.z),t2);
                    t2 += .0005f;
                }



                if(t2 >= .06)
                {

                scBall.isTrigger = false;
                    rbBall.useGravity = true;
                tbc.material =(PhysicMaterial) Resources.Load("PhysicMaterials/Bouncy");
                Destroy(GameObject.Find("AITarget(Clone)"));
                }





            }
        


        if (keepRunning || recoverToMiddle)
        {


          




            if (t < .06f)
            {

                transform.position = Vector3.Lerp(transform.position, new Vector3(PlayerControllerz.target.transform.position.x, PlayerControllerz.target.transform.position.y, PlayerControllerz.target.transform.position.z + 30), t);
                t += .0005f;
            }

            if (transform.position.x > -41.8)
            {
                anim.Play("LeftStep");
                anim.SetBool("LeftStep", true);
                anim.SetBool("RightStep", false);
                anim.SetBool("RunForward", false);
                anim.SetBool("RunBackward", false);

            }

            else if (transform.position.x < -41.8)
            {
                anim.Play("RightStep");
                anim.SetBool("LeftStep", false);
                anim.SetBool("RightStep", true);
                anim.SetBool("RunForward", false);
                anim.SetBool("RunBackward", false);

            }


            else if (transform.position.z < 84.1)
            {
                anim.Play("RunForward");
                anim.SetBool("LeftStep", false);
                anim.SetBool("RightStep", false);
                anim.SetBool("RunForward", true);
                anim.SetBool("RunBackward", false);

            }


            else if (transform.position.z > 84.1)
            {
                anim.Play("RunBackward");
                anim.SetBool("LeftStep", false);
                anim.SetBool("RightStep", false);
                anim.SetBool("RunForward", false);
                anim.SetBool("RunBackward", true);

            }










        }
    }
}

