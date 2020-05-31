﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.FeatureManagement;
using System.Threading.Tasks;

namespace chapter02.Controllers
{
    public class HomeController : Controller
    {
        private readonly LoggingSettings _settings;
        private readonly IFeatureManager _featureManager;

        public HomeController(IOptionsSnapshot<LoggingSettings> settings, IFeatureManager featureManager)
        {
            _settings = settings.Value;

            _featureManager = featureManager;

            var consoleSettings = settings.Get("Console");
        }

        public async Task<IActionResult> Index()
        {
            var isEnabled = await this._featureManager.IsEnabledAsync("MyFeature");

            return View();
        }
    }
}