using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LOK1game.Tools;

namespace LOK1game.World
{
    public class IntroWorld : GameWorld
    {
        public override void Initialize()
        {
        }

        public void LoadMainLevel()
        {
            TransitionLoad.SwitchToScene(Scenes.INTRO, Scenes.MAIN);
        }
    }
}