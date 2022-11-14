using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PrototypeFactory : MonoBehaviour
{
    public List<CollectibleData> allData;

    public GameObject buttonPanel;
    public GameObject buttonPrefab;

    public GameObject platformPrefab;
    public TMP_InputField widthInput;
    public TMP_InputField heightInput;

    int platformWidth;
    int platformHeight;

    private EditorManager editor;

    Coin coinPrototype;
    BlueGem blueGemPrototype;
    GreenGem greenGemPrototype;
    PinkGem pinkGemPrototype;
    FullHeart heartPrototype;
    customizablePlatform platformPrototype;

    // Start is called before the first frame update
    void Start()
    {
        editor = EditorManager.instance;

        coinPrototype = new Coin(allData[0]._prefab, allData[0]._score);
        blueGemPrototype = new BlueGem(allData[1]._prefab, allData[1]._score);
        greenGemPrototype = new GreenGem(allData[2]._prefab, allData[2]._score);
        pinkGemPrototype = new PinkGem(allData[3]._prefab, allData[3]._score);
        heartPrototype = new FullHeart(allData[4]._prefab, allData[4]._heal);

        for(int i = 0; i < allData.Count; i++)
        {
            var button = Instantiate(buttonPrefab);
            button.transform.SetParent(buttonPanel.transform);
            button.gameObject.name = allData[i].name + " Button";
            button.GetComponentInChildren<TextMeshProUGUI>().text = allData[i].name;
            button.GetComponent<Button>().onClick.AddListener(delegate { Spawner(button); });
        }
    }

    void Spawner(GameObject button)
    {
        var btn = button.GetComponentInChildren<TextMeshProUGUI>();

        switch (btn.text)
        {
            case "Coin":
                editor.item = coinPrototype.Clone().Spawn();
                break;
            case "BlueGem":
                editor.item = blueGemPrototype.Clone().Spawn();
                break;
            case "GreenGem":
                editor.item = greenGemPrototype.Clone().Spawn();
                break;
            case "PinkGem":
                editor.item = pinkGemPrototype.Clone().Spawn();
                break;
            case "FullHeart":
                editor.item = heartPrototype.Clone().Spawn();
                break;
            default:
                break;
        }

        editor.instantiated = true;
    }

    public void platformClone()
    {
        platformWidth = int.Parse(widthInput.text);
        platformHeight = int.Parse(heightInput.text);

        if(platformWidth != 0 && platformHeight != 0)
        { 
            platformPrototype = new customizablePlatform(platformWidth, platformHeight, platformPrefab);
            editor.item = platformPrototype.clone().spawn();
            editor.instantiated = true;
        }

    }
}
