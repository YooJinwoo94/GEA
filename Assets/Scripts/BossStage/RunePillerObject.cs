using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunePillerObject : MonoBehaviour
{
    [SerializeField] GameObject redPiller = null;
    [SerializeField] GameObject greenPiller = null;
    public BossPuzzleController.RuneColor pillerState;
    public BossPuzzleController bossPuzzleController;

    // Start is called before the first frame update
    void Start()
    {
        pillerState = BossPuzzleController.RuneColor.Red;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeColor(BossPuzzleController.RuneColor pillerColor)
    {
        if (pillerColor == pillerState) return;

        if (pillerColor == BossPuzzleController.RuneColor.Red)
        {
            redPiller.SetActive(true);
            greenPiller.SetActive(false);
            pillerState = BossPuzzleController.RuneColor.Red;
        }
        else if (pillerColor == BossPuzzleController.RuneColor.Green)
        {
            redPiller.SetActive(false);
            greenPiller.SetActive(true);
            pillerState = BossPuzzleController.RuneColor.Green;
        }
    }
}