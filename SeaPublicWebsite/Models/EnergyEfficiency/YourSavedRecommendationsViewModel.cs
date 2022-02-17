﻿using System;
using GovUkDesignSystem;
using SeaPublicWebsite.DataModels;
using System.Collections.Generic;
using System.Linq;
using SeaPublicWebsite.Models.EnergyEfficiency.Recommendations;

namespace SeaPublicWebsite.Models.EnergyEfficiency
{
    public class YourSavedRecommendationsViewModel : GovUkViewModel
    {
        public UserDataModel UserDataModel { get; set; }

        public string GetTotalInstallationCostText()
        {
            var minCost = GetSavedRecommendations().Sum(r => r.MinInstallCost);
            var maxCost = GetSavedRecommendations().Sum(r => r.MaxInstallCost);
            return $"{minCost:C0} - {maxCost:C0}";
        }

        public List<UserRecommendation> GetSavedRecommendations()
        {
            return UserDataModel.UserRecommendations.Where(r => r.RecommendationAction == RecommendationAction.SaveToActionPlan).ToList();
        }
        public List<UserRecommendation> GetDecideLaterRecommendations()
        {
            return UserDataModel.UserRecommendations.Where(r => r.RecommendationAction == RecommendationAction.DecideLater).ToList();
        }
         
        public string GetTotalSavingText()
        {
            var saving = GetSavedRecommendations().Sum(r => r.Saving);
            return $"{saving:C0} a year";
        }
        public string GetInstallationCostText(UserRecommendation recommendation)
        {
            return $"{recommendation.MinInstallCost:C0} - {recommendation.MaxInstallCost:C0}";
        }

        public string GetSavingText(UserRecommendation recommendation)
        {
            return $"{recommendation.Saving:C0}";
        }
    }
}