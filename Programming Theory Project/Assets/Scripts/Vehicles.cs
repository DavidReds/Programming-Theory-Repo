using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicles : MonoBehaviour
{
    [SerializeField] public float horsePower = 20.0f;
    [SerializeField] float turnSpeed=45.0f;
    [SerializeField] float horizontalInput;
    [SerializeField] float forwardInput;
    private Rigidbody vehicleRb;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] float energy = 20f;  // each vehicle will have different energy capacity
    private float m_energyConsuption = 0.1f;
    // ENCAPSULATION
    [SerializeField] public float energyConsuption {
                                                get {return m_energyConsuption;}
                                                set {
                                                    if (value<0.1f){m_energyConsuption=0.1f;} 
                                                    else{m_energyConsuption = value; }
                                                }
                                            }  // each vehicle will have different energy consumption


    // Start is called before the first frame update
    void Start()
    {
        vehicleRb = GetComponent<Rigidbody>();
        //vehicleRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        
    }


    // ABSTRACTION
    public void Move()
    {
        // This function performs the movements in rotation & displacement of the Vehicles
        horizontalInput = Input.GetAxisRaw("Horizontal");
        forwardInput = Input.GetAxisRaw("Vertical");
        
        if ((horizontalInput!=0) || (forwardInput !=0)){
    
            // Move the vehicle forward
            vehicleRb.AddRelativeForce(Vector3.forward * forwardInput * horsePower);
    
            // Rotates the vehicle
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
            Engine(m_energyConsuption);
            
            
            }


    }

    void Engine(float energyRequired){
        // all vehicles uses energy to move
        // this fuction is used to manage power required
        
        energy -= energyRequired;


        // if energy is below 2, horsePower is drastically reduced
        if (energy < 2){
            horsePower = 2f;
            energy = 2;
        }


    }
}
