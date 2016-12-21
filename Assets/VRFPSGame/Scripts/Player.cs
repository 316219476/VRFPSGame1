/*******************
********************/
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// 玩家类
/// </summary>
[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour {

	public float mCurHP;//
	public float mMaxHP;//
	public AWeapon mWeapon;
	public float mMoveSpeed = 0;
	public float mRotateSpeed = 0;

	public Transform mHandLeftCtrl;//左手控制器
	public Transform mHandRightCtrl;//右手控制器
	public Transform mHandLeftPoint;//左手武器挂载点
	public Transform mHandRightPoint;//右手武器挂载点

	CharacterController characterCtrl;
	Animator mAnimaor;

	void Start () {
		characterCtrl = GetComponent<CharacterController> ();
		mAnimaor = GetComponentInChildren<Animator> ();

		ChangeWeapon (PublicEnum.GunType.Shotgun);
	}
	
	float v = 0;
	float h = 0;
	bool isFire = false;
	void Update () {
		v = Input.GetAxis ("Vertical");
		h = Input.GetAxis ("Horizontal");
		Move (v , h);

		if(Input.GetMouseButtonDown(0)){
			isFire = true;
		}

		else if(Input.GetMouseButtonUp(0)){
			isFire = false;
		}

		Fire (isFire);

		if(Input.GetKeyDown(KeyCode.R)){
			this.Reload ();
		}
	}

	public void ChangeWeapon(PublicEnum.GunType gunType){
		AWeapon weapon = WeaponFactory.GetWeaponInstance(gunType);
		if (weapon == null) {
			Debug.Log ("ChangeWeapon...加载枪失败...");
		} else {
			this.mWeapon = weapon;
			this.mWeapon.transform.SetParent (this.mHandRightPoint);
			this.mWeapon.transform.localPosition = -this.mWeapon.handPoint.localPosition;
			this.mWeapon.transform.rotation = this.mHandRightPoint.rotation;
			this.mWeapon.Init ();
		}
	}

	protected virtual void SetIKCtrl(){
		mHandLeftCtrl.position = mAnimaor.GetIKPosition (AvatarIKGoal.LeftHand);
		mHandRightCtrl.position = mAnimaor.GetIKPosition (AvatarIKGoal.RightHand);
	}

	bool isFirst = true;
	public void OnAnimatorIK(int layer){
		if(isFirst){
			isFirst = false;
			SetIKCtrl ();
		}
		mAnimaor.SetIKPositionWeight (AvatarIKGoal.LeftHand,1);
		mAnimaor.SetIKPositionWeight (AvatarIKGoal.RightHand, 1);

		mAnimaor.SetIKPosition (AvatarIKGoal.LeftHand, mHandLeftCtrl.position);
		mAnimaor.SetIKPosition (AvatarIKGoal.RightHand , mHandRightCtrl.position);

		mAnimaor.SetIKRotationWeight (AvatarIKGoal.LeftHand, 1);
		mAnimaor.SetIKRotationWeight (AvatarIKGoal.RightHand, 1);

		mAnimaor.SetIKRotation (AvatarIKGoal.LeftHand , mHandLeftCtrl.rotation);
		mAnimaor.SetIKRotation (AvatarIKGoal.RightHand , mHandRightCtrl.rotation);
	}

	public void Move(float v , float h){
		characterCtrl.SimpleMove (transform.forward*v*mMoveSpeed);
		//transform.Translate ();
		characterCtrl.SimpleMove (transform.right*h*mMoveSpeed);
		mAnimaor.SetFloat ("MoveSpeed",v);
		mAnimaor.SetFloat ("Rotate",h);
	}

	public void Fire(bool flag){
		mAnimaor.SetBool ("Fire" , flag);
		if(this.mWeapon!=null&&flag){
			this.mWeapon.Fire();
		}
	}

	public void Reload(){
		if(this.mWeapon!=null){
			this.mWeapon.Reload ();
		}
	}
}
