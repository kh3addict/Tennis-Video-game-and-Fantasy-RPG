using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMovementEnabled : MonoBehaviour
{
    // Start is called before the first frame update
    CharacterController targetMovement;
    bool timeToResetPosition = false;

    public static float amountToOffsetXBy = 0;
    
    
    void Start()
    {
        targetMovement = GetComponent<CharacterController>();

        
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 targetMoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0 , Input.GetAxis("Vertical"));

        if(Input.GetAxis("Horizontal") <0 && amountToOffsetXBy <= 15 && PlayerControllerz.baseForce >= -2 )
           
        {
            amountToOffsetXBy += 7;
            PlayerControllerz.baseForce -= .20f;
             

        }


        if(Input.GetAxis("Horizontal") > 0 && amountToOffsetXBy >= 1)
        {
            amountToOffsetXBy -= 1;
        }
      
        if(PlayerControllerz.targetMovementEnabled == true)
        {
            targetMovement.enabled = true;
            if(timeToResetPosition == true)
            {
                Vector3 resetTargetPosition = this.transform.position;
                targetMovement.enabled = false;
                this.gameObject.SetActive(true);
                resetTargetPosition.x = -17f;
                resetTargetPosition.y = 4.3f;
                resetTargetPosition.z = 23.5f;
                this.transform.position = resetTargetPosition;
                targetMovement.enabled = true;
                timeToResetPosition = false;
            }

            if ((this.transform.position.x >= -108.6f && this.transform.position.x <= 77) )
            {
                if ((this.transform.position.z >= -2.4 && this.transform.position.z <= 86))
                {

                    targetMovement.Move(targetMoveDirection);

                }
            }

             
        }


        else
        {
            timeToResetPosition = true;
            targetMovement.enabled = false;
             
        }
        
    }
}
