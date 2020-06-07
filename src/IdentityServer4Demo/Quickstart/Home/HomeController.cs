// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


using System.Collections.Generic;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IdentityServer4.Models;
using System.Linq;

namespace IdentityServer4.Quickstart.UI
{
    [SecurityHeaders]
    public class HomeController : Controller
    {
        private readonly IIdentityServerInteractionService _interaction;
        private readonly IEnumerable<Client> _clients;

        public HomeController(IIdentityServerInteractionService interaction, IEnumerable<Client> clients)
        {
            _interaction = interaction;
            _clients = clients;
        }

        public IActionResult Index()
        {
            var vm = new HomeViewModel
            {
                Clients = _clients.Select(c => new IdentityServer4Demo.Seed.Client
                {
                    ClientId = c.ClientId,
                    ClientSecrets = c.ClientSecrets.Select(s => new IdentityServer4Demo.Seed.Secret
                    {
                        Value = s.Value
                    }).ToList(),
                    AllowedScopes = c.AllowedScopes,
                    AccessTokenLifetime = c.AbsoluteRefreshTokenLifetime,
                    AllowedGrantTypes = c.AllowedGrantTypes,
                    Claims = c.Claims.ToDictionary(c => c.Type, c => c.Value)
                }).ToList()
            };

            return View(vm);
        }

        /// <summary>
        /// Shows the error page
        /// </summary>
        public async Task<IActionResult> Error(string errorId)
        {
            var vm = new ErrorViewModel();

            // retrieve error details from identityserver
            var message = await _interaction.GetErrorContextAsync(errorId);
            if (message != null)
            {
                vm.Error = message;
            }

            return View("Error", vm);
        }
    }
}