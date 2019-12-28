using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSpeedOfWiehgtLift : MonoBehaviour
{
    // Start is called before the first frame update
    Animator animator;
    public Transform AIOBject;
    public Transform [] underLyingAI;
    public Transform theExactAI;

    public static bool AiIsEnabled = false;
    void Start()
    {


        AIOBject = GameObject.Find("AIObject").transform;
        underLyingAI = AIOBject.GetComponentsInChildren<Transform> (true);



        animator = GetComponent<Animator>();


        foreach(Transform objec1 in underLyingAI){
            if(objec1.name == "AI")
            {
                theExactAI = objec1;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        if(moveWeight.numberOfTimesWeightLifted == 1)
        {
            animator.speed = .87f;
        }

        if(moveWeight.numberOfTimesWeightLifted  == 2)
        {
            transform.gameObject.SetActive(false);
            theExactAI.gameObject.SetActive(true);
            AiIsEnabled = true;
            
        }
    }
}
