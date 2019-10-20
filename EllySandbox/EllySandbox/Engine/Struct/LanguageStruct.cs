namespace EllySandbox.Engine.Struct
{
    [System.Serializable]
    public struct LanguageStruct
    {
        public string LanguageTag;
        public LanguageCategory[] Categories;

        public LanguageStruct(string languageTag, LanguageCategory[] categories)
        {
            LanguageTag = languageTag;
            Categories = categories;
        }
    }

    [System.Serializable]
    public struct LanguageCategory
    {
        public string CategoryID;
        public LanguageLabel[] Labels;

        public LanguageCategory(string id, LanguageLabel[] labels)
        {
            CategoryID = id;
            Labels = labels;
        }
    }

    [System.Serializable]
    public struct LanguageLabel
    {
        public string LabelID;
        public string StringValue;

        public LanguageLabel(string iD, string stringValue)
        {
            LabelID = iD;
            StringValue = stringValue;
        }
    }
}
