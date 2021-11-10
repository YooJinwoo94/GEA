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
    [SerializeField] GameObject SuccessLight;
    int puzzleCount;
    bool clearPuzzleBoolen = false;
    List<RuneType> runeCorrectionList = new List<RuneType>();

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

    public void PushTile(RuneType _tileRuneType)
    {
        if(clearPuzzleBoolen) return;
        puzzleCount++;
        runeCorrectionList.Add(_tileRuneType);
        if (puzzleCount >= 4)
        {
            CheckRuneTile();
        }
    }

    void CheckRuneTile() {
        if (runeCorrectionList[0] == RuneType.RCyclone && 
            runeCorrectionList[1] == RuneType.Trident &&
            runeCorrectionList[2] == RuneType.Sun && 
            runeCorrectionList[3] == RuneType.Fish) 
        {
            ClearPuzzle();
        }
        else {
            Invoke("ResetColor", 0.5f);
        }
    }

    void ClearPuzzle () {
        SuccessLight.SetActive(true);
        clearPuzzleBoolen = true;
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
        SunTile.tileRuneType = RuneType.Sun;
        ConnectTile.bossPuzzleController = this;
        ConnectTile.tileRuneType = RuneType.Connect;
        FishTile.bossPuzzleController = this;
        FishTile.tileRuneType = RuneType.Fish;
        RCycloneTile.bossPuzzleController = this;
        RCycloneTile.tileRuneType = RuneType.RCyclone;
        LCycloneTile.bossPuzzleController = this;
        LCycloneTile.tileRuneType = RuneType.LCyclone;
        TridentTile.bossPuzzleController = this;
        TridentTile.tileRuneType = RuneType.Trident;

        RCyclonePiller.bossPuzzleController = this;
        TridentPiller.bossPuzzleController = this;
        FishPiller.bossPuzzleController = this;
        SunPiller.bossPuzzleController = this;
    }
}
