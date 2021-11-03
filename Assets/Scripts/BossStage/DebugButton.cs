using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugButton : MonoBehaviour
{
    [SerializeField] RuneTileObject runeTileObject;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(() => {
            runeTileObject.ChangeMaterial();
        });
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
