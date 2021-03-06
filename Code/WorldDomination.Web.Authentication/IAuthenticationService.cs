﻿using System;
using System.Collections.Specialized;

namespace WorldDomination.Web.Authentication
{
    /// <summary>
    /// Defines the contract that an authentication service must impliment.
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Registering a provider with this service.
        /// </summary>
        /// <param name="authenticationProvider">An Authentication Provider.</param>
        void AddProvider(IAuthenticationProvider authenticationProvider);

        /// <summary>
        /// Determine the uri which is used to redirect to a given Provider.
        /// </summary>
        /// <param name="providerKey">A Provider keyname.</param>
        /// <param name="callBackUri">The uri to call back to, after the Authentication Provider has completed it's authentication process.</param>
        /// <returns>The uri to redirect to.</returns>
        Uri RedirectToAuthenticationProvider(string providerKey, Uri callBackUri = null);

        /// <summary>
        /// Determine the uri which is used to redirect to a given Provider.
        /// </summary>
        /// <param name="authenticationServiceSettings">Specific authentication service settings to be passed along to the Authentication Provider.</param>
        /// <returns>The uri to redirect to.</returns>
        Uri RedirectToAuthenticationProvider(IAuthenticationServiceSettings authenticationServiceSettings);

        /// <summary>
        /// Retrieve the user information from the Authentication Provider.
        /// </summary>
        /// <param name="providerKey">A Provider keyname.</param>
        /// <param name="requestParameters">QueryString parameters from the callback uri.</param>
        /// <param name="state">Any optional state value. (Can be null for no state checks)</param>
        /// <returns>An authenticatedClient with either user information or some error message(s).</returns>
        IAuthenticatedClient GetAuthenticatedClient(string providerKey, NameValueCollection requestParameters, string state = null);

        /// <summary>
        /// Retrieve the user information from the Authentication Provider.
        /// </summary>
        /// <param name="providerKey">A Provider keyname.</param>
        /// <param name="requestParameters">QueryString parameters from the callback uri (Used by NancyFX).</param>
        /// <param name="state">Any optional state value. (Can be null for no state checks)</param>
        /// <returns>An authenticatedClient with either user information or some error message(s).</returns>
        IAuthenticatedClient GetAuthenticatedClient(string providerKey, dynamic requestParameters, string state = null);

        /// <summary>
        /// Retrieves the settings for an authentication service.
        /// </summary>
        /// <param name="providerKey">A Provider keyname.</param>
        /// <returns>The authentication service settings.</returns>
        IAuthenticationServiceSettings GetAuthenticateServiceSettings(string providerKey);
    }
}