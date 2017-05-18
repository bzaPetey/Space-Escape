using UnityEngine;
using System.Collections;

public class FollowCamera : MonoBehaviour {
	public Transform target;
	public Vector3 followDistance = new Vector3(0, 2, -10);
	public float positionalDamp = 10;
	public float rotationalDamp = 10;

	Transform myTransform;



	void Awake(){
		myTransform = transform;

        if (!target) FindTarget();

    }



    void LateUpdate () {
		if(!target)
        {
            FindTarget();
            return;
        }

        Vector3 toPos = target.position + (target.rotation * followDistance);
		Vector3 curPos = Vector3.Lerp(myTransform.position, toPos, positionalDamp * Time.deltaTime);
		myTransform.position = curPos;

		Quaternion toRot = Quaternion.LookRotation(target.position - myTransform.position, target.up);
		myTransform.rotation = Quaternion.Slerp(myTransform.rotation, toRot, Time.deltaTime * rotationalDamp);
	}


    void FindTarget()
    {
        GameObject temp = GameObject.FindGameObjectWithTag("Player");

        if (temp)
            target = temp.transform;
    }
}
