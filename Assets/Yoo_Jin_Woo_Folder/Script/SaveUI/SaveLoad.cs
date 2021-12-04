using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveLoad : MonoBehaviour
{
    [SerializeField]
    Slider _IngameSoundUISlider;

    [SerializeField]
    AudioSource _audiosource;




    public void SaveUIData()
    {
        SaveUIData save = new SaveUIData();

        save._soundValue = _IngameSoundUISlider.value;

        SaveLoadUIDataManager.save(save);
    }

    public void loadUIData()
    {
        SaveUIData load = SaveLoadUIDataManager.load();

        _audiosource.volume = load._soundValue;
    }



    private void Start()
    {
        loadUIData();
    }

    private void Update()
    {
        Debug.Log(_IngameSoundUISlider.value);
    }
}
