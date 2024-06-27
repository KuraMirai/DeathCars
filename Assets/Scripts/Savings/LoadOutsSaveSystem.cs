namespace Savings
{
    public class LoadOutsSaveSystem : AbstractSaveSystem<LoadOutsData>
    {
        private const string LoadOutsSavesName = "LoadOutsData";
        
        protected override void SaveData()
        {
            Save(LoadOutsSavesName);
        }

        protected override LoadOutsData LoadAndInitData()
        {
            return Load(LoadOutsSavesName);
        }

        public void ForceSave()
        {
            SaveData();
        }

        public LoadOutsData ForceLoad()
        {
            return LoadAndInitData();
        }
    }
}