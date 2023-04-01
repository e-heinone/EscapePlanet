using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionController : MonoBehaviour
{
    private GameObject objectInView;

    public OutlineScript2 os;
    private bool isInBuildMode = false;


    [SerializeField]
    private GameObject ghostTurret;
    private void Update()
    {
        RaycastObjects();
        PlayerInput();
        if (isInBuildMode)
        {
            ControlGhostTurret();
        }
    }

    private void PlayerInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            InteractWithObject();
            if (isInBuildMode)
            {
                //When building is build
                Instantiate(PlayerEntity.carriedObject,ghostTurret.transform.position,Quaternion.identity);
                CameraAndMovementController.SwitchMenuState();
                isInBuildMode = !isInBuildMode;
                ghostTurret.SetActive(false); 
                ghostTurret = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(CameraAndMovementController.grounded && PlayerEntity.carriedObject != null)
            {
                CameraAndMovementController.SwitchMenuState();
                isInBuildMode = !isInBuildMode;
                if (isInBuildMode)
                {
                    ghostTurret.SetActive(true);
                    ghostTurret = Instantiate(PlayerEntity.carriedObject);
                }
                else { ghostTurret.SetActive(false); }
            }
        }
    }
    private void RaycastObjects()
    {
        if (objectInView != null)
        {
            if (objectInView.GetComponent<OutlineScript2>() != null)
            {
                objectInView.GetComponent<OutlineScript2>().OutOfInteractRange();

            }
        }
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
        if (hit.distance < 2f && hit.collider != null)
        {
            if(objectInView!= null)
            {
                if (objectInView.GetComponent<OutlineScript2>() != null)
                {
                    objectInView.GetComponent<OutlineScript2>().OutOfInteractRange();

                }
            }
            
            if (hit.collider.gameObject.GetComponent<OutlineScript2>() != null)
            {
                hit.collider.gameObject.GetComponent<OutlineScript2>().InInteractRange();

            }
            objectInView = hit.collider.gameObject;
        }
    }

    private void InteractWithObject()
    {
        if(objectInView != null && CameraAndMovementController.MenuState == false)
        {
            IInteractable interactable = objectInView.GetComponent<IInteractable>();
            if(interactable != null)
            {
                interactable.Interaction();
            }
            
        }
    }

    private void ControlGhostTurret()
    {
        Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out RaycastHit hit);
        if(hit.distance < 10 && hit.collider != null)
        {
            ghostTurret.transform.position = hit.point + new Vector3(0,PlayerEntity.carriedObject.GetComponent<Entity>().Height/2,0);
        }
        ghostTurret.transform.rotation = Quaternion.identity;


    }
}
