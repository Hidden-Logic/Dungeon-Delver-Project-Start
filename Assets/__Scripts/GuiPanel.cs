using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiPanel : MonoBehaviour {

    [Header("Set in Inspector")]
    public Dray dray;
    public Sprite healthEmpty;
    public Sprite healthHalf;
    public Sprite healthFull;

    Text keyCountText;
    List<Image> healthImages;

	// Use this for initialization
	void Start () {
        //key count
        Transform trans = transform.Find("Key Count");
        keyCountText = trans.GetComponent<Text>();
        //health icons
        Transform healthPanel = transform.Find("Health Panel");
        healthImages = new List<Image>();
        if(healthPanel != null)
        {
            for(int i = 0; i < 20; i++)
            {
                trans = healthPanel.Find("H_" + i);
                if (trans == null) break;
                healthImages.Add(trans.GetComponent<Image>());
            }
        }
	}
	
	// Update is called once per frame
	void Update () {
        keyCountText.text = dray.numKeys.ToString();

        int health = dray.health;
        for(int i = 0; i < healthImages.Count; i++)
        {
            if(health > 1)
            {
                healthImages[i].sprite = healthFull;
            }
            else if(health == 1)
            {
                healthImages[i].sprite = healthHalf;
            }
            else
            {
                healthImages[i].sprite = healthEmpty;
            }
            health -= 2;
        }
	}
}
