﻿using System.Collections.Generic;
using System.Linq;
using SeaPublicWebsite.DataModels;
using SeaPublicWebsite.Models.EnergyEfficiency;

namespace SeaPublicWebsite.DataStores
{
    public static class RecommendationService
    {
        private static readonly List<Recommendation> Recommendations =
             new()
             {
                new Recommendation
                {
                    Key = RecommendationKey.AddLoftInsulation,
                    Title = "Add some loft insulation",
                    MinInstallCost = 300,
                    MaxInstallCost = 700,
                    Saving = 45,
                    Summary = "Increase the level of insulation in your loft to the recommended level of 300mm"
                },
                new Recommendation
                {
                    Key = RecommendationKey.GroundFloorInsulation,
                    Title = "Insulate the ground floor",
                    MinInstallCost = 1200,
                    MaxInstallCost = 1800,
                    Saving = 75,
                    Summary = "Lift the floor boards up and fit insulation in the gap beneath them"
                },
                new Recommendation
                {
                    Key = RecommendationKey.UpgradeHeatingControls,
                    Title = "Upgrade your heating controls",
                    MinInstallCost = 150,
                    MaxInstallCost = 400,
                    Saving = 75,
                    Summary = "Fit a programmer, thermostat and thermostatic radiator valves"
                },
                new Recommendation
                {
                    Key = RecommendationKey.FitNewWindows,
                    Title = "Fit new windows",
                    MinInstallCost = 3000,
                    MaxInstallCost = 5000,
                    Saving = 175,
                    Summary = "Replace old single glazed windows with new double or triple glazing"
                },
                new Recommendation
                {
                    Key = RecommendationKey.InsulateCavityWalls,
                    Title = "Insulate your cavity walls",
                    MinInstallCost = 700,
                    MaxInstallCost = 1200,
                    Saving = 185,
                    Summary = "Inject insulation into the cavity in your external walls"
                },
                new Recommendation
                {
                    Key = RecommendationKey.SolarElectricPanels,
                    Title = "Fit solar electric panels",
                    MinInstallCost = 3500,
                    MaxInstallCost = 5500,
                    Saving = 220,
                    Summary = "Install PV panels on your roof to generate electricity"
                }
            };

        public static List<Recommendation> GetRecommendations()
        {
            return Recommendations;
        }

        public static Recommendation GetRecommendation(int id)
        {
            return Recommendations.First(r => (int)r.Key == id);
        }

        public static List<Recommendation> GetRecommendationsForUser(UserDataModel answers)
        {
            var userRecommendationKeys = new List<RecommendationKey>
            {

                // Always shown
                RecommendationKey.UpgradeHeatingControls,

                // Glazing is single or both
                RecommendationKey.FitNewWindows,

                // User has uninsulated cavity walls OR don't know and property 1930-1995
                RecommendationKey.InsulateCavityWalls,

                // Not for ground floor or mid floor flat, or if loft is insulated/ flat roof
                RecommendationKey.AddLoftInsulation,

                // Not for mid or top floor flat
                RecommendationKey.GroundFloorInsulation,

                // Not on ground or mid floor flat
                RecommendationKey.SolarElectricPanels
            };

            return Recommendations.Where(r => userRecommendationKeys.Contains(r.Key)).ToList();
        }
    }
}