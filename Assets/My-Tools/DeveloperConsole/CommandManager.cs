using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Gokboerue.Tools
{
    public class CommandManager : MonoBehaviour
    {
        [SerializeField] private List<CommandBase> commands;
        private Dictionary<string, CommandBase> _commandDictionary;
        
        public List<CommandBase> Commands => commands;

        private void Awake()
        {
            InitializeCommandDictionary();
        }

        private void InitializeCommandDictionary()
        {
            _commandDictionary = commands.ToDictionary(cmd => cmd.GetWord(), cmd => cmd);
        }

        public void RunCommand(string command)
        {
            string[] commandParts = command.Split(' ');

            if (commandParts.Length == 0)
            {
                Log.E("Command is empty.");
                DeveloperConsole.I.ClearTextInput();
                return;
            }

            if (_commandDictionary.TryGetValue(commandParts[0], out CommandBase commandBase))
            {
                commandBase.RunCommand(commandParts);
            }
            else
            {
                Log.E($"Command '{commandParts[0]}' not found.");
            }
            
            DeveloperConsole.I.ClearTextInput();
        }
    }
}
