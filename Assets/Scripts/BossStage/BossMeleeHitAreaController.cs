using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeHitAreaController : MonoBehaviour
{
    public float atkDelayTime = 1.5f;
    public float atkAreaSize = 120.0f;
    [SerializeField] GameObject hitArea;
    [SerializeField] Projector projector;
    bool isTriggered = false;
    // Start is called before the first frame update
    void Start()
    {
        projector.fieldOfView = 10.0f;
        projector.material.color = new Color(1, 0.5f, 0.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (isTriggered) return;

        if (projector.fieldOfView >= atkAreaSize)
        {
            projector.fieldOfView = atkAreaSize;
            projector.material.color = new Color(1, 0, 0);
            hitArea.SetActive(true);
            isTriggered = true;
        }
        
        projector.fieldOfView += (atkAreaSize / atkDelayTime) * Time.deltaTime;
    }
}
