using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace LOK1game.UI
{
    public class ShotsScreensSwitcher : MonoBehaviour
    {
        #region Events

        public UnityEvent OnShotChanged;
        public UnityEvent OnEndReached;

        #endregion
        
        public int CurrentIndex { get; private set; }
        
        [SerializeField] private List<GameObject> _shots;
        [SerializeField] private int _startShotIndex;

        private void Awake()
        {
            ShowShot(_startShotIndex);
        }

        public void ShowNextShot()
        {
            if(CurrentIndex + 1 >= _shots.Count)
                OnEndReached?.Invoke();
            
            ShowShot(CurrentIndex + 1);
        }

        public void ShowPreviousShot()
        {
            ShowShot(CurrentIndex - 1);
        }
        
        public void ShowShot(int index)
        {
            if(index >= _shots.Count || index < 0) { return; }
            
            HideAll();

            CurrentIndex = index;
            _shots[index].SetActive(true);
            
            OnShotChanged?.Invoke();
        }

        public int GetLength()
        {
            return _shots.Count;
        }

        private void HideAll()
        {
            foreach (var shot in _shots)
            {
                shot.SetActive(false);
            }
        }
    }

}