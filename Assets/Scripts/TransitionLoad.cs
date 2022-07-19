using UnityEngine;
using UnityEngine.SceneManagement;

namespace LOK1game
{
    [RequireComponent(typeof(Animator))]
    public class TransitionLoad : MonoBehaviour
    {
        public static bool IsLoading { get; private set; } = false;

        private const string TRIGGER_CLOSE = "SceneClose";
        private const string TRIGGER_OPEN = "SceneOpen";
        
        private static bool _shouldPlayOpeningAnimation = false;
        private static TransitionLoad _instance;

        private Animator _animator;
        private AsyncOperation _loadingOperation;
        private string _loadingSceneName;

        private void Start()
        {
            _instance = this;

            _animator = GetComponent<Animator>();

            if (!_shouldPlayOpeningAnimation) return;
            
            _animator.SetTrigger(TRIGGER_OPEN);
            IsLoading = false;
            _shouldPlayOpeningAnimation = false;
        }

        public static void SwitchToScene(string activeScene, string sceneName)
        {
            if(IsLoading) { return; }

            SceneManager.UnloadSceneAsync(activeScene);
            
            IsLoading = true;
            _instance._animator.SetTrigger(TRIGGER_CLOSE);
            _instance._loadingSceneName = sceneName;
            _instance._loadingOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            _instance._loadingOperation.allowSceneActivation = false;

            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        
        private static void OnSceneLoaded(Scene scene, LoadSceneMode loadMode)
        {
            if (scene.name == _instance._loadingSceneName)
                SceneManager.SetActiveScene(scene);
        }

        public void OnAnimationOver()
        {
            _shouldPlayOpeningAnimation = true;
            _loadingOperation.allowSceneActivation = true;
        }
    }
}