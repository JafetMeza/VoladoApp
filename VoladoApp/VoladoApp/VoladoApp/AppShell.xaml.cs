﻿using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace VoladoApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            RegisterRoutes();
        }

        private void RegisterRoutes()
        {
            Routing.RegisterRoute("login", typeof(Views.Pruebas.Login));
            Routing.RegisterRoute("watchResults", typeof(Views.WatchAllResultsPage));
        }
    }
}
