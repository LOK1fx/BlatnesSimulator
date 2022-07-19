using System.Collections;

namespace LOK1game.Game
{
    public class IntroGameMode : BaseGameMode
    {
        public override EGameModeId Id => EGameModeId.Intro;

        public override IEnumerator OnStart()
        {
            State = EGameModeState.Starting;

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