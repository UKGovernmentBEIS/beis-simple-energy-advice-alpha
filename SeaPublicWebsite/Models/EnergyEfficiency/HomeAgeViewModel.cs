﻿using GovUkDesignSystem;
using GovUkDesignSystem.Attributes;
using GovUkDesignSystem.Attributes.ValidationAttributes;
using SeaPublicWebsite.Models.EnergyEfficiency.QuestionOptions;

namespace SeaPublicWebsite.Models.EnergyEfficiency
{
    public class HomeAgeViewModel : GovUkViewModel
    {
        public string Title = "Roughly what year was your property built?";
        public string Description = "Enter the year your proptery was built, approximately. It does not have to be exact. e.g. 1950";
        public string HelpTitle = "Help me determine the year my property was built";
        public string HelpText = "Typically...";
        public QuestionSection Section = QuestionSection.YourHome ;

        [GovUkDisplayNameForErrors(NameAtStartOfSentence = "Year property was built", NameWithinSentence = "year property was built")]
        [GovUkValidateRequired(ErrorMessageIfMissing = "Enter the approximate year that your property was built")]
        [GovUkValidateIntRange(Minimum = 1000, Maximum = 2022)]
        public int? HomeAge { get; set; }
    }
}