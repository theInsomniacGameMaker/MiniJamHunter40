﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
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

    public int score;
    public float nextStep;
    public float footStepInterval = 0.4f;
    
    public bool isMoving
    {
        get
        {
            return myAgent.velocity.sqrMagnitude > 0.0f;
        }
    }

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
            Ray ray = topDown.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 1000, Color.white, 5.0f);
            if (Physics.Raycast(topDown.ScreenPointToRay(Input.mousePosition), out hit, 1000, 1<<9))
            {
                Debug.Log("Hit something");
                if (hit.transform.CompareTag("Ground"))
                {
                    myAgent.destination = hit.point;
                    OnRightMouseButtonClicked();
                    Debug.Log("was ground");
                }
                else
                {
                    Debug.Log("Didn't hit ground but hit: " + hit.transform.name);
                }
            }
        }
        myAgent.updatePosition = false;

        transform.position = myAgent.nextPosition;

        if (isMoving)
        {
            if (nextStep<Time.time)
            {
                PlaySound("Footstep Dirtier "+Random.Range(1,4), transform.position, 0.3f);
                nextStep = Time.time + footStepInterval;
            }
        }
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
        Vector3 moveDirection = transform.position - myAgent.nextPosition;
        return Vector3.Dot(moveDirection.normalized, transform.forward);
    }

    public void PlaySound(string name, Vector3 position, float volume = 1.0f)
    {
        AudioSource.PlayClipAtPoint(Resources.Load(name) as AudioClip, position, volume);
    }
}



