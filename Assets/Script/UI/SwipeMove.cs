using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeMove : MonoBehaviour
{
    [SerializeField] Camera cam;
    [SerializeField] SwipeMove objectTolock;
    [SerializeField] bool invertAxis;
    [SerializeField] bool mouseOverObjectCondition;
    [SerializeField] bool dragToCursor;

    
    public bool isLocked;
    public float speed;

    private bool isMoving;
    private bool isLockingAnother;

    private Transform _transform;
    private Vector3 startPos, currentPos, targetPos, relativePos;

    private void Start()
    {
        if (cam == null) 
            cam = Camera.main;
        isLocked = false;
        isLockingAnother = false;
        _transform = GetComponent<Transform>();
        currentPos = _transform.position;
        isMoving = false;
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isLocked)
        {
            #region УСЛОВИЕ КУРСОРА НАД ОБЪЕКТОМ
            if (mouseOverObjectCondition)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);
                if (hit)
                {
                    if (hit.collider.gameObject.name == gameObject.name)
                    {
                        isMoving = true;
                    }
                }
            }
            else
                isMoving = true;
            #endregion
            if (isMoving)
            {
                #region БЛОКИРОВКА ДВИЖЕНИЯ ДРУГОГО ОБЪЕКТА
                if (objectTolock)
                {
                    isLockingAnother = true;
                    objectTolock.isLocked = true;
                }
                #endregion
                relativePos = cam.ScreenToWorldPoint(Input.mousePosition)-_transform.position;
                startPos = cam.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else if (Input.GetMouseButton(0) && isMoving && !isLocked)
        {
            
            currentPos = cam.ScreenToWorldPoint(Input.mousePosition) - startPos;
            targetPos = _transform.position - currentPos;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            #region РАЗБЛОКИРОВКА ДРУГОГО ОБЪЕКТА
            if (objectTolock&&isLockingAnother)
            {
                objectTolock.isLocked = false;
                isLockingAnother = false;
            }
            #endregion
            isMoving = false;
        }
        if (!isLocked && isMoving)
        {
            if (!dragToCursor)
            {
                targetPos.z = _transform.position.z;
                _transform.position = Vector3.Lerp(_transform.position, targetPos, speed * Time.deltaTime);
            }
            else
            {
                targetPos = cam.ScreenToWorldPoint(Input.mousePosition) - relativePos;
                
                targetPos.z = _transform.position.z;
                _transform.position = targetPos;
            }
        }
    }
}
