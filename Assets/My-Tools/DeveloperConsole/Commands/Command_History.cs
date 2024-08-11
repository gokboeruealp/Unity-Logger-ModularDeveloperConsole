namespace Gokboerue.Tools
{
    public class Command_History : CommandBase
    {
        public override void RunCommand(string[] commandParts)
        {
            base.RunCommand(commandParts);

            if (commandParts.Length == 1)
            {
                foreach (string command in DeveloperConsole.I.CommandHistory)
                {
                    Log.L($"history: {command}");
                }
            }
            else
            {
                Log.E("Command 'history' does not have any flags.");
            }
        }
    }
}
