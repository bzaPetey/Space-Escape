/*
PlayerMovement.cs
Oct 6/2016
Peter Laliberte - BurgZerg Arcade

Move the ship around in 3d space
*/

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour {
	public float maxSpeed = 50f;            //max speed of the ship
	public float maxTurn = 60f;             //max turning speed of the ship

    public Thruster[] thrusters;            //array of thrusters on this ship

    Transform myT;                          //cached version of our transform



    void Awake()
    {
        //cache out transform locally
        myT = transform;

        //make sure that we set out tag to Player
        gameObject.tag = "Player";
    }



	void Update()
    {
        Turn();     //turn th ship if needed this frame
        Thrust();   //move the ship forward this frame if needed
    }



    void Turn()
    {
        //get the player input and adjust the rotation acordingly
        float yawn = maxTurn * Input.GetAxis("Horizontal") * Time.deltaTime;
        float pitch = maxTurn * Input.GetAxis("Pitch") * Time.deltaTime;

        //rotate the ship
        myT.Rotate(new Vector3(-pitch, yawn, 0));

        /*** For extra credit, add roll to the player controls ***/
    }



    void Thrust()
    {
        //when the thust forward key is pressed, turn the thrusters on
        if (Input.GetKeyDown(KeyCode.W))
            for (int cnt = 0; cnt < thrusters.Length; cnt++)
                thrusters[cnt].Activate();
        else if(Input.GetKeyUp(KeyCode.W))
            for (int cnt = 0; cnt < thrusters.Length; cnt++)
                thrusters[cnt].Activate(false);

        //We only want the ship to move forward
        if (Input.GetAxis("Vertical") > 0)
            myT.position += myT.forward * maxSpeed * Time.deltaTime * Input.GetAxis("Vertical");

        /*** Bonus Credit -  Play a flight sound when the ship is  ***/
    }
}
