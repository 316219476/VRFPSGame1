/*******************
********************/
using UnityEngine;
using System.Collections;

public class WeaponFactory{
	public static AWeapon GetWeaponInstance(PublicEnum.GunType type){
		AWeapon weap = null;
		switch (type) {
		case PublicEnum.GunType.RocketLauncher:
			
			break;
		case PublicEnum.GunType.SciFiRifle:
			break;
		case PublicEnum.GunType.Shotgun:
			weap = ResourcesManager.LoadGun<ShotGunFinal> (type.ToString());
			break;
		case PublicEnum.GunType.SubmachineGun:
			break;
		}
		return weap;
	}
}

public abstract class AWeapon : MonoBehaviour {

	protected Animator mAnimator;

	public int bulletCount;//最大子弹数量
	public int curBulletCount;//当前子弹数量
	public Transform firePoint;//开火点
	public Transform linePoint;//开火点
	public Transform handPoint;//手放的位置
	public F3DFXType FXtype = F3DFXType.FlameRed;
	public LineRenderer line;//

	public virtual void Init(){
		line.SetPosition (0,linePoint.position);
		mAnimator = GetComponent<Animator> ();
	}

	public virtual void Reload(){
		if(mAnimator!=null){
			mAnimator.SetTrigger ("Reload");
		}
	}

	protected virtual void Update(){
		this.DrawLine (transform.forward.normalized*100+linePoint.position);
	}

	public virtual void DrawLine(Vector3 enPoint){
		line.SetPosition (0,linePoint.position);
		line.SetPosition (1,enPoint);
	}

	public virtual void Fire(){
		
	}
}
