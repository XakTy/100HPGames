using System.Collections;
using LeopotamGroup.Globals;
using UnityEngine;

namespace Core
{
    class Boot : MonoBehaviour
    {
        public StaticData StaticData;
        IEnumerator Start()
        {
            Service<StaticData>.Set(StaticData);
           
            GameInitialization.FullInit();

            Progress.SetUI(Service<UI>.Get());

				yield return null;
            Levels.LoadCurrent();
        }
    }
}