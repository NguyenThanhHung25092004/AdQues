using Unity.Hierarchy;
using Unity.VisualScripting;
using UnityEngine;

public class RopeManager : MonoBehaviour
{
    public DistanceJoint2D playerJoint;
    private SimpleCharacterMove movementScript;
    public SimpleCharacterMove otherPlayerMovement;

    public float pullSpeed = 0.5f;
    public float reelSpeed = 0.5f;
    public float minDistance = 2f;
    public float defaultDistance = 6.5f;

    public string verticalKeys = "Vertical";
    public KeyCode pullKey = KeyCode.DownArrow;
    
    private bool isPulling = false;

    private void Awake()
    {
        movementScript = GetComponent<SimpleCharacterMove>();
    }

    private void Update()
    {
        float verticalInput = Input.GetAxisRaw(verticalKeys);

        //Pulling
        if(movementScript.isGrounded())
        {
            if (Input.GetKeyDown(pullKey))
            {
                isPulling = true;
                movementScript.setMovementEnabled(false);
                StartCoroutine(PullOtherPlayer());
            }
            else if (Input.GetKeyUp(pullKey))
            {
                isPulling = false;
                movementScript.setMovementEnabled(true);
            }
        } else
        {
            if(isPulling)
            {
                isPulling = false;
                movementScript.setMovementEnabled(true);
            }

            //Reeling
            if (verticalInput != 0f && !isPulling)
            {
                float delta = verticalInput * reelSpeed * Time.deltaTime;
                float newDistance = Mathf.Clamp(playerJoint.distance - delta, minDistance, defaultDistance);
                playerJoint.distance = newDistance;
            }
        }
        if (movementScript.isGrounded() && otherPlayerMovement.isGrounded() && !isPulling)
        {
            playerJoint.distance = defaultDistance;
        }
    }

    private System.Collections.IEnumerator PullOtherPlayer()
    {
        while(isPulling)
        {
            float newDistance = playerJoint.distance - pullSpeed * Time.deltaTime;
            playerJoint.distance = Mathf.Max(newDistance, minDistance);
            yield return null;
        }

    }

}
