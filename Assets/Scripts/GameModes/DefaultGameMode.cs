using System.Collections;

namespace LOK1game.Game
{
    public sealed class DefaultGameMode : BaseGameMode
    {
        public override EGameModeId Id => EGameModeId.Default;

        public override IEnumerator OnStart()
        {
            State = EGameModeState.Starting;

            SpawnGameModeObject(UiPrefab, "UI_", "");

            State = EGameModeState.Started;

            yield return null;
        }

        public override IEnumerator OnEnd()
        {
            State = EGameModeState.Ending;

            yield return DestroyAllGameModeObjects();

            State = EGameModeState.Ended;
        }
    }
}