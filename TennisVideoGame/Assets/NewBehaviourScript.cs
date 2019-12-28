using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update




    public static int numberOfTimesCollidedWithGround;
    private GameObject ground1;
    public BoxCollider groundBoxCollider;
    public SphereCollider ballSphereCollider;
    




    void OnCollisionEnter(Collision col)
    {
        if (col.collider.name == "Tennis_court")
        {

            numberOfTimesCollidedWithGround++;

            


            Debug.Log("number of times collided with ground" + numberOfTimesCollidedWithGround);

            if (numberOfTimesCollidedWithGround == 6)
            {
                
            }
        }

    }
    void Start()
    {


        numberOfTimesCollidedWithGround = 0;


        ballSphereCollider = GetComponent<SphereCollider>();
        ground1 = GameObject.Find("Tennis_court");
       
        groundBoxCollider = ground1.GetComponent<BoxCollider>();




    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y >= 5.7)
        {

            if(ballSphereCollider != null)
            ballSphereCollider.isTrigger = true;
        }

        else
        {
            if(ballSphereCollider != null)
            ballSphereCollider.isTrigger = false;
        }
    }
}
