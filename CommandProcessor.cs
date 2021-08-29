using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ILYTATTools.Patterns
{
    public class CommandProcessor : MonoBehaviour
    {
        private List<Command> commands = new List<Command>();
        private int currentCommandIndex;

        public void ExecuteCommand(Command c)
        {
            commands.Add(c);
            c.Execute();
            currentCommandIndex = commands.Count - 1;
        }
    }
}