using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class TankVehicle : Vehicles
{
    // Start is called before the first frame update
    [SerializeField] bool shieldsEnable = false;
     [SerializeField] float shieldsConsumption = 0.1f;

    // POLYMORPHISM
    public virtual void Update(){

        if (Input.GetKeyDown(KeyCode.Space)){
            if (!shieldsEnable){
                shieldsEnable = true;
                shields();
            } else
            {
                shieldsEnable = false;
                shields();
            }
            
        }
        Move();

    }

    void shields(){
        if (shieldsEnable){
            energyConsuption+=shieldsConsumption;

        } else
        {
            energyConsuption= 0.1f;
        }
        

    }
}
