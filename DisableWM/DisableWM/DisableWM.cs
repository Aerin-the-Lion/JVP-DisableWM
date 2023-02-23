using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BepInEx;
using BepInEx.Configuration;
using UnityEngine;
using HarmonyLib;
using UnityEngine.UI;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace DisableWM
{
    public class DisableWM : MonoBehaviour
    {
        static bool isInject;
        //static GameObject GUI_Camera;
        //static GameObject addText;
        [HarmonyPostfix, HarmonyPatch(typeof(WmController), "Update")]
        static void InjectCode() {
            if(!Main.CFG_IS_ENABLED.Value) { return; }
            Debug.Log("isInject " + isInject);
            Debug.Log("!!!! INJECT CODE STARTED! !!!!");
            if (isInject) { return; }
            //javText = GameObject.Find("Gui Camera").GetComponent<TMPro.TextMeshProUGUI>();
            GameObject GUI_Camera = GameObject.Find("Gui Camera");
            GameObject addText = GUI_Camera.transform.Find("addText").gameObject;
            TMPro.TextMeshProUGUI TextMeshProUGUI = addText.GetComponent<TMPro.TextMeshProUGUI>();
            if (TextMeshProUGUI.enabled)
            {
                TextMeshProUGUI.enabled = false;
            }
            isInject = true;
            Debug.Log("!!!! INJECT CODE ENDED! !!!!");
        }

    }
}
