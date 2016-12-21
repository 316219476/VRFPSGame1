/*******************
********************/
using UnityEngine;
using System.Collections;

public class ShotGunFinal : AWeapon {
	public ParticleSystem shell;
	public float circleTime = 0.5f;
	public override void Init ()
	{
		base.Init ();

	}


	public override void Fire ()
	{
		if (curTime <= 0) {
			curTime = circleTime;
			F3DFXController.instance.DefaultFXType = FXtype;
			F3DFXController.instance.Fire (this.firePoint, shell);
		}

	}

	float curTime= 0;
	protected override void Update ()
	{
		base.Update ();
		curTime -= Time.deltaTime;
		if (curTime < 0) {
			curTime = 0;
		}
	}
}
