using System;
using Azure.Communication;
using Azure.Communication.Identity;

namespace AccessTokensQuickstart
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {
            Console.WriteLine("Azure Communication Services - Access Tokens Quickstart");
            var client = new CommunicationIdentityClient("<Azure Communication Services Endpoint>");

            var identityResponse = await client.CreateUserAsync();
            var identity = identityResponse.Value;
            Console.WriteLine($"\nCreated an identity with ID: {identity.Id}");

            // Issue an access token with the "voip" and "chat" scope for an identity
            var tokenResponse = await client.IssueTokenAsync(identity, scopes: new[] { CommunicationTokenScope.VoIP, CommunicationTokenScope.Chat });
            var token = tokenResponse.Value.Token;
            var expiresOn = tokenResponse.Value.ExpiresOn;
            Console.WriteLine($"\nIssued an access token with 'voip' and 'chat' scope that expires at {expiresOn}:");
            Console.WriteLine(token);
        }
    }
}