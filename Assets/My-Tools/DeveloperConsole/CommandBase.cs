using UnityEngine;

namespace Gokboerue.Tools
{
    public abstract class CommandBase : MonoBehaviour
    {
        [SerializeField] private string Word;
        [SerializeField] [TextArea] private string Help;
        [SerializeField] private string[] Flags;

        public virtual void RunCommand(string[] commandParts)
        {
            DeveloperConsole.I.ClearTextInput();
        }

        public string GetWord()
        {
            return Word;
        }

        public string GetHelp()
        {
            return Help;
        }

        public string[] GetFlags()
        {
            return Flags;
        }
    }
}
