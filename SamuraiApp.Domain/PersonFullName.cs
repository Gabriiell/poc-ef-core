using System;
using System.Collections.Generic;

namespace SamuraiApp.Domain
{
    public class PersonFullName
    {
        public PersonFullName(string givenName, string surName)
        {
            GivenName = givenName;
            SurName = surName;
        }

        public string GivenName { get; set; }
        public string SurName { get; set; }
        public string FullName => $"{GivenName} {SurName}";
        public string FullNameReverse => $"{SurName}, {GivenName}";
    }
}
