using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float rcsThrust = 250f;
    [SerializeField] float mainThrust = 100f;
    Rigidbody rigidbody;
    AudioSource audiosource;

    void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Friendly":
                //do nothing
                break;
            default:
                print("Shit");
                break;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        audiosource = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }
    void Thrust()
    {
        float thrustThisFrame = mainThrust * Time.deltaTime; ;
        if (Input.GetKey(KeyCode.Space))
        {
            rigidbody.AddRelativeForce(Vector3.up * thrustThisFrame);
            if (!audiosource.isPlaying)// So it doesnt layer
            {
                audiosource.Play();
            }
        }
        else
        {
            audiosource.Stop();
        }
    }
    void Rotate()
    {

        float rotationThisFrame = rcsThrust * Time.deltaTime;
        rigidbody.freezeRotation = true; // take manual contreol rotation
        if (Input.GetKey(KeyCode.A))
        {

            transform.Rotate(Vector3.forward * rotationThisFrame);
            // rigidbody.AddRelativeForce(Vector3.left);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
            // rigidbody.AddRelativeForce(Vector3.right);
        }

        rigidbody.freezeRotation = false; //Resume physics control
    }
}
