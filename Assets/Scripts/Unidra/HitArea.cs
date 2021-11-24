using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {
	
	void Damage(AttackArea.AttackInfo attackInfo)
	{
		transform.root.SendMessage("Damage",attackInfo);
	}

	//void WDamage(WSkillCtrl.WAttackInfo wattackinfo)
 //   {
	//	transform.root.SendMessage("WDamege", wattackinfo);
 //   }

	//void EDamage(ESkillCtrl.EAttackInfo eattackinfo)
	//{
	//	transform.root.SendMessage("EDamege", eattackinfo);
	//}
}
