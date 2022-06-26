using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsWebApp.Data.Enums
{
    //possible Buisness sub categories
    public enum BusinessContactCategory
    {
        Boss,
        Client,
        Coworker,
        Manager
    }

    //mapper clas to translate enum variable to string to be stored in database
    public static class BusinessContactCategoryDictionary
    {
        //directory of possible outcomes
        //if we decide to add another Buisness sub category we will also ned to add entry to this dictionary
        private readonly static Dictionary<BusinessContactCategory, string> 
            businessContactCategoryToStringDictionary = new Dictionary<BusinessContactCategory, string>()
        {
            {BusinessContactCategory.Boss, "Boss"},
            {BusinessContactCategory.Client, "Client"},
            {BusinessContactCategory.Coworker, "Coworker"},
            {BusinessContactCategory.Manager, "Manager"},
        };

        public static string translateBusinessContactCategoryToString(BusinessContactCategory category)
        {
            return businessContactCategoryToStringDictionary[category];
        }
    }
}
