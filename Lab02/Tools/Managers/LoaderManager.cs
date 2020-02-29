using System.Windows;

namespace KMA.CSharp2020.Lab02.Tools.Managers
{
    internal class LoaderManager
    {
        #region Fields
        private static readonly object Locker = new object();
        private static LoaderManager _instance;
        private ILoaderOwner _loaderOwner;
        #endregion

        #region Properties
        internal static LoaderManager Instance
        {
            get
            {
                if (_instance != null) return _instance;
                lock (Locker) { return _instance ?? (_instance = new LoaderManager()); }
            }
        }
        #endregion

        private LoaderManager() { }

        #region Methods
        internal void Initialize(ILoaderOwner loaderOwner) { _loaderOwner = loaderOwner; }

        internal void ShowLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Visible;
            _loaderOwner.IsControlEnabled = false;
        }
        internal void HideLoader()
        {
            _loaderOwner.LoaderVisibility = Visibility.Hidden;
            _loaderOwner.IsControlEnabled = true;
        }
        #endregion
    }
}