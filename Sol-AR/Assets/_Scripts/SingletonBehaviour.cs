using UnityEngine;

namespace SingletonUtility
{
    /// <summary>
    /// Turns any MonoBehaviour into a Singleton
    /// <para>
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        #region Variables
        #region Public
        /// <summary>
        /// Whether an instance exists
        /// </summary>
        public static bool Exists
        {
            get { return instance != null; }
        }

        /// <summary>
        /// Singleton-Reference
        /// Auto-Creates GameObject if it does not exist
        /// </summary>
        public static T Instance
        {
            get
            {
                if (instance != null)
                    return instance;
                GameObject obj = new GameObject
                {
                    name = typeof(T).Name + "-Manager"
                };
                instance = obj.AddComponent<T>();
                return instance;
            }
            protected set { instance = value; }
        }
        #endregion

        #region Private
        /// <summary>
        /// Internal Singleton-Reference
        /// </summary>
        protected static T instance { get; private set; } // protected get so it can be overridden through inheritance
        #endregion

        #region Instance
        /// <summary>
        /// Whether this Singleton has a Root-Object. If true, root-Object will be added to DontDestroyOnLoad instead
        /// </summary>
        [SerializeField]
        [Tooltip("Whether this Singleton has a Root-Object. If true, root-Object will be added to DontDestroyOnLoad instead")]
        private bool hasRootObject;
        #endregion
        #endregion

        #region Methods
        /// <summary>
        /// Singleton-Setup
        /// </summary>
        protected virtual void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            if (!hasRootObject)
                DontDestroyOnLoad(gameObject);
            else
                DontDestroyOnLoad(transform.root.gameObject);
            instance = this as T;
        }

        /// <summary>
        /// Singleton-Destruction
        /// </summary>
        protected virtual void OnDestroy()
        {
            if (Exists && instance == this)
                instance = null;
        }
        #endregion
    }
}