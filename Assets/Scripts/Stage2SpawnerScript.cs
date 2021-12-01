using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2SpawnerScript : MonoBehaviour
{
    public GameObject Mob;
    public Transform SpawnPos;
    public Transform PlayerTrans;
    public int SpawnCount = 1;
    float timecheck = 0;

    bool once = false;

    void Start()
    {
        PlayerTrans = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
    }

    public IEnumerator Spawn()
    {
        for (int i = 0; i < SpawnCount; i++)
        {
            EnemyCtrl MobCtrl = Instantiate(Mob, SpawnPos.position, SpawnPos.rotation).GetComponent<EnemyCtrl>();
            MobCtrl.SetAttackTarget(PlayerTrans);
            yield return new WaitForSeconds(2.0f);
        }
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && !once)
        {
            StartCoroutine(Spawn());
            once = true;
        }
    }
}
