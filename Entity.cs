using UnityEngine;

namespace ILYTATTools.Patterns
{
    [RequireComponent(typeof(InputReader))]
    [RequireComponent(typeof(CommandProcessor))]
    public class Entity : MonoBehaviour, IEntity
    {
        private InputReader inputReader;
        private CommandProcessor commandProcessor;

        private void Awake()
        {
            inputReader = GetComponent<InputReader>();
            commandProcessor = GetComponent<CommandProcessor>();
        }

        private void Update()
        {
            GetComponent<MovableRestrictions2D>().MoveWithinConstraints();
            var dir = inputReader.ReadInput();
            if (dir != Vector3.zero)
            {
                var mc = new MoveCommand(this, dir);
                commandProcessor.ExecuteCommand(mc);
            }

            if (inputReader.ReadShoot())
            {
                commandProcessor.ExecuteCommand(new ShootCommand(this));
            }
        }

        public void MoveFromTo(Vector3 startPosition, Vector3 endPosition)
        {
            throw new System.NotImplementedException();
        }
    }
}