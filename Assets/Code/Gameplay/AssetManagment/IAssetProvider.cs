using UnityEngine;

namespace Code.Gameplay.AssetManagment
{
    public interface IAssetProvider
    {
        GameObject LoadAsset(string path);
        T LoadAsset<T>(string path) where T : Component;
    }
}