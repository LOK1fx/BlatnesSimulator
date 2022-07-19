using UnityEngine;

namespace LOK1game.World
{
    public abstract class GameWorld : MonoBehaviour
    {
        public static GameWorld Current { get; private set; }

        [SerializeField] private EGameModeId _standardGameModeOverride;
        
        protected virtual void Awake()
        {
            Current = this;

            SetGameModeOverride();
        }
        
        private void OnDestroy()
        {
            Current = null;
        }

        private void SetGameModeOverride()
        {
            var gameModeManager = App.ProjectContext.GameModeManager;

            if (_standardGameModeOverride == EGameModeId.None)
            {
                return;
            }

            gameModeManager.SetGameMode(_standardGameModeOverride);
        }

        public abstract void Initialize();
    }
}