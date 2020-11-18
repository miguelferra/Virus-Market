using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCarrito : MonoBehaviour
{

    public Rigidbody rigidbody;

    public float fowardAccel = 8f;
    public float reverseAccel = 4f;
    public float maxSpeed = 15f;
    public float turnStrength = 180f;
    public float brakeFactor = 5f;


    public float gravityForce = 10f;

    private bool grounded;

    public ParticleSystem[] dustTrail;
    public float maxEmission = 25f;
    private float emissionRate;

    public LayerMask whatIsGround;
    public float groundRayLength = .5f;
    public Transform groundRayPoint;

    public AudioSource sonidoCarrito;

    private float speedInput;
    private float turnInput;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody.transform.parent = null;

    }

    // Update is called once per frame
    void Update()
    {
        speedInput = 0f;
        if (Input.GetAxis("Vertical") > 0) {
            speedInput = Input.GetAxis("Vertical") * fowardAccel;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            speedInput = Input.GetAxis("Vertical") * reverseAccel;
        }

        turnInput = Input.GetAxis("Horizontal");
        if (grounded)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles + new Vector3(0f, turnInput * turnStrength * Time.deltaTime, 0f));
        }


        transform.position = rigidbody.transform.position;
    }

    private bool estadoSonido = false;

    private void FixedUpdate()
    {
        grounded = false;
        RaycastHit hit;
        if (Physics.Raycast(groundRayPoint.position, -transform.up,out hit,groundRayLength,whatIsGround))
        {
            grounded = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        emissionRate = 0f;

        if (grounded)
        {
            if (Mathf.Abs(speedInput) > 0)
            {
                rigidbody.AddForce(transform.forward * speedInput);
                emissionRate = maxEmission;
                if (!estadoSonido)
                {
                    sonidoCarrito.Play();
                    estadoSonido = true;
                }
            }
            else if(Mathf.Abs(speedInput) == 0)
            {
                sonidoCarrito.Stop();
                estadoSonido = false;
            }
            if (Input.GetKey("space"))
            {
                rigidbody.AddForce(-brakeFactor * rigidbody.velocity);
            }

        }
        else
        {
            rigidbody.AddForce(Vector3.up * -gravityForce);
        }

        if (rigidbody.velocity.magnitude > maxSpeed)
        {
            rigidbody.velocity = rigidbody.velocity.normalized * maxSpeed;
        }

        foreach (ParticleSystem part in dustTrail)
        {
            var emissionModule = part.emission;
            emissionModule.rateOverTime = emissionRate;
        }
    }
}
