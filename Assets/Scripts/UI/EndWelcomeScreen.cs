using System;
using UnityEngine;

namespace LOK1game.UI
{
    [RequireComponent(typeof(ShotsScreensSwitcher))]
    public class EndWelcomeScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _welcomePanel;
        [SerializeField] private float _destroyTime = 2f;
        [SerializeField] private CanvasGroupAlphaEvolutor _alphaEvolutor;
        
        private ShotsScreensSwitcher _shotsSwitcher;

        private void Awake()
        {
            _shotsSwitcher = GetComponent<ShotsScreensSwitcher>();
            
            _shotsSwitcher.OnEndReached.AddListener(OnShotChanged);
        }

        private void OnShotChanged()
        {
            _alphaEvolutor.SetTargetAlpha(0);
                
            Destroy(_welcomePanel, _destroyTime);
        }

        private void OnDestroy()
        {
            _shotsSwitcher.OnEndReached.RemoveListener(OnShotChanged);
        }
    }
}