/*******************
********************/
using UnityEngine;
using System.Collections;

public class CamFollow : MonoBehaviour {

	public Transform target;//follow Target
	public float offsetHight = 1.8f;
	public float offsetZ = 0.134f;
	public float followPosSamp = 5;
	public float followRotSamp = 5;

	void Start () {
	
	}

	void Update () {
	
	}

	//每一帧调用一次，当Update执行完后被调用，一般是用相机的移动
	void LateUpdate ()
	{
		transform.position = Vector3.Lerp (transform.position , target.position+Vector3.up*offsetHight+target.forward.normalized*offsetZ , Time.deltaTime*followPosSamp);
		transform.rotation = Quaternion.Slerp (transform.rotation, target.rotation, Time.deltaTime * followRotSamp);
	}
}
