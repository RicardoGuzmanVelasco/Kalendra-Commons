using System;
using Kalendra.Time.Domain;
using UnityEngine;
using Zenject;

public class TestInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var timePassageSingle = new TimePassage(DateTime.Now);
        Container.BindInterfacesAndSelfTo<TimePassage>().FromInstance(timePassageSingle);
    }
}