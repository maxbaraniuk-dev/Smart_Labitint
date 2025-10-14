using AppStates;
using Infrastructure;
using UnityEngine;

public class AppLoader : MonoBehaviour
{
    private void Start()
    {
        LoadApp();
    }

    private void LoadApp()
    {
        Context.GetAllSystems()
               .ForEach(system => system.Initialize());
        
        Context.AppStateMachine.Enter<LobbyState>();
    }
}
