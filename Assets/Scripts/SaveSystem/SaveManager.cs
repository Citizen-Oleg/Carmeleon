using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class SaveManager : MonoBehaviour
    {
        public void SaveTalent()
        {
            var activeTalents = GameManager.PlayerData.ActivatedTalentDatas;
            var serializeTalents = JsonConvert.SerializeObject(activeTalents);
            PlayerPrefs.SetString(GlobalConstant.SAVE_TALENT, serializeTalents);
        }

        public void SaveResource()
        {
            var resource = GameManager.ResourceManagerGame.GetResources();
            var serializeResource = JsonConvert.SerializeObject(resource);
            PlayerPrefs.SetString(GlobalConstant.SAVE_RESOURCE, serializeResource);
        }

        public void SaveLevel()
        {
            var passedLevel = GameManager.PlayerData.PassedLevel;
            var serializeLevel = JsonConvert.SerializeObject(passedLevel);
            PlayerPrefs.SetString(GlobalConstant.SAVE_LEVEL, serializeLevel);
        }
    }
}
