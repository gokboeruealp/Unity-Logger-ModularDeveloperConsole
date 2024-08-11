using UnityEngine;

namespace Gokboerue.Tools
{
    public class DeveloperConsoleHandler : MonoBehaviour
    {
        private void Awake()
        {
            if(DeveloperConsole.I == null)
            {
                DeveloperConsole developerConsole = Resources.Load<DeveloperConsole>("DeveloperConsole");
                GameObject developerConsoleGo = Instantiate(developerConsole).gameObject;
                developerConsoleGo.name = "DeveloperConsole";
                developerConsoleGo.transform.SetParent(transform);

                if(DeveloperConsole.I == null)
                {
                    Log.E("DeveloperConsole not found.");
                    Log.W("Please make sure that the DeveloperConsole prefab is in the Resources folder.");
                }
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.BackQuote))
            {
                DeveloperConsole.I.ToggleConsole();
            }
        }
    }
}
