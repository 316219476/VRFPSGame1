/*******************
********************/
using UnityEngine;
using System.Collections;

public class PlayerAnimatorRecive : MonoBehaviour {

	Player player;
	// Use this for initialization
	 void Start () {
		player = GetComponentInParent<Player> ();
	}

	void OnAnimatorIK(int layer){
		player.OnAnimatorIK (layer);
	}
}
