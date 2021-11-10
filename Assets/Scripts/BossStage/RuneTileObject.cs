using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuneTileObject : MonoBehaviour
{
    [SerializeField] GameObject redTile = null;
    [SerializeField] GameObject greenTile = null;
    public BossPuzzleController.RuneType tileRuneType;
    public BossPuzzleController.RuneColor tileState;
    public BossPuzzleController bossPuzzleController;

    // Start is called before the first frame update
    void Awake()
    {
        tileState = BossPuzzleController.RuneColor.Green;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Player")) {
            if (tileState == BossPuzzleController.RuneColor.Red) {
                ChangeColor();
                bossPuzzleController.PushTile(tileRuneType);
            }
        }
    }

    public void ChangeColor()
    {
        if (tileState == BossPuzzleController.RuneColor.Red)
        {
            redTile.SetActive(false);
            greenTile.SetActive(true);
            tileState = BossPuzzleController.RuneColor.Green;
        }
        else if (tileState == BossPuzzleController.RuneColor.Green)
        {
            redTile.SetActive(true);
            greenTile.SetActive(false);
            tileState = BossPuzzleController.RuneColor.Red;
        }
    }

    public void ChangeColor(BossPuzzleController.RuneColor tileColor)
    {
        if (tileState == tileColor) return;
        if (tileColor == BossPuzzleController.RuneColor.Red)
        {
            redTile.SetActive(true);
            greenTile.SetActive(false);
            tileState = BossPuzzleController.RuneColor.Red;
        }
        else if (tileColor == BossPuzzleController.RuneColor.Green)
        {
            redTile.SetActive(false);
            greenTile.SetActive(true);
            tileState = BossPuzzleController.RuneColor.Green;
        }
    }
}
