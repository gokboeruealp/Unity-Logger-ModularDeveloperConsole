namespace Gokboerue.Tools
{
    public class Command_Clear : CommandBase
    {
        public override void RunCommand(string[] commandParts)
        {
            base.RunCommand(commandParts);

            if (commandParts.Length == 1)
            {
                DeveloperConsole.I.ClearConsole();
            }
            else
            {
                Log.E("Command 'clear' does not have any flags.");
            }
        }
    }
}
