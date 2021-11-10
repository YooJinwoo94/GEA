using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPuzzleController : MonoBehaviour
{
    public enum RuneType
    {
        Sun,
        Connect,
        Fish,
        RCyclone,
        LCyclone,
        Trident
    }

    public enum RuneColor
    {
        Red,
        Green
    }

    [SerializeField] RuneTileObject SunTile;
    [SerializeField] RuneTileObject ConnectTile;
    [SerializeField] RuneTileObject FishTile;
    [SerializeField] RuneTileObject RCycloneTile;
    [SerializeField] RuneTileObject LCycloneTile;
    [SerializeField] RuneTileObject TridentTile;

    [SerializeField] RunePillerObject RCyclonePiller;
    [SerializeField] RunePillerObject TridentPiller;
    [SerializeField] RunePillerObject SunPiller;
    [SerializeField] RunePillerObject FishPiller;

    int puzzleCount;

    // Start is called before the first frame update
    void Start()
    {
        puzzleCount = 0;
        InitPuzzles();
        Invoke("ResetColor", 0.5f);

        ResetColor();
    }

    // Update is called once per frame
    void Update()
    {
        RCyclonePiller.ChangeColor(RCycloneTile.tileState);
        TridentPiller.ChangeColor(TridentTile.tileState);
        SunPiller.ChangeColor(SunTile.tileState);
        FishPiller.ChangeColor(FishTile.tileState);
    }

    public void PushTile()
    {
        puzzleCount++;

        if (puzzleCount >= 4)
        {
            Invoke("ResetColor", 1.5f);
        }
    }

    void ResetColor()
    {
        puzzleCount = 0;
        SunTile.ChangeColor(RuneColor.Red);
        ConnectTile.ChangeColor(RuneColor.Red);
        FishTile.ChangeColor(RuneColor.Red);
        RCycloneTile.ChangeColor(RuneColor.Red);
        LCycloneTile.ChangeColor(RuneColor.Red);
        TridentTile.ChangeColor(RuneColor.Red);

        RCyclonePiller.ChangeColor(RuneColor.Red);
        TridentPiller.ChangeColor(RuneColor.Red);
        FishPiller.ChangeColor(RuneColor.Red);
        SunPiller.ChangeColor(RuneColor.Red);
    }

    void InitPuzzles()
    {
        SunTile.bossPuzzleController = this;
        ConnectTile.bossPuzzleController = this;
        FishTile.bossPuzzleController = this;
        RCycloneTile.bossPuzzleController = this;
        LCycloneTile.bossPuzzleController = this;
        TridentTile.bossPuzzleController = this;

        RCyclonePiller.bossPuzzleController = this;
        TridentPiller.bossPuzzleController = this;
        FishPiller.bossPuzzleController = this;
        SunPiller.bossPuzzleController = this;
    }
}
