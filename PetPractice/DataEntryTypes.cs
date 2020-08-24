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

    public static class TranslateUtility
    {
        public static string GetBirthDateString(DateTime target)
        {
            return target.Month + "/" + target.Day + "/" + target.Year;
        }
    }

    public class PetData
    {
        public Uri ImageUrl { get; set; }        // Later its going to be Photos
        public string Name { get; set; }
        public string PetType { get; set; }
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
