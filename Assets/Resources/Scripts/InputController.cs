using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    [SerializeField] private InputAction leftMove;
    [SerializeField] private InputAction rightMove;
    [SerializeField] private InputAction forwardMove;
    [SerializeField] private InputAction backMove;
    [SerializeField] private InputAction selection;

    private Camera camera;

    private Vector3 movement;
    private Player player;

    #region Lifecycle Functions
    private void Awake()
    {
        leftMove.performed += LeftMovePerformed;
        rightMove.performed += RightMovePerformed;
        forwardMove.performed += ForwardMovePerformed;
        backMove.performed += BackMovePerformed;
        selection.performed += SelectionPerformed;

        leftMove.canceled += MoveCanceled;
        rightMove.canceled += MoveCanceled;
        forwardMove.canceled += MoveCanceled;
        backMove.canceled += MoveCanceled;

        movement = Vector3.zero;
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        leftMove.Enable();
        rightMove.Enable();
        forwardMove.Enable();
        backMove.Enable();
        selection.Enable();
    }

    private void OnDisable()
    {
        leftMove.Disable();
        rightMove.Disable();
        forwardMove.Disable();
        backMove.Disable();
        selection.Disable();
    }
    #endregion

    #region Performed Input
    private void LeftMovePerformed(InputAction.CallbackContext obj)
    {
        movement = -transform.right;
        player.Move(movement);
    }

    private void RightMovePerformed(InputAction.CallbackContext obj)
    {
        movement = transform.right;
        player.Move(movement);
    }

    private void ForwardMovePerformed(InputAction.CallbackContext obj)
    {
        movement = transform.forward;
        player.Move(movement);
    }

    private void BackMovePerformed(InputAction.CallbackContext obj)
    {
        movement = -transform.forward;
        player.Move(movement);
    }

    private void SelectionPerformed(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000.0f))
        {
            Transform item = hit.transform;
            if (item != null && item.gameObject.tag == "Item")
            {
                item.gameObject.GetComponent<ItemController>().Push();
            }
        } 
    }
    #endregion

    #region Canceled Input
    private void MoveCanceled(InputAction.CallbackContext obj)
    {
        player.Move(Vector3.zero);
    }

    private void SelectionMoveCanceled(InputAction.CallbackContext obj)
    {

    }

    #endregion


}
