using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveWeight : MonoBehaviour
{

    Vector3 weightPosition;
    public static int numberOfTimesWeightLifted = 0;
    static bool  reachedBottomOfWeightLiftingPhase;


    // Start is called before the first frame update
    void Start()
    {
        weightPosition = transform.position; 
    }

    // Update is called once per frame
    void Update()
    {
        if(reachedBottomOfWeightLiftingPhase == false && numberOfTimesWeightLifted < 2)
        {
            weightPosition.y -= .005f;
            transform.position = weightPosition;
        }

       if(weightPosition.y <= 13.0f)
        {

            reachedBottomOfWeightLiftingPhase = true;
            weightPosition.y += 2.0f;
           
            transform.position = weightPosition;
            reachedBottomOfWeightLiftingPhase = false;
            numberOfTimesWeightLifted++;
             
        }




            
        
    }
}
