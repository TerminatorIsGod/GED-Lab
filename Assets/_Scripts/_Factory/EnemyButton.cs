using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyButton : MonoBehaviour
{
    private EnemyFactory factory;

    private EditorManager editor;

    TextMeshProUGUI btnText;

    // Start is called before the first frame update
    void Start()
    {
        factory = GameObject.Find("Game Manager").GetComponent<EnemyFactory>();

        editor = EditorManager.instance;

        btnText = GetComponentInChildren<TextMeshProUGUI>();
    }

    public void OnClickSpawn()
    {
        switch (btnText.text)
        {
            case "Crab":
                editor.item = factory.GetEnemy("Crab").Create(factory.prefab1);
                break;
            case "Monster":
                editor.item = factory.GetEnemy("Monster").Create(factory.prefab2);
                break;
            default:
                break;
        }

        editor.instantiated = true;
    }

}
