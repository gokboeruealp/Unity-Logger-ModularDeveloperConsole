namespace Gokboerue.Tools
{
    public class Command_Help : CommandBase
    {
        public override void RunCommand(string[] commandParts)
        {
            base.RunCommand(commandParts);

            if (commandParts.Length == 1)
            {
                foreach (CommandBase command in DeveloperConsole.I.CommandManager.Commands)
                {
                    Log.L($"{command.GetWord()} - {command.GetHelp()}");
                }
            }
            else
            {
                Log.E("Command 'help' does not have any flags.");
            }
        }
    }
}
