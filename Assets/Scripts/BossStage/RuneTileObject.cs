using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTileObject : MonoBehaviour
{
    enum TileColor {
        Red,
        Green
    }

    [SerializeField] GameObject redTile = null;
    [SerializeField] GameObject greenTile = null;
    TileColor tileState;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    void Start()
    {
        tileState = TileColor.Red;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeMaterial() {
        if (tileState == TileColor.Red) {
            redTile.SetActive(false);
            greenTile.SetActive(true);
            tileState = TileColor.Green;
        }
        else if (tileState == TileColor.Green) {
            redTile.SetActive(true);
            greenTile.SetActive(false);
            tileState = TileColor.Red;
        }
    }
}
