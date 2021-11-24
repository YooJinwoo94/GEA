using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {
	
	void Damage(AttackArea.AttackInfo attackInfo)
	{
		transform.root.SendMessage("Damage",attackInfo);
	}

	void WDamage(WSkillCtrl.WAttackInfo wAttackInfo)
    {
		transform.root.SendMessage("WDamege", wAttackInfo);
    }

	void EDamage(ESkillCtrl.EAttackInfo eAttackInfo)
	{
		transform.root.SendMessage("EDamege", eAttackInfo);
	}
}
