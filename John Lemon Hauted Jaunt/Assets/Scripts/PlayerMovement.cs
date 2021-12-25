using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f;
    public GameObject firstPersonCamera;
    public GameObject thirdPersonCamera;
    Animator m_Animator;
    Vector3 m_Movement; //'m' for member variable, non-public variable    
    Quaternion m_Rotation = Quaternion.identity;
    Rigidbody m_RigidBody;
    AudioSource m_AudioSource;
    bool m_IsInFirstPerson;

    void Start()
    {
        m_Animator = GetComponent<Animator>(); //gets GameObject's Animator component (an instance)
        m_RigidBody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            firstPersonCamera.SetActive(!firstPersonCamera.activeInHierarchy);
            thirdPersonCamera.SetActive(!thirdPersonCamera.activeInHierarchy);
            m_IsInFirstPerson = firstPersonCamera.activeInHierarchy;
        }
    }

    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        

        /*if (m_IsInFirstPerson)
        {
            m_Movement.Set(Input.GetAxis("Mouse X"), 0f, 10f);
        }
        else
        {
            m_Movement.Set(horizontal, 0f, vertical);
        }*/
        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);

        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking);

        if(isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }            
        }
        else
        {
            m_AudioSource.Stop();
        }

        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward);



    }

    void OnAnimatorMove()
    { 
        m_RigidBody.MovePosition(m_RigidBody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_RigidBody.MoveRotation(m_Rotation);
    }
}
