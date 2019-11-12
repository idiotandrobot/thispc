namespace ThisPC
{
    public class FolderKey
    {
        private RootKey RootKey;

        public string Key { get; private set; }

        public FolderKey(string key, RootKey rootKey)
        {
            RootKey = rootKey;
            Key = key;
        }

        public bool Exists
        {
            get
            {
                return RootKey.HasSubKey(Key);
            }
            set
            {
                if (value)
                    Add();
                else
                    Remove();
            }
        }

        public void Add()
        {
            if (!Exists) RootKey.AddSubKey(Key);
        }

        public void Remove()
        {
            if (Exists) RootKey.RemoveSubKey(Key);
        }
    }
}
