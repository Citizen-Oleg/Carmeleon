using System.Collections.Generic;
using Newtonsoft.Json;
using ResourceManager;
using ScriptsMenu.Map;
using ScriptsMenu.Tree;
using UnityEngine;

namespace SaveSystem
{
    public class LoadManager : MonoBehaviour
    {
        public DefaultSave DefaultSave => _defaultSave;

        [SerializeField]
        private DefaultSave _defaultSave;
        
        public List<Resource> LoadResource()
        {
            var resourceSave = PlayerPrefs.GetString(GlobalConstant.SAVE_RESOURCE);
            var resource = string.IsNullOrEmpty(resourceSave) 
                ? _defaultSave.Resources 
                : JsonConvert.DeserializeObject<List<Resource>>(resourceSave);
            return resource;
        }

        public List<LevelData> LoadLevelPassed()
        {
            var levelSave = PlayerPrefs.GetString(GlobalConstant.SAVE_LEVEL);
            var passedLevel = string.IsNullOrEmpty(levelSave)
                ? new List<LevelData>()
                : JsonConvert.DeserializeObject<List<LevelData>>(levelSave);
            return passedLevel;
        }

        public List<TalentData> LoadTalent()
        {
            var talentSave = PlayerPrefs.GetString(GlobalConstant.SAVE_TALENT);
            var activeTalent = string.IsNullOrEmpty(talentSave)
                ? new List<TalentData>()
                : JsonConvert.DeserializeObject<List<TalentData>>(talentSave);
            return activeTalent;
        }
    }
}
