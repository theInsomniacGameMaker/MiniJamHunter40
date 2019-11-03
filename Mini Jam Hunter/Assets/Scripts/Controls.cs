using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public enum View { FirstPerson, TopDown };
public class Controls : MonoBehaviour
{
    private static Controls _instance;
    public static Controls Instance { get { return _instance; } }

    [SerializeField]
    private Camera firstPerson, topDown;

    public delegate void MiddleMouseButtonClick();
    public static event MiddleMouseButtonClick OnMiddleMouseButtonClicked;

    public delegate void RightMouseButtonClick();
    public static event RightMouseButtonClick OnRightMouseButtonClicked;

    public View currentView = View.FirstPerson;

    private NavMeshAgent myAgent;

    private void Awake()
    {
        myAgent = GetComponent<NavMeshAgent>();

        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    private void Start()
    {
        firstPerson.enabled = true;
        topDown.enabled = false;
    }

    private void Update()
    {
        CheckMiddleMouseButtonClick();

        if (Input.GetMouseButtonDown(1) && currentView == View.TopDown)
        {
            RaycastHit hit;

            if (Physics.Raycast(topDown.ScreenPointToRay(Input.mousePosition), out hit, 1000))
            {
                if (hit.transform.CompareTag("Ground"))
                {
                    myAgent.destination = hit.point;
                    OnRightMouseButtonClicked();
                }
            }
        }
        myAgent.updatePosition = false;

        //Debug.Log(GetDotDirection());
        //if (GetDotDirection())
        transform.position = myAgent.nextPosition;
    }


    private void CheckMiddleMouseButtonClick()
    {
        if (Input.GetMouseButtonDown(2))
        {
            firstPerson.enabled = !firstPerson.enabled;
            topDown.enabled = !topDown.enabled;

            currentView = currentView == View.FirstPerson ? View.TopDown : View.FirstPerson;



            OnMiddleMouseButtonClicked();
        }
    }

    private float GetDotDirection()
    {
        //Vector3 moveDirection = myAgent.nextPosition - transform.position;
        Vector3 moveDirection =  transform.position- myAgent.nextPosition;
        return Vector3.Dot(moveDirection.normalized, transform.forward);
    }


    public bool isMoving
    {
        get
        {
            return myAgent.velocity.sqrMagnitude > 0.0f;
        }
    }
}
