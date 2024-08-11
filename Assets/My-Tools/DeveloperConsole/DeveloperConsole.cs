using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Gokboerue.Tools
{
    [RequireComponent(typeof(CommandManager))]
    public class DeveloperConsole : MonoBehaviour
    {
        #region Singleton
        private static DeveloperConsole _i;
        public static DeveloperConsole I
        {
            get
            {
                if (_i == null)
                {
                    _i = FindObjectOfType<DeveloperConsole>();
                }

                return _i;
            }
        }

        private CommandManager _commandManager;

        private void Awake()
        {
            _commandManager = GetComponent<CommandManager>();

            if (_commandManager == null)
            {
                Log.E("CommandManager not found.");
            }
        }

        public CommandManager CommandManager => _commandManager;
        #endregion

        private bool _isConsoleActive = true;

        [SerializeField] private Transform consolePanel;
        [SerializeField] private TMP_InputField textInput;
        [SerializeField] private TextMeshProUGUI consoleTextPrefab;

        private List<string> commandHistory = new List<string>();
        private int currentCommandIndex = -1;
        
        public List<string> CommandHistory => commandHistory;

        private void Update()
        {
            if (_isConsoleActive)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    string command = textInput.text;
                    if (!string.IsNullOrEmpty(command))
                    {
                        _commandManager.RunCommand(command);
                        commandHistory.Add(command);
                        currentCommandIndex = commandHistory.Count;
                        ClearTextInput();
                    }

                    textInput.ActivateInputField();
                }

                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    ShowPreviousCommand();
                }
                else if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    ShowNextCommand();
                }
            }
        }

        private void ShowPreviousCommand()
        {
            if (currentCommandIndex > 0)
            {
                currentCommandIndex--;
                textInput.text = commandHistory[currentCommandIndex];
                textInput.caretPosition = textInput.text.Length;
            }
        }

        private void ShowNextCommand()
        {
            if (currentCommandIndex < commandHistory.Count - 1)
            {
                currentCommandIndex++;
                textInput.text = commandHistory[currentCommandIndex];
                textInput.caretPosition = textInput.text.Length;
            }
            else
            {
                currentCommandIndex = commandHistory.Count;
                ClearTextInput();
            }
        }

        private void Start()
        {
            SetConsoleTexts();
        }

        internal void SetConsoleTexts()
        {
            List<string> commands = Log.ReadLog();

            foreach (string command in commands)
            {
                Debug.Log(command);
                AddText(command);
            }
        }

        internal void ClearTextInput()
        {
            textInput.text = "";
        }

        internal void ClearConsole()
        {
            Log.ClearLog();
            ClearCurrentConsole();
        }

        internal void ClearCurrentConsole()
        {
            foreach (TextMeshProUGUI text in consolePanel.transform.GetComponentsInChildren<TextMeshProUGUI>())
            {
                Destroy(text.gameObject);
            }
        }

        internal void ToggleConsole()
        {
            _isConsoleActive = !_isConsoleActive;

            if (_isConsoleActive)
            {
                gameObject.SetActive(true);
                Log.C("Developer Console is active.", Color.green);

                textInput.ActivateInputField();
            }
            else
            {
                gameObject.SetActive(false);
                Log.C("Developer Console is inactive.", Color.cyan);

                textInput.DeactivateInputField();
            }

            textInput.text = "";
        }

        internal TextMeshProUGUI AddText(string text)
        {
            TextMeshProUGUI textMesh = Instantiate(consoleTextPrefab, consolePanel);
            textMesh.text = text;
            return textMesh;
        }
    }
}