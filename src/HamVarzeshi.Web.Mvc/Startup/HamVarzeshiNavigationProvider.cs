﻿using Abp.Application.Navigation;
using Abp.Authorization;
using Abp.Localization;
using HamVarzeshi.Authorization;

namespace HamVarzeshi.Web.Startup
{
    /// <summary>
    /// This class defines menus for the application.
    /// </summary>
    public class HamVarzeshiNavigationProvider : NavigationProvider
    {
        public override void SetNavigation(INavigationProviderContext context)
        {
            context.Manager.MainMenu
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.Home,
                        L("HomePage"),
                        url: "",
                        icon: "fas fa-home",
                        requiresAuthentication: true
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Clubs,
                        L("Clubs"),
                        url: "Clubs",
                        icon: "fas fa-list",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Clubs)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Tenants,
                        L("Tenants"),
                        url: "Tenants",
                        icon: "fas fa-building",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Tenants)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Users,
                        L("Users"),
                        url: "Users",
                        icon: "fas fa-users",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Users)
                    )
                ).AddItem(
                    new MenuItemDefinition(
                        PageNames.Roles,
                        L("Roles"),
                        url: "Roles",
                        icon: "fas fa-theater-masks",
                        permissionDependency: new SimplePermissionDependency(PermissionNames.Pages_Roles)
                            )
                )
                .AddItem(
                    new MenuItemDefinition(
                        PageNames.About,
                        L("About"),
                        url: "About",
                        icon: "fas fa-info-circle"
                    )                
                );
        }

        private static ILocalizableString L(string name)
        {
            return new LocalizableString(name, HamVarzeshiConsts.LocalizationSourceName);
        }
    }
}
