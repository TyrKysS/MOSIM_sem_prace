using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skills : MonoBehaviour
{
    public static bool likeCamping = false;
    public static bool likeMushroms = false;
    public static bool likeFishing = false;
    public static bool likeSwimming = false;
    
    public Toggle camping;
    public Toggle mushroms;
    public Toggle fishing;
    public Toggle swimming;

    // Přiřazení hodnot k přepínačům
    void Start()
    {
      camping.onValueChanged.AddListener(delegate {
          ToggleValueChangedOccured(camping,"camping");
      });

      mushroms.onValueChanged.AddListener(delegate {
          ToggleValueChangedOccured(mushroms,"mushroms");
      });

      fishing.onValueChanged.AddListener(delegate {
          ToggleValueChangedOccured(fishing,"fishing");
      });

      swimming.onValueChanged.AddListener(delegate {
          ToggleValueChangedOccured(swimming, "swimming");
      });
    }
    // Pokud je zaškrtnutu, přiřaď hodnotu proměnné TRUE/FALSE
    void ToggleValueChangedOccured (Toggle toggle, string type)
    {
        switch(type)
        {
            case "camping":
                likeCamping = toggle.isOn;
                break;
            case "mushroms":
                likeMushroms = toggle.isOn;
                break;
            case "fishing":
                likeFishing = toggle.isOn;
                break;
            case "swimming":
                likeSwimming = toggle.isOn;
                break;
        }
    }
}
