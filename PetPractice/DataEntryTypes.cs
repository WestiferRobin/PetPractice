using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PetPractice
{

    public enum GeneralListFlag
    {
        ACITIVITY,
        NOTES,
        REMINDER,
        DEFAULT,
    };

    public enum DataEntryType
    {
        D_ACTIVITY,
        D_NOTES,
        D_DEFAULT
    };

    public enum SnakeTypes
    {
        CORN_SNAKE,
        BALL_PYTHON,
        GREEN_SNAKE,
        PINE_SNAKE,
        GREEN_TREE_PYTHON,
        MILK_SNAKE,
        GARTER_SNAKE,
        WATER_SNAKE,
        BOA_CONSTRICTOR,
        BURMESE_PYTHON,
        RAT_SNAKE,
        ROSY_BOA,
        KING_SNAKE,
        HOGNOSE,
        GOPHER_SNAKE,
        SAND_BOA,
        RAINBOW_BOA,
        OTHER,
    };

    public static class TranslateUtility
    {
        public static string GetBirthDateString(DateTime target)
        {
            return target.Month + "/" + target.Day + "/" + target.Year;
        }
        public static string TranslateType(SnakeTypes type)
        {
            switch (type)
            {
                case SnakeTypes.CORN_SNAKE:
                    return "Corn Snake";
                case SnakeTypes.BALL_PYTHON:
                    return "Ball Python";
                case SnakeTypes.GREEN_SNAKE:
                    return "Green Snake";
                case SnakeTypes.PINE_SNAKE:
                    return "Pine Snake";
                case SnakeTypes.GREEN_TREE_PYTHON:
                    return "Green Tree Python";
                case SnakeTypes.MILK_SNAKE:
                    return "Milk Snake";
                case SnakeTypes.GARTER_SNAKE:
                    return "Garter Snake";
                case SnakeTypes.WATER_SNAKE:
                    return "Water Snake";
                case SnakeTypes.BOA_CONSTRICTOR:
                    return "Boa Constrictor";
                case SnakeTypes.BURMESE_PYTHON:
                    return "Burmese Python";
                case SnakeTypes.RAT_SNAKE:
                    return "Rat Snake";
                case SnakeTypes.ROSY_BOA:
                    return "Rosy Boa";
                case SnakeTypes.KING_SNAKE:
                    return "King Snake";
                case SnakeTypes.HOGNOSE:
                    return "Hognose";
                case SnakeTypes.GOPHER_SNAKE:
                    return "Gopher Snake";
                case SnakeTypes.SAND_BOA:
                    return "Sand Boa";
                case SnakeTypes.RAINBOW_BOA:
                    return "Rainbow Boa";
                case SnakeTypes.OTHER:
                    return "Other";
                default:
                    return "Non Existant";
            }
        }
    }

    public class PetData
    {
        public string ImageUrl { get; set; }        // Later its going to be Photos
        public string Name { get; set; }
        public SnakeTypes PetType { get; set; }
        public string PetGender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Dictionary<string, ObservableCollection<DataEntry>> QueryLogs { get; set; } = new Dictionary<string, ObservableCollection<DataEntry>>();
    }

    public class DataEntry
    {
        public DateTime Date { get; set; }
        public string DateToString { get { return GetDateToString(); } }

        public string Title { get; set; }
        public string FormalTitle { get { return GetFormalTitle(); } }

        public DataEntryType DataEType { get; set; }

        public DataEntry(string title, DataEntryType type = DataEntryType.D_DEFAULT)
        {
            Title = title;
            DataEType = type;
            Date = DateTime.Now;
        }

        private string GetDateToString()
        {
            return Date.Month + "/" + Date.Day + "/" + Date.Year;
        }

        /// <summary>
        /// Design to be overriden. If not just have the Title.
        /// </summary>
        /// <returns></returns>
        private string GetFormalTitle()
        {
            return Title;
        }
    }

    public class WebsiteEntry : DataEntry
    {
        private const string gmailFailback = "www.google.com/search?q=";
        public string Url { get; set; }

        public WebsiteEntry(string title, string url) : base(title)
        {
            ValidateUrl(url);
        }

        private void ValidateUrl(string paramUrl)
        {
            paramUrl.Replace("http://", string.Empty);
            paramUrl.Replace("https://", string.Empty);
            string[] entry = paramUrl.Split('.');

            if (entry.Length >= 3)
            {
                entry[0] = "www";
                entry[2] = GetExtension(entry[2]);
                string buildUrl = string.Empty;
                for (int i = 0; i < 2; i++)
                {
                    buildUrl += string.Concat(entry[i], '.');
                }
                Url = string.Concat(buildUrl, entry[2]);
            }
            else
            {
                Url = string.Concat(gmailFailback, this.Title);
            }
        }

        private string GetExtension(string extension)
        {
            if (extension.Contains("/"))
                return extension;
            switch (extension.ToLower())
            {
                case "com":
                case "org":
                case "edu":
                case "gov":
                    return extension;
                default:
                    return "com";
            }
        }

    }
}
